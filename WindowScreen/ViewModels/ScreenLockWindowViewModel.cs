using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowScreen.Helpers;
using WindowScreen.Views;

namespace WindowScreen.ViewModels
{
    public class ScreenLockWindowViewModel: BindableBase
    {
        private readonly IContainerExtension _container;

        private readonly Helper _helper;

        public DelegateCommand VerifyPasswordCommand { get; set; }
        public Window TheScreenLockWindow { get; private set; }

        public ScreenLockWindowViewModel(IContainerExtension container)
        {
            VerifyPasswordCommand = new DelegateCommand(VerifyPassword);
            _container = container;
            _helper = container.Resolve<Helper>();
        }

        private void VerifyPassword()
        {

            VerifyPasswordWindow vpw = _container.Resolve<VerifyPasswordWindow>();
            VerifyPasswordWindowViewModel vpwvm = vpw.DataContext as VerifyPasswordWindowViewModel;
            vpwvm.GetTheScreenLockWindow(TheScreenLockWindow);
            vpw.Show();
        }

        public void HiddenTheTaskBar(Window window)
        {
            _helper.HiddenWindowTaskbar(window);
        }

        public void GetTheScreenLockWindow(Window window)
        {
            TheScreenLockWindow = window;
        }
    }
}
