using GestãoDeEquipamentosAP.ItemModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.MakeModule
{
    public class Make
    {
        public int Id;
        public string Name;
        public string Email;
        public string Telephone;
        public Item[] Items;

        public Make(string name, string email, string telephone)
        {
            Name = name;
            Email = email;
            Telephone = telephone;
        }

        public void AddItem(Item item)
        {
            for(int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == null)
                {
                    Items[i] = item;
                }
            }
        }


        public void DeleteItem(Item item)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == null)
                {
                    continue;
                } else if (Items[i] == item)
                {
                    Items[i] = null;
                    return;
                }
            }
        }

        public int AmountOfItemsInMake()
        {
            int counter = 0;

            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] != null)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
