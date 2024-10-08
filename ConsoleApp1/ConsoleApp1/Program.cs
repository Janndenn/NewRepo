using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("add kha");
            char a = (char)Console.Read();
            if (char.IsUpper(a))
            {
                Console.WriteLine("To yai");
            }
             else if (char.IsLower(a))  
            {
                Console.WriteLine("To noy");
            }
            else if (char.IsDigit(a))
            {
                Console.WriteLine("To lex");
            }
          else if (char.IsSeparator(a))
            {
                Console.WriteLine("San ya luk");
            }
            else if (char.IsPunctuation(a))
            { 
                Console.WriteLine("San ya luk2");
            }
            else if (char.IsSymbol(a))
            {
                Console.WriteLine("San ya luk3");
            }
            else if (char.IsLetter(a))
            {
                Console.WriteLine("San ya luk4");
            }
            else if (char.IsLetter(a))
            {
                Console.WriteLine("San ya luk5");
            }
            Console.ReadLine();
        }    
    }
}
