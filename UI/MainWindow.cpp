#include <QPropertyAnimation>
#include <QGraphicsOpacityEffect>
#include "MainWindow.h"
#include "UIEffects.h"
#include "UI/Button/Apps/Apps.h"

#include <QDebug>

MainWindow::MainWindow(QWidget* parent)
    : QMainWindow(parent),
    centralWidget(new QWidget(this)),
    uiEffects(new UIEffects(this)),
    contentStack(new QStackedWidget(this)),
    homePage(nullptr),
    appsPage(nullptr)
{
    setupUI();
    applyStyles();
    setCentralWidget(centralWidget);

    showFullScreen();

    appsPage = new AppsUI(this);  // FIX: Change Apps to AppsUI
    homePage = new QWidget(this);

    pageMap[appsButton] = appsPage;
    pageMap[homeButton] = homePage;

    contentStack->addWidget(homePage);
    contentStack->addWidget(appsPage);

    contentStack->setCurrentWidget(homePage);
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
    connect(fileManagerButton, &QPushButton::clicked, this, &MainWindow::onFileManagerClicked);
    connect(taskManagerButton, &QPushButton::clicked, this, &MainWindow::onTaskManagerClicked);
    connect(powerOptionsButton, &QPushButton::clicked, this, &MainWindow::onPowerOptionsClicked);
    connect(networkButton, &QPushButton::clicked, this, &MainWindow::onNetworkClicked);
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
    contentStack->setCurrentWidget(homePage);  // Change this if you have a specific page
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}

void MainWindow::onDashboardClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(homePage);  // Change this if needed
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}

void MainWindow::onSettingsClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(homePage);
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}

void MainWindow::onFileManagerClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(homePage);
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}

void MainWindow::onTaskManagerClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(homePage);
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}

void MainWindow::onPowerOptionsClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(homePage);
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}

void MainWindow::onNetworkClicked()
{
    uiEffects->fadeOut(contentStack->currentWidget(), 500);
    contentStack->setCurrentWidget(homePage);
    uiEffects->fadeIn(contentStack->currentWidget(), 500);
}
