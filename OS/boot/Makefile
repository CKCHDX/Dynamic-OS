TARGET = bootloader.efi
SOURCES = bootloader.c memory.c graphics.c
OBJECTS = $(SOURCES:.c=.o)
ASM_SOURCES = boot64.S
ASM_OBJECTS = $(ASM_SOURCES:.S=.o)

CC = x86_64-w64-mingw32-gcc
LD = x86_64-w64-mingw32-ld
CFLAGS = -I. -I/usr/include/efi -I/usr/include/efi/x86_64 -DEFI_FUNCTION_WRAPPER -fno-stack-protector -fpic -fshort-wchar -mno-red-zone
LDFLAGS = -T ../linker/bootloader.ld -shared -Bsymbolic -L/usr/lib -l:libgnuefi.a -l:efi.a -lefi -lgnuefi

all: $(TARGET)

%.o: %.c
	$(CC) $(CFLAGS) -c -o $@ $<

%.o: %.S
	$(CC) $(CFLAGS) -c -o $@ $<

$(TARGET): $(OBJECTS) $(ASM_OBJECTS)
	$(LD) $(LDFLAGS) -o $@ $^

clean:
	rm -f $(TARGET) $(OBJECTS) $(ASM_OBJECTS)
TARGET = bootloader.efi
SOURCES = bootloader.c memory.c graphics.c
OBJECTS = $(SOURCES:.c=.o)
ASM_SOURCES = boot64.S
ASM_OBJECTS = $(ASM_SOURCES:.S=.o)

CC = x86_64-w64-mingw32-gcc
LD = x86_64-w64-mingw32-ld
CFLAGS = -I. -I/usr/include/efi -I/usr/include/efi/x86_64 -DEFI_FUNCTION_WRAPPER -fno-stack-protector -fpic -fshort-wchar -mno-red-zone
LDFLAGS = -T ../linker/bootloader.ld -shared -Bsymbolic -L/usr/lib -l:libgnuefi.a -l:efi.a -lefi -lgnuefi

all: $(TARGET)

%.o: %.c
	$(CC) $(CFLAGS) -c -o $@ $<

%.o: %.S
	$(CC) $(CFLAGS) -c -o $@ $<

$(TARGET): $(OBJECTS) $(ASM_OBJECTS)
	$(LD) $(LDFLAGS) -o $@ $^

clean:
	rm -f $(TARGET) $(OBJECTS) $(ASM_OBJECTS)
