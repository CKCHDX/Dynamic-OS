OUTPUT_FORMAT(pe-x86-64)
ENTRY(efi_main)
SECTIONS {
    . = 0x200000;
    .text : {
        *(.text)
        *(.text.*)
    }
    .data : {
        *(.data)
        *(.data.*)
        *(.rodata)
        *(.rodata.*)
    }
    .bss : {
        *(.bss)
        *(.bss.*)
        *(COMMON)
    }
    /DISCARD/ : {
        *(.eh_frame)
        *(.comment)
    }
}
