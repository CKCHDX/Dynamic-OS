#include <efi.h>
#include <efilib.h>
#include "bootloader.h"

EFI_STATUS EFIAPI efi_main(EFI_HANDLE ImageHandle, EFI_SYSTEM_TABLE *SystemTable) {
    InitializeLib(ImageHandle, SystemTable);
    
    // Print bootloader header
    Print(L"Dynamic OS Bootloader\n");
    Print(L"Version 1.0\n\n");
    
    // Get memory map
    UINTN memory_map_size = 0;
    EFI_MEMORY_DESCRIPTOR *memory_map = NULL;
    UINTN map_key, descriptor_size;
    UINT32 descriptor_version;
    
    // First call to get buffer size
    SystemTable->BootServices->GetMemoryMap(&memory_map_size, memory_map, &map_key, &descriptor_size, &descriptor_version);
    memory_map_size += 2 * descriptor_size; // Safety buffer
    
    // Allocate pool for memory map
    EFI_STATUS status = SystemTable->BootServices->AllocatePool(EfiLoaderData, memory_map_size, (void**)&memory_map);
    if (EFI_ERROR(status)) {
        Print(L"Failed to allocate memory for map\n");
        return status;
    }
    
    // Get actual memory map
    status = SystemTable->BootServices->GetMemoryMap(&memory_map_size, memory_map, &map_key, &descriptor_size, &descriptor_version);
    if (EFI_ERROR(status)) {
        Print(L"Failed to get memory map\n");
        return status;
    }
    
    // Load kernel
    EFI_FILE_PROTOCOL *root_dir = get_root_dir(ImageHandle);
    void *kernel_entry = NULL;
    status = load_kernel(root_dir, L"kernel.elf", &kernel_entry);
    if (EFI_ERROR(status)) {
        Print(L"Failed to load kernel\n");
        return status;
    }
    
    // Exit boot services
    status = SystemTable->BootServices->ExitBootServices(ImageHandle, map_key);
    if (EFI_ERROR(status)) {
        Print(L"Failed to exit boot services\n");
        return status;
    }
    
    // Setup graphics
    EFI_GRAPHICS_OUTPUT_PROTOCOL *gop = NULL;
    status = setup_graphics(&gop);
    if (EFI_ERROR(status)) {
        Print(L"Failed to initialize graphics\n");
    }
    
    // Transfer control to kernel
    typedef void (*KernelEntryPoint)(void *boot_info);
    KernelEntryPoint entry = (KernelEntryPoint)kernel_entry;
    
    // Prepare boot info structure
    BootInfo boot_info = {
        .gop = gop,
        .memory_map = memory_map,
        .memory_map_size = memory_map_size,
        .descriptor_size = descriptor_size
    };
    
    entry(&boot_info);
    
    // Should never reach here
    while(1);
    return EFI_SUCCESS;
}
