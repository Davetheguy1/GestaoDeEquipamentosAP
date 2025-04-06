using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP
{
    public class Call
    {
        public int Id;
        public string Title;
        public string Description;
        public string Name;
        public TimeSpan Posted;

       
        public Call(string title, string description, string name)
        {
            
            Title = title;
            Description = description;
            Name = name;
            
        }

        public TimeSpan daysSincePosted(DateTime input)
        {
            DateTime currentDateTime = new DateTime();

            TimeSpan finalDatetime = currentDateTime - input;

            return finalDatetime;
        }
    }
}
