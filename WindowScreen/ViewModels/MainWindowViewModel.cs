using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Windows;
using WindowScreen.Helpers;
using WindowScreen.Views;

namespace WindowScreen.ViewModels
{
    public class MainWindowViewModel: BindableBase
    { 

        private readonly IContainerExtension _container;
        private readonly KeyboardHook _keyboardHook;
        private readonly Helper _helper;
        private readonly Setting _setting;

        public DelegateCommand LockTheScreenCommand { get; set; }
        public DelegateCommand ExitTheAppCommand { get; set; }
        public MainWindowViewModel(IContainerExtension container)
        {

            _container = container;
            _keyboardHook = _container.Resolve<KeyboardHook>();
            _helper = container.Resolve<Helper>();
            _setting = container.Resolve<Setting>();
            LockTheScreenCommand = new DelegateCommand(LockTheScreen);
            ExitTheAppCommand = new DelegateCommand(ExitTheApp);
        }

        private void ExitTheApp()
        {
            if (_setting.Accident)
            {
                Helper.StartUpTheApp(false);
            }
            _keyboardHook.HookClear();
            Application.Current.Shutdown();
            Environment.Exit(0);
        }

        private void LockTheScreen()
        {
            StartLockScreen();
        }

        public void StartLockScreen()
        {
            if (_setting.Accident)
            {
                Helper.StartUpTheApp(true);
            }
            ScreenLockWindow slw = _container.Resolve<ScreenLockWindow>();
            slw.Show();
            _keyboardHook.HookStart();
         
        }

        public void HiddenTheTaskBar(Window window)
        {

            _helper.HiddenWindowTaskbar(window);
        }
    }
}
