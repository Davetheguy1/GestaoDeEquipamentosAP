using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.MakeModule
{
    public class MakeSystem
    {
        public MakeRepository makeRepository;
        Text text = new Text();

        public MakeSystem(MakeRepository makeRepository)
        {
            this.makeRepository = makeRepository;
        }


        public void RegisterMake()
        {
            text.MakeRegisterText();

            Make newMake = GetMakeData();

            makeRepository.RegisterMake(newMake);

            Notifier.ShowMessage("O Registro foi Efetuado com Sucesso.", ConsoleColor.Green);
        }

        public void EditMake()
        {
            text.MakeEditorText();
            
            VisualizeMakes(false);

            Console.WriteLine("Digite o Id do fabricante a ser editado.");
            int selectedId = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Make editedMake = GetMakeData();

            bool wasEditSucessful = makeRepository.EditMake(selectedId, editedMake);

            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Ocorreu um Erro durante a Edição", ConsoleColor.Red);
                return;
            }
            Notifier.ShowMessage("Item Editado com Sucesso", ConsoleColor.Green);

        }
        public void DeleteMake()
        {
            text.MakeDeleteText();
            Console.WriteLine();
            VisualizeMakes(false);

            Console.WriteLine("Digite o Id do Fabricante que deseja selecionar:");
            int selectedId = int.Parse(Console.ReadLine());


            bool wasEditSucessful = makeRepository.DeleteMake(selectedId);

            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Ocorreu um Erro durante a Edição", ConsoleColor.Red);
                return;
            }

            Notifier.ShowMessage("Item Editado com Sucesso", ConsoleColor.Green);
        }

        public void VisualizeMakes(bool showTitle)
        {
            if (showTitle)
            {
                text.MakeVisualizerText();
            }
            Console.WriteLine();
            Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}",
            "Id", "Nome", "Email", "Telefone", "Qtd. Equipamentos"
        );

            Make[] registeredMakes = makeRepository.SelectMakes();

            for (int i = 0; i < registeredMakes.Length; i++)
            {
                Make m = registeredMakes[i];

                if (m == null) continue;

                Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}",
                m.Id, m.Name, m.Email, m.Telephone, m.AmountOfItemsInMake()
            );
            }
            Console.WriteLine();
            Notifier.ShowMessage("Pressione Enter para Continuar...", ConsoleColor.DarkYellow);
        }

        public Make GetMakeData()
        {
            Console.WriteLine("Digite o Nome do Fabricante:");
            string name = Console.ReadLine();

            Console.WriteLine("Digite o Endereço de Email do Fabricante:");
            string email = Console.ReadLine();

            Console.WriteLine("Digite o Telefone do Fabricante:");
            string telephone = Console.ReadLine();

            Make make = new Make(name, email, telephone);

            return make;

            
        }
    }
}
