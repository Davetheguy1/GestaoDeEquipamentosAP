using GestãoDeEquipamentosAP.ItemModule;
using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.CallModule
{
    class CallSystem
    {
        public ItemRepository ItemRepository;
        public CallRespository CallRepository;
        
        public CallSystem(ItemRepository itemRepository)
        {
            this.ItemRepository = itemRepository;
            CallRepository = new CallRespository();
        }

        Text text = new Text();

       
        public Call GetCallData()
        {
            Console.Clear();
            Console.WriteLine("Digite o Titúlo do Chamado:");
            string title = Console.ReadLine();

            Console.WriteLine("Digite a descrição do Chamado:");
            string description = Console.ReadLine();

            VisualizeItems();

            Console.WriteLine("Digite o ID do Equipamento a ser chamado");
            int selectedId = int.Parse(Console.ReadLine());

            Item selectedItem = ItemRepository.GetItemById(selectedId);

            Call newCall = new Call(title, description, selectedItem);

            return newCall;

            
        }
 
        public void RegisterCall() 
        {

            Call newCall = GetCallData();

            CallRepository.RegisterCall(newCall);

            Console.WriteLine("Chamado Registrado com Sucesso");
        }

        public void ViewCalls(bool showTitle)
        {
            
            if (showTitle)
            {
                text.CallVisualizerText();
            }

            Console.WriteLine("{0, -10} | {1, -18} | {2, -18} | {3, -15} | {4, -18} ", "Id", "Titulo", "Descrição", "Equipamento", "Dias desde Aberto");

            Call[] registeredCalls = CallRepository.selectCalls();
            Console.ReadLine();

            for (int i = 0; i < registeredCalls.Length; i++)
            {
                Call selectedCall = registeredCalls[i];

                if (selectedCall == null) continue;

                
                Console.WriteLine("{0, -10} | {1, -18} | {2, -18} | {3, -15} | {4, -18} ", selectedCall.Id, selectedCall.Title, selectedCall.Description, selectedCall.Item.Name, selectedCall.daysSincePosted());
            }
        }

        public void EditCall()
        {
            Console.Clear();
            ViewCalls(false);


            Console.WriteLine("\nDigite o ID do Chamado que deseja Editar:\n");
            int selectedId = int.Parse(Console.ReadLine());

            Call newCall = GetCallData();

            bool wasEditSucessfull = CallRepository.EditCall(selectedId, newCall);

            if (!wasEditSucessfull)
            {
                Notifier.ShowMessage("Ocorreu um Erro durante a edição", ConsoleColor.Red);

                return;
            }

            Notifier.ShowMessage("A Edição foi Execultada com Sucesso", ConsoleColor.Green);
            
        }

        public void Close()
        {
            text.CloseCallText();
            ViewCalls(false);


            Console.WriteLine("\nDigite o ID do Chamado que deseja Editar:\n");
            int selectedId = int.Parse(Console.ReadLine());
            bool wasEditSucessful = CallRepository.Close(selectedId);

            if(!wasEditSucessful)
            {
                Notifier.ShowMessage("Ocorreu um Erro durante a edição", ConsoleColor.Red);

                return;
            }

            Notifier.ShowMessage("A Edição foi Execultada com Sucesso", ConsoleColor.Green);
        }

        public void VisualizeItems()
        {
            text.VisualizerText();
            Console.WriteLine();

            Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
            "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação"
         );
            Item[] RegisteredItems = ItemRepository.SelectItem();
            
            for (int i = 0; i < RegisteredItems.Length; i++)
            {
                Item e = RegisteredItems[i];

                if (e == null) continue;

                Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                e.Id, e.Name, e.GetSerialNumber(), e.Make, e.Price.ToString("C2"), e.ManufactureDate.ToShortDateString()
             );
            }
            Notifier.ShowMessage("\nPressione ENTER para continuar...", ConsoleColor.DarkYellow);
        }


    }
}
