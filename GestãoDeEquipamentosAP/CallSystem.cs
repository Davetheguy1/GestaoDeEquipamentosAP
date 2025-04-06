using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP
{
    class CallSystem
    {
        public Call[] calls = new Call[100];
        public int amountOfCalls;

        Text text = new Text();

        public void RegisterCall()
        {
            
            text.CallRegisterText();
            Console.WriteLine("Titulo do Chamado:\n");
            string title = Console.ReadLine();

            Console.WriteLine("Descrição do Chamado:\n");
            string desciption = Console.ReadLine();

            Console.WriteLine("Nome do Equipamento a ser chamado:\n");
            string name = Console.ReadLine();

            Console.WriteLine("Data de Postagem do Chamado:");
            DateTime input = DateTime.Parse(Console.ReadLine());
               


            Call newCall = new Call(title, desciption, name);
            newCall.Id = IdGenerator.GenerateId();
            newCall.Posted = newCall.daysSincePosted(input);

            calls[amountOfCalls++] = newCall;

        }

        public void ViewCalls(bool showTitle)
        {

            if (showTitle)
            {
                text.CallVisualizerText();
            }

            Console.WriteLine("{0, -10} | {1, -18} | {2, -18} | {3, -15} | {4, -18} ", "Id", "Titulo", "Descrição", "Equipamento", "Dias desde Aberto");

            for (int i = 0; i < calls.Length; i++)
            {
                Call selectedCall = calls[i];

                if (selectedCall == null) continue;

                Console.WriteLine("{0, -10} | {1, -18} | {2, -18} | {3, -15} | {4, -18} ", selectedCall.Id, selectedCall.Title, selectedCall.Description, selectedCall.Name, selectedCall.Posted);
            }
            Console.WriteLine("\nPressione Enter para Continuar:\n\n");
            Console.ReadLine();
        }

        public void EditCall()
        {
            text.CallEditorText();
            ViewCalls(false);


            Console.WriteLine("\nDigite o ID do Chamado que deseja Editar:\n");
            int selectedId = int.Parse(Console.ReadLine());

            Console.WriteLine("Titulo do Chamado:\n");
            string title = Console.ReadLine();

            Console.WriteLine("Descrição do Chamado:\n");
            string desciption = Console.ReadLine();

            Console.WriteLine("Nome do Equipamento a ser chamado:\n");
            string name = Console.ReadLine();

            Console.WriteLine("Data de Postagem do Chamado:");
            DateTime input = DateTime.Parse(Console.ReadLine());

            Call newCall = new Call(title, desciption, name);
            newCall.Posted = newCall.daysSincePosted(input);
            bool wasEditSucessful = false;

            for (int i = 0; i < calls.Length; i++)
            {
                if (calls[i] == null) continue;

                else if (calls[i].Id == selectedId)
                {
                    calls[i].Title = newCall.Title;
                    calls[i].Description = newCall.Description;
                    calls[i].Name = newCall.Name;
                    calls[i].Posted = newCall.Posted;
                }
            }
            if (!wasEditSucessful)
            {
                Console.WriteLine("Erro na edição...");
                return;
            }
            Console.WriteLine("Chamado Editado com Sucesso.");
            Console.ReadLine();
        }

        public void Close()
        {
            text.CloseCallText();
            ViewCalls(false);


            Console.WriteLine("\nDigite o ID do Chamado que deseja Editar:\n");
            int selectedId = int.Parse(Console.ReadLine());
            bool wasEditSucessful = false;

            for (int i = 0; i < calls.Length; i++)
            {
                if (calls[i] == null) continue;

                else if (calls[i].Id == selectedId)
                {
                    calls[i] = null;
                    wasEditSucessful = true;
                }
            }
            if (!wasEditSucessful)
            {
                Console.WriteLine("Erro na edição...");
                return;
            }
            Console.WriteLine("Chamado Editado com Sucesso.");
            Console.ReadLine();
        }


    }
}
