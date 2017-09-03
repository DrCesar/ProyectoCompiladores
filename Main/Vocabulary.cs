using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Vocabulary
    {
        private const string letterFormat = "[a-z]" + "[A-Z]";
        private const string digitFormat = "0123456789";
        private const string identFormat = letterFormat + "{" + letterFormat + "|" + digitFormat + "}";
        private const string numberFormat = digitFormat + "{" + digitFormat + "}";
        private const string charFormat = cFormat + "|CHR(" + numberFormat + ")";
        private const string anyFormat = "[@N&]";
        private const string stringFormat = "\"{[@N&S]}\"";
        private const string cFormat = "'[@N&C]'";
        private const string basicSetFormat = stringFormat + "|" + identFormat + "|" + cFormat;
        private const string setFormat = basicSetFormat + "{(+|-)" + basicSetFormat + "}";
        private const string setDeclFormat = identFormat + "=" + setFormat + ".";
        private const string keywordDeclFormat = identFormat + "=" + stringFormat + ".";
        private const string charatersFormat = "[ CHARACTERS {" + setDeclFormat + "}]";
        private const string keywordFormat = "[ KEYWORDS {" + keywordDeclFormat + "}]";
        private const string whiteSpaceFormat = "{ IGNORE " + setFormat + ".}";
        private const string scannerSpecificationFormat = charatersFormat + keywordFormat + whiteSpaceFormat;
        private const string cocolFormat = "COMPILER" + identFormat + scannerSpecificationFormat + "END" + identFormat + ".";


        /*AutomataD letter;
        AutomataD digit;
        AutomataD ident;
        AutomataD number;
        AutomataD charA;
        AutomataD stringA;
        AutomataD set;
        AutomataD basicSet;*/
        AutomataD setDecl;
        AutomataD keywordDecl;
        private AutomataD cocolA;

        public Vocabulary()
        {
            /*letter = createAutomata(letterFormat);
            digit = createAutomata(digitFormat);
            ident = createAutomata(identFormat);
            number = createAutomata(numberFormat);
            stringA = createAutomata(stringFormat);
            charA = createAutomata(charFormat);
            set = createAutomata(setFormat);
            setDecl = createAutomata(setDeclFormat);
            keywordDecl = createAutomata(keywordDeclFormat);*/
            this.cocolA = createAutomata(cocolFormat);
        }

       

        public AutomataD createAutomata(string s)
        {

            InfixToPostfix ix = new InfixToPostfix(s);
            ArbolSin ar = new ArbolSin(s);
            Converter con = new Converter();

            return con.DirectAFD(ar);

        }

        public void Simulate(string s)
        {
            //Console.WriteLine(cocolA.GetEstados());
            if (!s.Contains("CHARACTERS"))
                Console.WriteLine("No contiene el identificador COMPILER");
            else
                if (!s.Contains("CHARACTERS"))
                    Console.WriteLine("No contiene el identificador CHARACTERS");
                else
                    if (!s.Contains("KEYWORDS"))
                        Console.WriteLine("No contiene el identificador KEYWORD");
                    else
                        if (!s.Contains("END"))
                            Console.WriteLine("No contiene el identificador END");
                        else
                            this.cocolA.simularD(s);
        }

        public AutomataD GetCocolA()
        {
            return this.cocolA;
        }

    }
}
