using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.MakeModule
{
    public class MakeRepository
    {
        public Make[] makes = new Make[100];
        public int amountOfMakes = 0;

        public void RegisterMake(Make newMake)
        {
            newMake.Id = IdGenerator.GenerateMakeId();

            makes[amountOfMakes++] = newMake;
        }

        public bool EditMake(int selectedId, Make editedMake)
        {
            for (int i = 0; i < makes.Length; i++)
            {
                if (makes[i] == null)
                    continue;

                else if (makes[i].Id == selectedId)
                {
                    makes[i].Name = editedMake.Name;
                    makes[i].Email = editedMake.Email;
                    makes[i].Telephone = editedMake.Telephone;

                    return true;
                }
            } return false;
        }

        public bool DeleteMake(int selectedId)
        {
            for (int i = 0; i < makes.Length; i++)
            {
                if (makes[i] == null) continue;

                else if (makes[i].Id == selectedId)
                {
                    makes[i] = null;
                    return true;
                }
            } return false;
        }

        public Make[] SelectMakes()
        {
            return makes;
        }

        public Make GetMakeById(int makeId)
        {
            for (int i = 0; i < makes.Length; i++)
            {
                Make e = makes[i];


                if (e == null) continue;

                else if (e.Id == makeId) return e;
            } return null;
        }
    }
}
