using GestãoDeEquipamentosAP.CallModule;
using GestãoDeEquipamentosAP.ItemModule;
using GestãoDeEquipamentosAP.Shared;

namespace GestãoDeEquipamentosAP
{
    internal class Program
    {
        

        public static void MainMenu()
        {
            ItemSystem itemSystem = new ItemSystem();
            ItemRepository itemRepository = itemSystem.itemRepository;
            CallSystem Call = new CallSystem(itemRepository);
            MainScreen mainScreen = new MainScreen();
            Text text = new Text();



            while (true)
            {
                char menuOption = mainScreen.ShowMenu();

                if (menuOption == '1')
                {
                    text.ItemMenuText();
                    char option = Console.ReadLine()[0];

                    switch (option)
                    {
                        case '1': itemSystem.Register(); break;

                        case '2': itemSystem.Edit(); break;

                        case '3': itemSystem.Delete(); break;

                        case '4': itemSystem.Visualize(true); break;

                        case 'S': Environment.Exit(0); break;

                        default: break;
                    }
                } else if (menuOption == '2')
                {
                    text.CallMenuText();
                    char option = Console.ReadLine()[0];
                    switch (option)
                    {
                        case '1': Call.RegisterCall(); break;

                        case '2': Call.EditCall(); break;

                        case '3': Call.Close(); break;

                        case '4': Call.ViewCalls(true); break;

                        case 'S': Environment.Exit(0); break;


                        default: break;
                    }
                }
                else
                {
                    Environment.Exit(0);
                }

                
            }
           
        }
     
        
        static void Main(string[] args)
        {
           MainMenu();
        }
    }
}
