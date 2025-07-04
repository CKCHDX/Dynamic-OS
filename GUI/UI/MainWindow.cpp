#include <QPropertyAnimation>
#include <QGraphicsOpacityEffect>
#include "MainWindow.h"
#include "UIEffects.h"
#include "UI/Button/Apps/Apps.h"
#include "UI/Button/Power Options/Power Options.h"
#include <QDebug>
#include <QApplication>
#include "UI/Button/Network/Network.h"
#include "UI/Button/File Manager/File Manager.h"
#include "UI/Button/Built-In Apps/Built-In Apps.h"
#include "UI/Button/Settings/Settings.h"
#include "UI/Button/Task Manager/Task Manager.h"


MainWindow::MainWindow(QWidget* parent)
    : QMainWindow(parent),
      centralWidget(new QWidget(this)),
      uiEffects(new UIEffects(this)),
      contentStack(new QStackedWidget(this)),
      homePage(new QWidget(this)),
      appsPage(new AppsUI(this)),
      powerOptionsPage(new PowerOptionsUI(this)),
      networkPage(new Network(this)),
      fileManagerPage(new FileManager(this)),
      builtInAppsPage(new BuiltInApps(this)),
      dashboardPage(new Dashboard(this)),
      settingsPage(new Settings(this)),
      taskManagerPage(new TaskManager(this))


{
    setupUI();
    applyStyles();
    setCentralWidget(centralWidget);



    // Map buttons to their pages
    pageMap[appsButton] = appsPage;
    pageMap[homeButton] = homePage;
    pageMap[builtInAppsButton] = builtInAppsPage;
    pageMap[networkButton] = networkPage;
    pageMap[fileManagerButton] = fileManagerPage;
    pageMap[dashboardButton] = dashboardPage;
    pageMap[settingsButton] = settingsPage;
    pageMap[taskManagerButton] = taskManagerPage;



    // Add pages to the stacked widget
    contentStack->addWidget(homePage);
    contentStack->addWidget(appsPage);
    contentStack->addWidget(builtInAppsPage);
    contentStack->addWidget(dashboardPage);
    contentStack->addWidget(fileManagerPage);
    contentStack->addWidget(powerOptionsPage);
    contentStack->addWidget(networkPage);
    contentStack->addWidget(settingsPage);
    contentStack->addWidget(taskManagerPage);




    // Set the initial page
    contentStack->setCurrentWidget(homePage);
    showFullScreen();
}




MainWindow::~MainWindow()
{
}

void MainWindow::setupUI()
{
    // Create main layouts
    mainLayout = new QHBoxLayout;
    sidebarLayout = new QVBoxLayout;

    // Create QStackedWidget if not already created
    // (We already did it in the constructor initialization list.)

    // Initialize sidebar buttons
    homeButton = new QPushButton("Home");
    appsButton = new QPushButton("Apps");
    builtInAppsButton = new QPushButton("Built-In Apps");
    dashboardButton = new QPushButton("Dashboard");
    settingsButton = new QPushButton("Settings");
    fileManagerButton = new QPushButton("File Manager");
    taskManagerButton = new QPushButton("Task Manager");
    powerOptionsButton = new QPushButton("Power Options");
    networkButton = new QPushButton("Network");

    // Spacing & sidebar arrangement
    sidebarLayout->setSpacing(15);
    sidebarLayout->addWidget(homeButton);
    sidebarLayout->addWidget(appsButton);
    sidebarLayout->addWidget(builtInAppsButton);
    sidebarLayout->addWidget(dashboardButton);
    sidebarLayout->addWidget(settingsButton);
    sidebarLayout->addWidget(fileManagerButton);
    sidebarLayout->addWidget(taskManagerButton);
    sidebarLayout->addWidget(powerOptionsButton);
    sidebarLayout->addWidget(networkButton);
    sidebarLayout->addStretch();

    // Create the home page layout
    if (!homePage) {
        homePage = new QWidget;
    }
    QVBoxLayout* homeLayout = new QVBoxLayout(homePage);

    titleLabel = new QLabel("Welcome to Dynamic OS", homePage);
    titleLabel->setAlignment(Qt::AlignCenter);

    systemInfoLabel = new QLabel(
        "System Information:\n"
        "CPU Usage: 4.9%\n"
        "RAM Usage: 5286 MB\n"
        "Battery Status: 88% (Discharging)",
        homePage);
    systemInfoLabel->setAlignment(Qt::AlignCenter);

    // Add labels to home layout
    homeLayout->addWidget(titleLabel);
    homeLayout->addWidget(systemInfoLabel);
    homePage->setLayout(homeLayout);

    // Combine sidebar & stack in main layout
    mainLayout->addLayout(sidebarLayout, 1);
    mainLayout->addWidget(contentStack, 4);

    centralWidget->setLayout(mainLayout);

    //
    // Connect signals/slots
    //
    connect(homeButton, &QPushButton::clicked, this, &MainWindow::onHomeClicked);
    connect(appsButton, &QPushButton::clicked, this, &MainWindow::onAppsClicked);

    connect(builtInAppsButton, &QPushButton::clicked, this, &MainWindow::onBuiltInAppsClicked);
    connect(dashboardButton, &QPushButton::clicked, this, &MainWindow::onDashboardClicked);
    connect(settingsButton, &QPushButton::clicked, this, &MainWindow::onSettingsClicked);
    connect(settingsPage, &Settings::performanceModeChanged, this, &MainWindow::onPerformanceModeChanged);

    connect(fileManagerButton, &QPushButton::clicked, this, &MainWindow::onFileManagerClicked);
    connect(taskManagerButton, &QPushButton::clicked, this, &MainWindow::onTaskManagerClicked);
    connect(powerOptionsButton, &QPushButton::clicked, this, &MainWindow::onPowerOptionsClicked);
    connect(networkButton, &QPushButton::clicked, this, &MainWindow::onNetworkClicked);
    taskbarWidget = new TaskbarWidget(this);
    sidebarLayout->addWidget(taskbarWidget);


}

