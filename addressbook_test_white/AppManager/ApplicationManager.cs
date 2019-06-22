using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;


namespace addressbook_test_white
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        private GroupHelper groupHelper;
        

        public ApplicationManager()
        {
            //Запускаем приложение
            Application app = Application.Launch(@"C:\Program Files (x86)\GAS Softwares\Free Address Book\AddressBook.exe");

            MainWindow = app.GetWindow(WINTITLE); //Делаем видимым окно "Free Address Book"
            //Ожидания выполняются автоматически

            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();

            
        }


        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public Window MainWindow { get; private set; } //Проперти основного окна

    }
}
