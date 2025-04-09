using GestãoDeEquipamentosAP.MakeModule;
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
        public MakeRepository makeRepository;

        public ItemSystem(ItemRepository itemRepository, MakeRepository makeRepository)
        {
            this.itemRepository = itemRepository;
            this.makeRepository = makeRepository;
        }


        public void Register()
        {
            Item newItem = GetItemData();

            Make make = newItem.Make;

            make.AddItem(newItem);

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

            Item oldItem = itemRepository.GetItemById(selectedId);
            Make oldMake = oldItem.Make;
            
            Console.WriteLine();

            Item editedItem = GetItemData();
            Make editedMake = oldItem.Make;
           
            bool wasEditSucessful = itemRepository.EditItems(selectedId, newItem);
            
            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Um Erro Ocorreu Durante a Edição", ConsoleColor.Red);

                return;
            }
            if (oldMake != editedMake)
            {
                oldMake.DeleteItem(oldItem);
                editedMake.AddItem(editedItem);
            }

            Notifier.ShowMessage("Item Editado com Sucesso", ConsoleColor.Green);
        }

        public void Delete()
        {
            text.DeleteText();
            Visualize(false);

            Console.WriteLine("\nDigite o ID do Equipamento que deseja Excluir:\n");
            int selectedId = int.Parse(Console.ReadLine());

            Item selectedItem = itemRepository.GetItemById(selectedId);
            bool wasEditSucessful = itemRepository.DeleteItems(selectedId);

            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Um Erro Ocorreu Durante a Edição", ConsoleColor.Red);

                return;
            }

            Make selectedMake = selectedItem.Make;
            selectedMake.DeleteItem(selectedItem);

            Notifier.ShowMessage("Item Deletado com Sucesso", ConsoleColor.Green);
        }
    }


}
