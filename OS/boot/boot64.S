[bits 64]
[extern kernel_main]

section .text
global start

start:
    ; Set up stack
    mov rsp, stack_top
    
    ; Clear direction flag
    cld
    
    ; Call kernel main
    mov rdi, rsp ; Pass boot info structure
    call kernel_main
    
    ; Halt if kernel returns
    cli
    hlt

section .bss
align 16
stack_bottom:
    resb 16384
stack_top:
