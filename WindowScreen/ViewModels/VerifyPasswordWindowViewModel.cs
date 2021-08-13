using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowScreen.Helpers;
using WindowScreen.Views;
using System.Windows;
namespace WindowScreen.ViewModels
{
    public class VerifyPasswordWindowViewModel: BindableBase
    {
        private string password;
        public string Password 
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        private string passwordTip;
        public string PasswordTip
        {
            get { return passwordTip; }
            set { SetProperty(ref passwordTip, value); }
        }
        private readonly Setting _setting;
        private readonly KeyboardHook _keyboardHook;

        private readonly Helper _helper;
        public DelegateCommand CheckPasswordCommand { get; set; }
        public DelegateCommand CloseTheWindowCommand { get; set; }
        public Window TheVerifyPasswordWindow { get; private set; }
        public Window TheScreenLockWindow { get; private set; }

        public VerifyPasswordWindowViewModel(IContainerExtension container)
        {
            CheckPasswordCommand = new DelegateCommand(CheckPassword);
            CloseTheWindowCommand = new DelegateCommand(CloseWindow);
            Password = string.Empty;
            PasswordTip = string.Empty;
            _setting = container.Resolve<Setting>();
            _helper = container.Resolve<Helper>();
            _keyboardHook = container.Resolve<KeyboardHook>();
        }

        private void CloseWindow()
        {
            TheVerifyPasswordWindow.Close();
        }

        public void HiddenTheTaskbar(Window window)
        {
            _helper.HiddenWindowTaskbar(window);
        }

        private void CheckPassword()
        {

            if (string.IsNullOrWhiteSpace(Password) || string.IsNullOrEmpty(Password))
            {
                return;
            }
            Password = Password.Trim();

            
            
            if (Password != _setting.Password)
            {
                Password = string.Empty;
                PasswordTip = "密码输入错误";
                return;
            }

            Password = string.Empty;
            PasswordTip = string.Empty;
            _keyboardHook.HookClear();
            TheScreenLockWindow.Close();
            TheVerifyPasswordWindow.Close();
            if (_setting.Accident)
            {
                Helper.StartUpTheApp(false);
            }

        }

        public void GetTheVerifyPasswordWindow(Window window)
        {
            TheVerifyPasswordWindow = window;
        }
        public void GetTheScreenLockWindow(Window window)
        {
            TheScreenLockWindow = window;
        }
    }
}