void MainWindow::applyStyles()
{
    setStyleSheet(
        "QMainWindow { "
        "  background: qlineargradient(spread:pad, x1:0, y1:0, x2:1, y2:1, "
        "              stop:0 #1e1e1e, stop:1 #2d2d30); "
        "}"
        "QPushButton { "
        "  background-color: rgba(255, 255, 255, 0.1); "
        "  color: white; "
        "  border-radius: 15px; "
        "  border: 1px solid #3c3c3c; "
        "  padding: 12px; "
        "  font-size: 16px; "
        "  transition: all 0.2s ease-in-out; "
        "}"
        "QPushButton:hover { "
        "  background-color: rgba(255, 255, 255, 0.2); "
        "  box-shadow: 0px 0px 15px rgba(255, 255, 255, 0.5); "
        "  transform: scale(1.05); "
        "}"
        "QPushButton:pressed { "
        "  background-color: rgba(255, 255, 255, 0.3); "
        "  transform: scale(0.95); "
        "}"
        "QLabel { "
        "  color: white; "
        "  font-size: 20px; "
        "}"
    );
}

// Slot implementations
void MainWindow::onHomeClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(homePage);
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}

void MainWindow::onAppsClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(appsPage);
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}
void MainWindow::onBuiltInAppsClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(builtInAppsPage);
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}


void MainWindow::onDashboardClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(dashboardPage);
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}

void MainWindow::onSettingsClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(settingsPage);  // Was: homePage
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}


void MainWindow::onFileManagerClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(fileManagerPage);
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}


void MainWindow::onTaskManagerClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(taskManagerPage);  // Was: homePage
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}


void MainWindow::onPowerOptionsClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(powerOptionsPage);
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}

void MainWindow::onNetworkClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(networkPage);
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}
void MainWindow::onPerformanceModeChanged(int mode)
{
    currentPerformanceMode = static_cast<SystemSettings::PerformanceMode>(mode);
    applyPerformanceMode();
}

void MainWindow::applyPerformanceMode()
{
    switch (currentPerformanceMode) {
        case SystemSettings::LowPerformance:
            uiEffects->setAnimationsEnabled(false);
            break;
        case SystemSettings::NormalPerformance:
            uiEffects->setAnimationsEnabled(true);
            uiEffects->setAnimationDuration(300);
            break;
        case SystemSettings::HighPerformance:
            uiEffects->setAnimationsEnabled(true);
            uiEffects->setAnimationDuration(500);
            break;
    }
}


