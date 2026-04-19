using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDatabaseStore
{
    internal static class Program
    {
        /// <summary>
        /// Класс Program содержит точку входа в приложение.
        /// Именно с этого класса начинается запуск программы.
        /// В методе Main выполняется инициализация визуальных стилей
        /// и открытие главной формы MainForm.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

