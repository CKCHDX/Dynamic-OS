# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.28

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:

#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:

# Disable VCS-based implicit rules.
% : %,v

# Disable VCS-based implicit rules.
% : RCS/%

# Disable VCS-based implicit rules.
% : RCS/%,v

# Disable VCS-based implicit rules.
% : SCCS/s.%

# Disable VCS-based implicit rules.
% : s.%

.SUFFIXES: .hpux_make_needs_suffix_list

# Command-line flag to silence nested $(MAKE).
$(VERBOSE)MAKESILENT = -s

#Suppress display of executed commands.
$(VERBOSE).SILENT:

# A target that is always out of date.
cmake_force:
.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /usr/bin/cmake

# The command to remove a file.
RM = /usr/bin/cmake -E rm -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /mnt/c/users/akoj2/desktop/oscyra/files/oscyra

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build

# Include any dependencies generated for this target.
include CMakeFiles/Oscyra.dir/depend.make
# Include any dependencies generated by the compiler for this target.
include CMakeFiles/Oscyra.dir/compiler_depend.make

# Include the progress variables for this target.
include CMakeFiles/Oscyra.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/Oscyra.dir/flags.make

Oscyra_autogen/timestamp: /usr/lib/qt5/bin/moc
Oscyra_autogen/timestamp: /usr/lib/qt5/bin/uic
Oscyra_autogen/timestamp: CMakeFiles/Oscyra.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --blue --bold --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Automatic MOC and UIC for target Oscyra"
	/usr/bin/cmake -E cmake_autogen /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles/Oscyra_autogen.dir/AutogenInfo.json ""
	/usr/bin/cmake -E touch /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/Oscyra_autogen/timestamp

CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.o: CMakeFiles/Oscyra.dir/flags.make
CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.o: Oscyra_autogen/mocs_compilation.cpp
CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.o: CMakeFiles/Oscyra.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Building CXX object CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.o -MF CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.o.d -o CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.o -c /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/Oscyra_autogen/mocs_compilation.cpp

CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Preprocessing CXX source to CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/Oscyra_autogen/mocs_compilation.cpp > CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.i

CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Compiling CXX source to assembly CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/Oscyra_autogen/mocs_compilation.cpp -o CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.s

CMakeFiles/Oscyra.dir/Root/main.cpp.o: CMakeFiles/Oscyra.dir/flags.make
CMakeFiles/Oscyra.dir/Root/main.cpp.o: /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Root/main.cpp
CMakeFiles/Oscyra.dir/Root/main.cpp.o: CMakeFiles/Oscyra.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_3) "Building CXX object CMakeFiles/Oscyra.dir/Root/main.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/Oscyra.dir/Root/main.cpp.o -MF CMakeFiles/Oscyra.dir/Root/main.cpp.o.d -o CMakeFiles/Oscyra.dir/Root/main.cpp.o -c /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Root/main.cpp

CMakeFiles/Oscyra.dir/Root/main.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Preprocessing CXX source to CMakeFiles/Oscyra.dir/Root/main.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Root/main.cpp > CMakeFiles/Oscyra.dir/Root/main.cpp.i

CMakeFiles/Oscyra.dir/Root/main.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Compiling CXX source to assembly CMakeFiles/Oscyra.dir/Root/main.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Root/main.cpp -o CMakeFiles/Oscyra.dir/Root/main.cpp.s

CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.o: CMakeFiles/Oscyra.dir/flags.make
CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.o: /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/MainWindow.cpp
CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.o: CMakeFiles/Oscyra.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_4) "Building CXX object CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.o -MF CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.o.d -o CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.o -c /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/MainWindow.cpp

CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Preprocessing CXX source to CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/MainWindow.cpp > CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.i

CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Compiling CXX source to assembly CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/MainWindow.cpp -o CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.s

CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.o: CMakeFiles/Oscyra.dir/flags.make
CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.o: /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/UIEffects.cpp
CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.o: CMakeFiles/Oscyra.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_5) "Building CXX object CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.o -MF CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.o.d -o CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.o -c /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/UIEffects.cpp

CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Preprocessing CXX source to CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/UIEffects.cpp > CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.i

CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Compiling CXX source to assembly CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/UIEffects.cpp -o CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.s

CMakeFiles/Oscyra.dir/Function/Functions.cpp.o: CMakeFiles/Oscyra.dir/flags.make
CMakeFiles/Oscyra.dir/Function/Functions.cpp.o: /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Function/Functions.cpp
CMakeFiles/Oscyra.dir/Function/Functions.cpp.o: CMakeFiles/Oscyra.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_6) "Building CXX object CMakeFiles/Oscyra.dir/Function/Functions.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/Oscyra.dir/Function/Functions.cpp.o -MF CMakeFiles/Oscyra.dir/Function/Functions.cpp.o.d -o CMakeFiles/Oscyra.dir/Function/Functions.cpp.o -c /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Function/Functions.cpp

CMakeFiles/Oscyra.dir/Function/Functions.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Preprocessing CXX source to CMakeFiles/Oscyra.dir/Function/Functions.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Function/Functions.cpp > CMakeFiles/Oscyra.dir/Function/Functions.cpp.i

CMakeFiles/Oscyra.dir/Function/Functions.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Compiling CXX source to assembly CMakeFiles/Oscyra.dir/Function/Functions.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Function/Functions.cpp -o CMakeFiles/Oscyra.dir/Function/Functions.cpp.s

CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.o: CMakeFiles/Oscyra.dir/flags.make
CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.o: /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Apps.cpp
CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.o: CMakeFiles/Oscyra.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_7) "Building CXX object CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.o -MF CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.o.d -o CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.o -c /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Apps.cpp

CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Preprocessing CXX source to CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Apps.cpp > CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.i

CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Compiling CXX source to assembly CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Apps.cpp -o CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.s

CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.o: CMakeFiles/Oscyra.dir/flags.make
CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.o: /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Manageapp.cpp
CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.o: CMakeFiles/Oscyra.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_8) "Building CXX object CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.o -MF CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.o.d -o CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.o -c /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Manageapp.cpp

CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Preprocessing CXX source to CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Manageapp.cpp > CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.i

CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Compiling CXX source to assembly CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Manageapp.cpp -o CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.s

CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.o: CMakeFiles/Oscyra.dir/flags.make
CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.o: /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Function/Button/Apps/Apps.cpp
CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.o: CMakeFiles/Oscyra.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_9) "Building CXX object CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.o -MF CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.o.d -o CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.o -c /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Function/Button/Apps/Apps.cpp

CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Preprocessing CXX source to CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Function/Button/Apps/Apps.cpp > CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.i

CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Compiling CXX source to assembly CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Function/Button/Apps/Apps.cpp -o CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.s

CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.o: CMakeFiles/Oscyra.dir/flags.make
CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.o: /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp
CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.o: CMakeFiles/Oscyra.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_10) "Building CXX object CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.o -MF CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.o.d -o CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.o -c /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp

CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Preprocessing CXX source to CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp > CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.i

CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Compiling CXX source to assembly CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp -o CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.s

CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.o: CMakeFiles/Oscyra.dir/flags.make
CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.o: /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp
CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.o: CMakeFiles/Oscyra.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_11) "Building CXX object CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.o -MF CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.o.d -o CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.o -c /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp

CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Preprocessing CXX source to CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp > CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.i

CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Compiling CXX source to assembly CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp -o CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.s

CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.o: CMakeFiles/Oscyra.dir/flags.make
CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.o: /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp
CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.o: CMakeFiles/Oscyra.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_12) "Building CXX object CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.o -MF CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.o.d -o CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.o -c /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp

CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Preprocessing CXX source to CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp > CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.i

CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Compiling CXX source to assembly CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp -o CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.s

CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.o: CMakeFiles/Oscyra.dir/flags.make
CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.o: /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp
CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.o: CMakeFiles/Oscyra.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_13) "Building CXX object CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.o"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.o -MF CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.o.d -o CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.o -c /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp

CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Preprocessing CXX source to CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp > CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.i

CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green "Compiling CXX source to assembly CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp -o CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.s

# Object files for target Oscyra
Oscyra_OBJECTS = \
"CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.o" \
"CMakeFiles/Oscyra.dir/Root/main.cpp.o" \
"CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.o" \
"CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.o" \
"CMakeFiles/Oscyra.dir/Function/Functions.cpp.o" \
"CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.o" \
"CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.o" \
"CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.o" \
"CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.o" \
"CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.o" \
"CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.o" \
"CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.o"

# External object files for target Oscyra
Oscyra_EXTERNAL_OBJECTS =

Oscyra: CMakeFiles/Oscyra.dir/Oscyra_autogen/mocs_compilation.cpp.o
Oscyra: CMakeFiles/Oscyra.dir/Root/main.cpp.o
Oscyra: CMakeFiles/Oscyra.dir/UI/MainWindow.cpp.o
Oscyra: CMakeFiles/Oscyra.dir/UI/UIEffects.cpp.o
Oscyra: CMakeFiles/Oscyra.dir/Function/Functions.cpp.o
Oscyra: CMakeFiles/Oscyra.dir/UI/Button/Apps/Apps.cpp.o
Oscyra: CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Manageapp.cpp.o
Oscyra: CMakeFiles/Oscyra.dir/Function/Button/Apps/Apps.cpp.o
Oscyra: CMakeFiles/Oscyra.dir/Function/Button/Apps/Manageapp/ManageFunctionApp.cpp.o
Oscyra: CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp.o
Oscyra: CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp.o
Oscyra: CMakeFiles/Oscyra.dir/UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp.o
Oscyra: CMakeFiles/Oscyra.dir/build.make
Oscyra: /usr/lib/x86_64-linux-gnu/libQt5Widgets.so.5.15.13
Oscyra: /usr/lib/x86_64-linux-gnu/libQt5Gui.so.5.15.13
Oscyra: /usr/lib/x86_64-linux-gnu/libQt5Core.so.5.15.13
Oscyra: CMakeFiles/Oscyra.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color "--switch=$(COLOR)" --green --bold --progress-dir=/mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_14) "Linking CXX executable Oscyra"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/Oscyra.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/Oscyra.dir/build: Oscyra
.PHONY : CMakeFiles/Oscyra.dir/build

CMakeFiles/Oscyra.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/Oscyra.dir/cmake_clean.cmake
.PHONY : CMakeFiles/Oscyra.dir/clean

CMakeFiles/Oscyra.dir/depend: Oscyra_autogen/timestamp
	cd /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /mnt/c/users/akoj2/desktop/oscyra/files/oscyra /mnt/c/users/akoj2/desktop/oscyra/files/oscyra /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build /mnt/c/users/akoj2/desktop/oscyra/files/oscyra/build/CMakeFiles/Oscyra.dir/DependInfo.cmake "--color=$(COLOR)"
.PHONY : CMakeFiles/Oscyra.dir/depend

