using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.ItemModule
{
    public class Item
    {
        public int Id;
        public string Name;
        public string Make;
        public decimal Price;
        public DateTime ManufactureDate;

        public Item(string name, string make, decimal price, DateTime manufactureDate) //this is a constructor
        {
            
            Name = name;
            Make = make;
            Price = price;
            ManufactureDate = manufactureDate;
        }

        public string GetSerialNumber()
        {
            string serial1 = Name.Substring(0,3).ToUpper();

            
            return $"{serial1}-{Id}";
        }
    
    
    }
}
