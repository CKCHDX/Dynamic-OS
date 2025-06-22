#include "bootloader.h"
#include <efi.h>
#include <efilib.h>

EFI_STATUS get_memory_map(UINTN *memory_map_size, EFI_MEMORY_DESCRIPTOR **memory_map,
                          UINTN *map_key, UINTN *descriptor_size, UINT32 *descriptor_version) {
    *memory_map = NULL;
    
    // First call to get buffer size
    EFI_STATUS status = uefi_call_wrapper(BS->GetMemoryMap, 5, memory_map_size, *memory_map,
                                          map_key, descriptor_size, descriptor_version);
    if (status != EFI_BUFFER_TOO_SMALL) {
        return status;
    }
    
    // Allocate pool for memory map
    status = uefi_call_wrapper(BS->AllocatePool, 3, EfiLoaderData, *memory_map_size, (void**)memory_map);
    if (EFI_ERROR(status)) {
        return status;
    }
    
    // Get actual memory map
    return uefi_call_wrapper(BS->GetMemoryMap, 5, memory_map_size, *memory_map,
                             map_key, descriptor_size, descriptor_version);
}
