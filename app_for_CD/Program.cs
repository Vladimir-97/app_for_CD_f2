using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_for_CD
{
    static class Data
    {
        public static bool it_ok = false;
        public static string st_date_orig { get; set; }
        public static string end_date_orig { get; set; }
        public static string number_ser = "-1000";
        public static string name_cl = " ";
        public static int f_n { get; set; }
        public static int f_s { get; set; }
        public static int f_d { get; set; }
        public static int login = 0;
        public static int role = 0;
        public static bool exit = false;

    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_agreement());
        }
    }

}
