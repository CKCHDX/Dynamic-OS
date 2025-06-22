#include "bootloader.h"
#include <efi.h>
#include <efilib.h>

EFI_STATUS setup_graphics(EFI_GRAPHICS_OUTPUT_PROTOCOL **gop) {
    EFI_GUID gop_guid = EFI_GRAPHICS_OUTPUT_PROTOCOL_GUID;
    EFI_STATUS status = uefi_call_wrapper(BS->LocateProtocol, 3, &gop_guid, NULL, (void**)gop);
    
    if (EFI_ERROR(status)) {
        return status;
    }
    
    // Set preferred mode (usually mode 0 is the highest resolution)
    return uefi_call_wrapper((*gop)->SetMode, 2, *gop, 0);
}
