using GestãoDeEquipamentosAP.ItemModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.CallModule
{
    public class Call
    {
        public int Id;
        public string Title;
        public string Description;
        public Item Item;
        public DateTime Opened;

       
        public Call(string title, string description, Item item)
        {
            Title = title;
            Description = description;
            Item = item;
            
            Opened = DateTime.Now;
            
        }

        public int daysSincePosted()
        {
            TimeSpan diference = DateTime.Now - Opened;

            return diference.Days;
        }

        
    }
}
