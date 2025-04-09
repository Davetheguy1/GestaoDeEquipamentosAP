using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.Shared
{
    public static class IdGenerator // o static faz com que esse valores sejam constantes indepente da instancia. 
    {
        public static int ItemId = 0;
        public static int CallId = 0;
        public static int MakeId = 0;

        public static int GenerateItemID()
        {
            ItemId++;
            return ItemId;
        }

        public static int GenerateCallID()
        {
            CallId++;
            return CallId;
        }

        public static int GenerateMakeId()
        {
            MakeId++;
            return MakeId;
        }
    }
}
