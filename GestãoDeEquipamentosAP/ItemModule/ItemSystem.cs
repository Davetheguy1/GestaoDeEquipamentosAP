using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.ItemModule
{
    public class ItemSystem
    {
        

        Text text = new Text();

        public ItemRepository itemRepository;

        public ItemSystem()
        {
            itemRepository = new ItemRepository();
        }


        public void Register()
        {
            text.RegisterText();
            Console.WriteLine("Nome do Equipamento:\n");
            string name = Console.ReadLine();

            Console.WriteLine("Nome do Fabricante:\n");
            string make = Console.ReadLine();

            Console.WriteLine("Preço de Aquisição:\n");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Data de Fabricação (dd/mm/yyyy):");
            DateTime manufactureDate = DateTime.Parse(Console.ReadLine());

            Item newItem = new Item(name, make, price, manufactureDate);
            newItem.Id = IdGenerator.GenerateItemID();

            itemRepository.RegisterItem(newItem);

            Notifier.ShowMessage("Equipamento Registrado com Sucesso!", ConsoleColor.Green);
        }


        public void Visualize(bool showTitle)
        {
            
            if (showTitle)
            {
                text.VisualizerText();
            }

            Console.WriteLine("{0, -10} | {1, -18} | {2, -11} | {3, -15} | {4, -18} | {5, -10}", "ID", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação");

            Item[] registeredItems = itemRepository.SelectItem();

            for (int i = 0; i < registeredItems.Length; i++)
            {
                Item selectedItem = registeredItems[i];

                if (selectedItem == null) continue;

                Console.WriteLine("{0, -10} | {1, -18} | {2, -11} | {3, -15} | {4, -18} | {5, -10}", selectedItem.Id, selectedItem.Name, selectedItem.GetSerialNumber(), selectedItem.Make, selectedItem.Price.ToString("C2"), selectedItem.ManufactureDate.ToShortDateString());
            }
            
            Notifier.ShowMessage("\nPressione Enter para continuar", ConsoleColor.DarkYellow);
            
        }

        public void Edit()
        {
            text.EditorText();
            Visualize(false);
            Console.WriteLine("\nDigite o ID do Equipamento que deseja Editar:\n");
            int selectedId = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome do Equipamento:\n");
            string name = Console.ReadLine();

            Console.WriteLine("Nome do Fabricante:\n");
            string make = Console.ReadLine();

            Console.WriteLine("Preço de Aquisição:\n");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Data de Fabricação (dd/mm/yyyy):");
            DateTime manufactureDate = DateTime.Parse(Console.ReadLine());

            Item newItem = new Item(name, make, price, manufactureDate);
           
            bool wasEditSucessful = itemRepository.EditItems(selectedId, newItem);
            
            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Um Erro Ocorreu Durante a Edição", ConsoleColor.Red);

                return;
            }

            Notifier.ShowMessage("Item Editado com Sucesso", ConsoleColor.Green);
        }

        public void Delete()
        {
            text.DeleteText();
            Visualize(false);

            Console.WriteLine("\nDigite o ID do Equipamento que deseja Excluir:\n");
            int selectedId = int.Parse(Console.ReadLine());
            bool wasEditSucessful = itemRepository.DeleteItems(selectedId);

            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Um Erro Ocorreu Durante a Edição", ConsoleColor.Red);

                return;
            }

            Notifier.ShowMessage("Item Deletado com Sucesso", ConsoleColor.Green);
        }
    }


}
