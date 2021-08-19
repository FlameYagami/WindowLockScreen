using Prism.Ioc;
using System;
using System.Windows;
using WindowScreen.Helpers;
using WindowScreen.ViewModels;

namespace WindowScreen.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            Window window = Window.GetWindow(this);
            MainWindowViewModel vm = this.DataContext as MainWindowViewModel;
            vm.HiddenTheTaskBar(window);
            vm.ImmediatelyLock();
            vm.StartUp();
        }
    }
}
