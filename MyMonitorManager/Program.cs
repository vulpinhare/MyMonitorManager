using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace MyMonitorManager
{   
    class Program
    {
        static void Discription()
        {
            Console.WriteLine("================ 사용방법 ================");
            Console.WriteLine("MyMonitorManager.exe <arg1> <arg2> ...");
            Console.WriteLine("");
            Console.WriteLine("setprimary 0 : 0번 모니터를 주모니터로");
            Console.WriteLine("toggleprimary 0 0 : 0, 0번 모니터를 주모니터로 토글");
            Console.WriteLine("off : 화면 끄기");
            Console.WriteLine("");
            Console.WriteLine("===========================================");
        }

        static void Main(string[] args)
        {
            try
            {
                switch (args[0])
                {
                    case "setprimary":
                        uint set_monitor = Convert.ToUInt32(args[1]);
                        MonitorChanger.SetAsPrimaryMonitor(set_monitor);
                        break;

                    case "toggleprimary":
                        System.Windows.Forms.Screen[] screens = System.Windows.Forms.Screen.AllScreens;
                        for (uint i = 0; i < screens.Length; i++)
                        {
                            if (!Screen.Equals(screens[i], Screen.PrimaryScreen) & (Convert.ToUInt32(args[1]) == i | Convert.ToUInt32(args[2]) == i))
                            {
                                MonitorChanger.SetAsPrimaryMonitor(i);
                                break;
                            }
                        }
                        break;

                    case "off":
                        MonitorChanger.TurnOffMonitor();
                        break;

                    default:
                        Discription();
                        break;
                }
            }
            catch (Exception ex)
            {
                Discription();
            } 
        }
    }
}
