using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowScreen.Helpers
{
    public class Setting
    {
        public string README { get; set; } = "开机自启、运行程序后立即锁屏、意外关机重启后自动锁屏、密码";

        public bool StartUp { get; set; } = false;
        public bool ImmediatelyLock { get; set; } = false;
        public bool Accident { get; set; } = false;
        public string Password { get; set; } = "348440076";
    }
}
