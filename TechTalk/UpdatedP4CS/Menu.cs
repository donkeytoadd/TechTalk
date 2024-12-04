namespace TechTalk.UpdatedP4CS
{
    using System;
    using System.Collections.Generic;
    using TechTalk.UpdatedP4CS.Interfaces;

    public class Menu
    {
        private readonly Dictionary<int, IApp> apps;

        public Menu(Dictionary<int, IApp> apps)
        {
            this.apps = apps;
        }

        public void Display()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nP4CS Mini Applications");
                Console.WriteLine("----------------------");
                Console.WriteLine("1) Keep Counting");
                Console.WriteLine("2) Square Root Calculator");
                Console.WriteLine("3) Encrypt Text (Caesar Cipher)");
                Console.WriteLine("4) Decrypt Text (Caesar Cipher)");
                Console.WriteLine("9) Quit");
                Console.Write("\nPlease select an option: ");

                bool validInput = int.TryParse(Console.ReadLine(), out int choice);

                if (!validInput || (choice != 9 && !this.apps.ContainsKey(choice)))
                {
                    Console.WriteLine("Invalid option, please try again.");
                    continue;
                }

                if (choice == 9)
                {
                    running = false;
                    Console.WriteLine("Goodbye!");
                }
                
                else
                {
                    this.apps[choice].Run();
                }
            }
        }
    }
}
