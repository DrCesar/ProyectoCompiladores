using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {

        
        static void Main(string[] args)
        {
            string line;
            string text = "";
            Vocabulary vocab = new Vocabulary();
            /*InfixToPostfix fix;
            PostfixToAutomata i;
            string input;
            Converter c = new Converter();
            AutomataD afd;
            AutomataD afd2;
            ArbolSin arb = new ArbolSin();
            string regex;

            Console.WriteLine("Ingrese la expresion regular. Epsilon es @.");

            input = Console.ReadLine();
            
            fix = new InfixToPostfix(input);
            Console.WriteLine(fix.getPostfix());
            i = new PostfixToAutomata(fix.getPostfix());
            i.conAutomata();


            Console.WriteLine("El AFN es:");
            i.getAuto().printEstados();
            i.getAuto().toString();

            Console.WriteLine("El AFD es:");
            afd = c.AfnToAfd(i.getAuto());
            afd.toString();

            fix = new InfixToPostfix(input + "#");
            arb = new ArbolSin(fix.getPostfix());
            Console.WriteLine("El AFD es:");
            afd2 = c.DirectAFD(arb);
            afd2.toString();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Ingrese un regex a simular");
                regex = Console.ReadLine();
                i.getAuto().simular(regex);
                afd2.simular(regex);
            }*/

            System.IO.StreamReader file = new System.IO.StreamReader("test.txt");
            while ((line = file.ReadLine()) != null)
            {
                text = text + line;
            }
            file.Close();

            text = text.Replace(" ", "");
            vocab.Simulate(text);

            Console.ReadLine();

        }
    }
}
