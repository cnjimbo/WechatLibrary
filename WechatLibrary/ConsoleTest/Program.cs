using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Serialization;
using Common.Serialization.Json;
using WechatLibrary.MenuManagement;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonHelper.EnumFormat = Common.Serialization.Json.EnumFormat.Name;

            WechatLibrary.MenuManagement.Menu menu = new Menu();

            MenuButton btn1 = new MenuButton()
            {
                Name = "haha"
            };

            btn1.SubButton.Add(new MenuSubButton()
            {
                Name = "fff",
                Key = "shit",
                Type = MenuButtonType.Click
            });

            menu.Button.Add(btn1);

            string s = JsonHelper.SerializeToJson(menu);
            Console.WriteLine(s);

            var mmm = JsonHelper.Deserialize<Menu>(s);
            Console.WriteLine();

            Console.WriteLine(JsonHelper.SerializeToJson(mmm));

            Console.ReadKey();
        }
    }
}
