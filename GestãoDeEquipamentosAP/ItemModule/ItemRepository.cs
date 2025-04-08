using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.ItemModule
{
    public class ItemRepository
    {
        public static Item[] Items = new Item[100];
        public int amountOfItems;

        public void RegisterItem(Item newItem)
        {
            newItem.Id = IdGenerator.GenerateItemID();

            Items[amountOfItems++] = newItem;
        }

        public bool EditItems(int selectedId, Item editedItem)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == null) continue;

                else if (Items[i].Id == selectedId)
                {
                    Items[i].Name = editedItem.Name;
                    Items[i].Make = editedItem.Make;
                    Items[i].Price = editedItem.Price;
                    Items[i].ManufactureDate = editedItem.ManufactureDate;

                    return true;
                }
            }
            return false;
        }

        public bool DeleteItems(int selectedId)
        {
            for (int i =0; i< Items.Length; i++)
            {
                if (Items[i] == null) continue;

                else if (Items[i].Id == selectedId)
                {
                    Items[i] = null;

                    return true;
                }
                

                
            }
            return false;
        }

        public Item[] SelectItem()
        {
            return Items;
        }

        public Item GetItemById(int selectedId)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Item item = Items[i];

                if (item == null) continue;

                else if (item.Id == selectedId) 
                    return item;
            }
            return null;
        }


    }
}
