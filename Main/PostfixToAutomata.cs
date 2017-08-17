using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Main
{

    internal class PostfixToAutomata
    {
        private string postfix;
        private Stack<Automata> autoFinal;
        private Automata auto;
        private Operaciones oper;

        public PostfixToAutomata(string p)
        {
            this.postfix = p;
            this.autoFinal = new Stack<Automata>();
            this.oper = new Operaciones();
        }

        public void conAutomata()
        {
            Automata temp;
            Automata temp2;

            for(int i = 0; i< postfix.Length; i++)
            {

                switch (postfix[i])
                {
                    case '.':
                        temp2 = this.autoFinal.Pop();
                        temp = this.autoFinal.Pop();
                        this.autoFinal.Push(oper.multiplicacion(temp, temp2));
                        break;
                    case '|':
                        temp2 = this.autoFinal.Pop();
                        temp = this.autoFinal.Pop();
                        this.autoFinal.Push(oper.adicion(temp, temp2));
                        break;
                    case '*':
                        temp = this.autoFinal.Pop();
                        this.autoFinal.Push(oper.kleene(temp));
                        break;
                    case '+':
                        temp = DeepCopy(this.autoFinal.Peek());
                        this.autoFinal.Push(oper.kleene(this.autoFinal.Pop()));
                        this.autoFinal.Push(oper.multiplicacion(temp, this.autoFinal.Pop()));
                        break;
                    default:
                        temp = new Automata(postfix[i].ToString());
                        autoFinal.Push(temp);
                        break;

                }
            }

            auto = autoFinal.Pop();
            auto.numEstados();
        }


        /*Codigo Sacado de Internet.
         * Autor: Farhad Jabiyev
         * Fuente:https://stackoverflow.com/questions/16696448/how-to-make-a-copy-of-an-object-in-c-sharp/16696564#16696564 */
        public static T DeepCopy<T>(T other)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, other);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }

        public Automata getAuto()
        {
            return this.auto;
        }

    }
}
