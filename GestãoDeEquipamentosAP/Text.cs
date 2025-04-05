using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP
{
    public class Text
    {
        public void MainMenuText()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("---------------------------");

            Console.WriteLine("Ações:\n");
            Console.WriteLine("1- Cadastrar um Item");
            Console.WriteLine("2- Editar um Item");
            Console.WriteLine("3- Excluir um Item");
            Console.WriteLine("4- Visualizar todos os Items");
            Console.WriteLine("S- Sair do Programa");

            Console.WriteLine("\nDigite uma opção válida:");
        }

        public void RegisterText()
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("Cadastro de Equipamento");
            Console.WriteLine("--------------------\n");
        }

        public void VisualizerText()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Lista de Items Cadastrados");
            Console.WriteLine("-------------------------\n");
        }

        public void EditorText()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Ediçao de Items");
            Console.WriteLine("-------------------------\n");
        }

        public void DeleteText()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Excluir um Item");
            Console.WriteLine("-------------------------\n");
        }
    
    
    
    }
}
