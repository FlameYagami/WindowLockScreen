using Microsoft.VisualBasic.CompilerServices;
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
    /// ScreenLockWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ScreenLockWindow : Window
    {
        public ScreenLockWindow()
        {
            InitializeComponent();
            Background = Brushes.White;
            Opacity = 0.01;
            Topmost = true;
            Width = SystemParameters.PrimaryScreenWidth;
            Height = SystemParameters.PrimaryScreenHeight;

        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var window = Window.GetWindow(this);

            ScreenLockWindowViewModel vm = this.DataContext as ScreenLockWindowViewModel;
            vm.HiddenTheTaskBar(window);
            vm.GetTheScreenLockWindow(window);
;        }
    }
}
