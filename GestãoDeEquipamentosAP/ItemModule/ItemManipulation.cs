using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.ItemModule
{
    public class ItemManipulation
    {
        public static Item[] Items = new Item[100];
        public int amountOfItems;

        Text text = new Text();

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
            newItem.Id = IdGenerator.GenerateId();

            Items[amountOfItems++] = newItem;
        }


        public void Visualize(bool showTitle)
        {
            
            if (showTitle)
            {
                text.VisualizerText();
            }

            Console.WriteLine("{0, -10} | {1, -18} | {2, -11} | {3, -15} | {4, -18} | {5, -10}", "ID", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação");

            for (int i = 0; i < Items.Length; i++)
            {
                Item selectedItem = Items[i];

                if (selectedItem == null) continue;

                Console.WriteLine("{0, -10} | {1, -18} | {2, -11} | {3, -15} | {4, -18} | {5, -10}", selectedItem.Id, selectedItem.Name, selectedItem.GetSerialNumber(), selectedItem.Make, selectedItem.Price.ToString("C2"), selectedItem.ManufactureDate.ToShortDateString());
            }
            Console.WriteLine("\nPressione Enter para Continuar:\n\n");
            Console.ReadLine();
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
            bool wasEditSucessful = false;
            
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == null) continue;

                else if (Items[i].Id == selectedId)
                {
                    Items[i].Name = newItem.Name;
                    Items[i].Make = newItem.Make;
                    Items[i].Price = newItem.Price;
                    Items[i].ManufactureDate = newItem.ManufactureDate;
                }
            }
            if (!wasEditSucessful)
            {
                Console.WriteLine("Erro na edição...");
                return;
            }
            Console.WriteLine("Item Editado com Sucesso.");
            Console.ReadLine();
        }

        public void Delete()
        {
            text.DeleteText();
            Visualize(false);

            Console.WriteLine("\nDigite o ID do Equipamento que deseja Excluir:\n");
            int selectedId = int.Parse(Console.ReadLine());
            bool wasEditSucessful = false;

            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == null) continue;

                else if (Items[i].Id == selectedId)
                {
                    Items[i] = null;
                    wasEditSucessful = true;
                }
            }
            if (!wasEditSucessful)
            {
                Console.WriteLine("Erro na edição...");
                return;
            }
            Console.WriteLine("Item Editado com Sucesso.");
            Console.ReadLine();
        }
    }


}
