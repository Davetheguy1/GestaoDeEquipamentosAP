using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.CallModule
{
    public class CallRespository
    {
        public Call[] calls = new Call[100];
        public int amountOfCalls = 0;

        public void RegisterCall(Call newCall)
        {
            newCall.Id = IdGenerator.GenerateCallID();
            calls[amountOfCalls++] = newCall;
        }

        public bool EditCall(int selectedId, Call newCall)
        {
            for (int i = 0; i < calls.Length; i++)
            {
                if (calls[i] == null) continue;

                else if (calls[i].Id == selectedId)
                {
                    calls[i].Description = newCall.Description;
                    calls[i].Title = newCall.Title;
                    calls[i].Opened = newCall.Opened;

                    return true;
                }
            }

            return false;
        }

        public Call[] selectCalls()
        {
            return calls;
        }

        public bool Close(int selectedId)
        {
            for (int i = 0; i < calls.Length; i++)
            {
                if (calls[i] == null) continue;

                else if (calls[i].Id == selectedId)
                {
                    calls[i] = null;
                    return true;
                }
            }
            return false;
        }

    }
}
