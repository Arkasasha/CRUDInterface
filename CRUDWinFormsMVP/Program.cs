using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDWinFormsMVP.Models;
using CRUDWinFormsMVP.Presenters;
using CRUDWinFormsMVP._Repositories;
using CRUDWinFormsMVP.Views;
using System.Configuration;

namespace CRUDWinFormsMVP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string mySqlConnectionString = "Server=127.0.0.1;Port=3306;Database=shop_db;Uid=root;pwd=\"\"";
            IMainView view = new MainView();
            new MainPresenter(view, mySqlConnectionString);
            Application.Run((Form)view);
        }
    }
}
