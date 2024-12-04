namespace TechTalk.UpdatedP4CS.Apps
{
    using System;
    using System.Linq;
    using TechTalk.UpdatedP4CS.Interfaces;

    public class CaesarCipher : IApp
    {
        private readonly bool encrypting;

        public CaesarCipher(bool encrypting)
        {
            this.encrypting = encrypting;
        }

        public void Run()
        {
            Console.WriteLine(this.encrypting ? "\nEncrypt Text\n------------" : "\nDecrypt Text\n------------");

            Console.Write("Enter the text: ");
            string input = Console.ReadLine().ToUpper();

            int shift = (int)new SquareRootCalculator().GetValidInput("Enter shift key (0-25): ", x => x >= 0 && x <= 25);
            shift = this.encrypting ? shift : -shift;

            string result = this.CaesarShift(input, shift);
            Console.WriteLine($"Result: {result}");
        }

        private string CaesarShift(string input, int shift)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char ShiftChar(char c)
            {
                int index = alphabet.IndexOf(c);
                
                if (index < 0) 
                    return c; // Non-alphabetic character
                
                int shiftedIndex = (index + shift + 26) % 26;
                
                return alphabet[shiftedIndex];
            }

            return string.Concat(input.ToUpper().Select(ShiftChar));
        }
    }
}
