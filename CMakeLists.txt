cmake_minimum_required(VERSION 3.10)

project(Oscyra)

set(CMAKE_CXX_STANDARD 17)

# If needed, adjust Qt version
find_package(Qt5 COMPONENTS Widgets REQUIRED)

# Include directories
include_directories(
    ${CMAKE_SOURCE_DIR}/UI
    ${CMAKE_SOURCE_DIR}/UI/Button
    ${CMAKE_SOURCE_DIR}/UI/Button/Apps
    ${CMAKE_SOURCE_DIR}/UI/Button/Apps/Manageapp
    ${CMAKE_SOURCE_DIR}/Function
    ${CMAKE_SOURCE_DIR}/Function/Button
    ${CMAKE_SOURCE_DIR}/Function/Button/Apps
    ${CMAKE_SOURCE_DIR}/Function/Button/Apps/Manageapp
)

set(CMAKE_AUTOMOC ON)
set(CMAKE_AUTOUIC ON)
set(CMAKE_INCLUDE_CURRENT_DIR ON)

set(SOURCES
    # Root / main
    Root/main.cpp

    # MainWindow + UIEffects
    UI/MainWindow.cpp
    UI/UIEffects.cpp

    # Functions
    Function/Functions.cpp

    # Apps (UI)
    UI/Button/Apps/Apps.cpp

    # Manage Apps (UI)
    UI/Button/Apps/Manageapp/Manageapp.cpp  # Added this line

    # Apps (Function)
    Function/Button/Apps/Apps.cpp

    # Manage Apps (Function)
    Function/Button/Apps/Manageapp/ManageFunctionApp.cpp  # Added this line
    UI/Button/Apps/Manageapp/Content/Addapp/AddApp.cpp
    UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.cpp
    UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.cpp
)

set(HEADERS
    UI/MainWindow.h
    UI/UIEffects.h
    Function/Functions.h

    # Apps (UI)
    UI/Button/Apps/Apps.h

    # Manage Apps (UI)
    UI/Button/Apps/Manageapp/Manageapp.h  # Added this line

    # Apps (Function)
    Function/Button/Apps/Apps.h

    # Manage Apps (Function)
    Function/Button/Apps/Manageapp/ManageFunctionApp.h  # Added this line
    UI/Button/Apps/Manageapp/Content/Addapp/AddApp.h
    UI/Button/Apps/Manageapp/Content/Manageapp/ManageAppPage.h
    UI/Button/Apps/Manageapp/Content/Uninstallapp/UninstallApp.h
)

add_executable(${PROJECT_NAME}
    ${SOURCES}
    ${HEADERS}  # So MOC can process Q_OBJECT classes
)

target_link_libraries(${PROJECT_NAME} Qt5::Widgets)
