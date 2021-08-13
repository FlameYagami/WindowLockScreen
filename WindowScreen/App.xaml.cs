using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WindowScreen.Helpers;
using WindowScreen.Views;
using Helpers = WindowScreen.Helpers.Helper;

namespace WindowScreen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {

        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Setting setting = Helper.GetSettingFromFile($"{AppDomain.CurrentDomain.BaseDirectory}setting.json");
            containerRegistry.RegisterInstance<Setting>(setting);
            containerRegistry.RegisterSingleton<Helper>(() => new Helper());
            containerRegistry.RegisterSingleton<KeyboardHook>(() => new KeyboardHook());
        
        }



    }
}
