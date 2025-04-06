namespace GestãoDeEquipamentosAP
{
    internal class Program
    {
        

        public static void MainMenu()
        {
            ItemManipulation Item = new ItemManipulation();
            CallSystem Call = new CallSystem();
            Text text = new Text();

            while (true)
            {
                text.MainMenuText();
                string chosenMenuOption = Console.ReadLine().ToUpper();

                switch (chosenMenuOption)
                {
                    case "1":
                        Item.Register();
                        break;

                    case "2":
                        Item.Edit();
                        break;

                    case "3":
                        Item.Delete();
                        break;

                    case "4":
                        Item.Visualize(true);
                        break;

                    case "5":
                        Call.RegisterCall();
                        break;

                    case "6":
                        Call.EditCall();
                        break;
                    
                    case "7":
                        Call.Close();
                        break;
                    
                    case "8":
                        Call.ViewCalls(true);
                        break;


                    case "S":
                        Environment.Exit(0);
                        break;


                    default:
                        Console.WriteLine("Opção Inválida, Pressione Enter para continuar:\n");
                        Console.ReadLine();
                        break;


                }
            }
           
        }
     
        
        static void Main(string[] args)
        {
           MainMenu();
        }
    }
}
