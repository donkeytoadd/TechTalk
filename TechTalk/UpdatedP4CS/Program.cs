namespace TechTalk.UpdatedP4CS
{
    using System.Collections.Generic;
    using TechTalk.UpdatedP4CS.Apps;
    using TechTalk.UpdatedP4CS.Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            var apps = new Dictionary<int, IApp>
            {
                { 1, new CountingGame() },
                { 2, new SquareRootCalculator() },
                { 3, new CaesarCipher(true) },  // Encrypt
                { 4, new CaesarCipher(false) }, // Decrypt
            };

            var menu = new Menu(apps);
            menu.Display();
        }
    }
}
