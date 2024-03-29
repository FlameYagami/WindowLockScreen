﻿using PInvoke;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Interop;

namespace WindowScreen.Helpers
{
    public class Helper
    {

        public  void HiddenWindowTaskbar(Window window)
        {
            // 隐藏任务栏图标 和 Alt + Tab 时的窗口
            if (window == null) return;
            var handle = new WindowInteropHelper(window).Handle;
            int exStyle = User32.GetWindowLong(handle, User32.WindowLongIndexFlags.GWL_EXSTYLE);
            exStyle = exStyle | (int)User32.SetWindowLongFlags.WS_EX_TOOLWINDOW;
            User32.SetWindowLong(handle, User32.WindowLongIndexFlags.GWL_EXSTYLE, (User32.SetWindowLongFlags)exStyle);

        }
        public static Setting GetSettingFromFile(string path)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            var setting = new Setting();
            if (!File.Exists(path))
            {
                string json = JsonSerializer.Serialize(setting, options);
                File.WriteAllText(path, json);
                return setting;
            }
            string set = File.ReadAllText(path);
            setting = JsonSerializer.Deserialize<Setting>(set, options);

            return setting;
        }


        public static void StartUpTheApp(bool flag)
        {
            string startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            var appPath = Process.GetCurrentProcess().MainModule.FileName;
            var shortcutName = System.IO.Path.GetFileNameWithoutExtension(appPath);
            var linkPath = $@"{startupPath}\{shortcutName}.lnk";

            if (flag)
            {
                if (!File.Exists(linkPath))
                {

                    var workPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                    var shellType = Type.GetTypeFromProgID("WScript.shell");
                    dynamic shell = Activator.CreateInstance(shellType);
                    var shortcut = shell.CreateShortcut(linkPath);
                    shortcut.TargetPath = appPath;
                    shortcut.WorkingDirectory = workPath;
                    shortcut.Save();

                }
            }
            else
            {
                if (File.Exists(linkPath))
                {
                    File.Delete(linkPath);
                }
            }

        }
    }
}
