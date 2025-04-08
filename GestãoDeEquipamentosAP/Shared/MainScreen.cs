using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.Shared
{
    public class MainScreen
    {
        Text text = new Text();

        public char ShowMenu()
        {
            text.MainMenuText();
            char Option =Console.ReadLine()[0];
            return Option;
        }
    }
}
