using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WindowScreen.Helpers;
using WindowScreen.ViewModels;

namespace WindowScreen.Views
{
    /// <summary>
    /// VerifyPasswordWindow.xaml 的交互逻辑
    /// </summary>
    public partial class VerifyPasswordWindow : Window
    {
        public VerifyPasswordWindow()
        {
            InitializeComponent();
            Topmost = true;
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var window = Window.GetWindow(this);

            VerifyPasswordWindowViewModel vm = this.DataContext as VerifyPasswordWindowViewModel;

            vm.HiddenTheTaskbar(window);
            vm.GetTheVerifyPasswordWindow(window);
        }
    }
}
