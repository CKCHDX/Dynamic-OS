#ifndef BOOTLOADER_H
#define BOOTLOADER_H

#include <efi.h>

typedef struct {
    EFI_GRAPHICS_OUTPUT_PROTOCOL *gop;
    EFI_MEMORY_DESCRIPTOR *memory_map;
    UINTN memory_map_size;
    UINTN descriptor_size;
} BootInfo;

EFI_FILE_PROTOCOL* get_root_dir(EFI_HANDLE ImageHandle);
EFI_STATUS load_kernel(EFI_FILE_PROTOCOL *root_dir, CHAR16 *filename, void **entry_point);
EFI_STATUS setup_graphics(EFI_GRAPHICS_OUTPUT_PROTOCOL **gop);

#endif // BOOTLOADER_H
