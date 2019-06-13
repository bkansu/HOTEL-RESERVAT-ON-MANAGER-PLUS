using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Project2
{
    class Program
    {
        //ref link : https://stackoverflow.com/questions/3571627/show-hide-the-console-window-of-a-c-sharp-console-application
        [DllImport("kernel32.dll")]
       static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        static void Main(string[] args)
        {
            
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
             
            
            LoginScreen lg = new LoginScreen();
            Application.Run(lg);
            Environment.Exit(0);



        }

     
    }
}


