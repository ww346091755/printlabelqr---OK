using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace printlabelqr
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool ret;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out ret);
            if (ret)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
               Application.Run(new Form2());
                 //Application.Run(new LideSPA());
                //Application.Run(new deyi());
                //Application.Run(new SUPPLIES());
            }
        }
    }
}
