#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QMap>
#include <QPushButton>
#include <QLabel>
#include <QVBoxLayout>
#include <QHBoxLayout>
#include <QWidget>
#include <QStackedWidget>

#include "UIEffects.h"
#include "UI/Button/Apps/Apps.h"  // Ensure this includes AppsUI class

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget* parent = nullptr);
    ~MainWindow();

private:
    QWidget* centralWidget;
    QVBoxLayout* sidebarLayout;
    QHBoxLayout* mainLayout;
    QStackedWidget* contentStack;
    UIEffects* uiEffects;

    QPushButton* homeButton;
    QPushButton* appsButton;
    QPushButton* builtInAppsButton;
    QPushButton* dashboardButton;
    QPushButton* settingsButton;
    QPushButton* fileManagerButton;
    QPushButton* taskManagerButton;
    QPushButton* powerOptionsButton;
    QPushButton* networkButton;

    QLabel* titleLabel;
    QLabel* systemInfoLabel;
    QWidget* homePage;

    AppsUI* appsPage;  // FIX: Change Apps* to AppsUI*

    QMap<QPushButton*, QWidget*> pageMap;

    void setupUI();
    void applyStyles();

private slots:
    void onHomeClicked();
    void onAppsClicked();
    void onBuiltInAppsClicked();
    void onDashboardClicked();
    void onSettingsClicked();
    void onFileManagerClicked();
    void onTaskManagerClicked();
    void onPowerOptionsClicked();
    void onNetworkClicked();
};

#endif // MAINWINDOW_H
