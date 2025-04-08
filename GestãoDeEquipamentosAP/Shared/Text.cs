using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.Shared
{
    public class Text
    {
        public void MainMenuText()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Central de Gestão");
            Console.WriteLine("---------------------------");

            Console.WriteLine("Ações:\n");
            Console.WriteLine("1.Gestão de Equipamentos");
            Console.WriteLine("2.Gestão de Chamados");
            Console.WriteLine("\nS- Sair do Programa");

            Console.WriteLine("\nDigite uma opção válida:");
        }



        public void ItemMenuText()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("---------------------------");

            Console.WriteLine("Ações:\n");
            Console.WriteLine("1- Cadastrar um Item");
            Console.WriteLine("2- Editar um Item");
            Console.WriteLine("3- Excluir um Item");
            Console.WriteLine("4- Visualizar todos os Items\n");
            Console.WriteLine("\nS- Voltar");

            Console.WriteLine("\nDigite uma opção válida:");
        }
        
        public void CallMenuText()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Ações:\n");
            Console.WriteLine("1- Cadastrar um novo Chamado");
            Console.WriteLine("2- Editar um Chamado");
            Console.WriteLine("3- Fechar um Chamado");
            Console.WriteLine("4- Visualizar todos os Chamados");
            Console.WriteLine("\nS- Voltar");

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

        

        public void CallRegisterText()
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("Cadastrar Nova Chamada");
            Console.WriteLine("--------------------\n");
        }


        public void CallVisualizerText()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Lista de Chamadas Abertas:");
            Console.WriteLine("-------------------------\n");
        }

        public void CallEditorText()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Ediçao de Chamados");
            Console.WriteLine("-------------------------\n");
        }

        public void CloseCallText()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Fechar um Chamado");
            Console.WriteLine("-------------------------\n");
        }
    }
}
