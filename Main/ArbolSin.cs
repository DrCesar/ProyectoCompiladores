using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
 
namespace Main
{
    class ArbolSin
    {
        private Nodo raiz;
        private Nodo fin;
        private List<string> alfa;

        public ArbolSin()
        {
            this.raiz = new Nodo();
        }

        public ArbolSin(string s)
        {
            InfixToPostfix ix = new InfixToPostfix(s);
            Stack<Symbol> postfix = ix.getStackPost();
            Stack<Nodo> sNodo = new Stack<Nodo>();
            alfa = new List<string>();
            Nodo temp;
            int cont = 0;

            foreach (Symbol sim in postfix)
            {
                if (sim.isOper())
                    switch (sim.getSym())
                    {
                        case "|":
                            sNodo.Push(new Nodo(sim.getSym(), sNodo.Pop(), sNodo.Pop()));
                            break;
                        case ".":
                            sNodo.Push(new Nodo(sim.getSym(), sNodo.Pop(), sNodo.Pop()));
                            break;
                        case "*":
                            sNodo.Push(new Nodo(sim.getSym(), sNodo.Pop()));
                            break;
                            /*case '+':
                                temp = DeepCopy(sNodo.Peek());
                                sNodo.Push(new Nodo("*", sNodo.Pop()));
                                sNodo.Push(new Nodo(".", temp, sNodo.Pop()));
                                break;*/
                    }
                else
                { 
                    temp = new Nodo(sim.getSym());
                    temp.getFPos().Add(temp);
                    temp.getLPos().Add(temp);
                    if (sim.getSym() == "#")
                        this.fin = temp;
                    else
                    {
                        if (!alfa.Contains(sim.getSym()))
                            alfa.Add(sim.getSym());
                    }
                    cont++;
                    temp.setNum(cont.ToString());
                    sNodo.Push(temp);

                    break;
                }
            }

            this.raiz = sNodo.Pop();
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

        public void setRaiz(Nodo n)
        {
            this.raiz = n;
        }

        public Nodo getRaiz()
        {
            return this.raiz;
        }

        public void setAlfa(List<string> l)
        {
            this.alfa = l;
        }

        public List<string> getAlfa()
        {
            return this.alfa;
        }

        public void setFin(Nodo n)
        {
            this.fin = n;
        }

        public Nodo getFin()
        {
            return this.fin;
        }

        public List<Nodo> getFollowPos(List<Nodo> l, string s)
        {
            List<Nodo> r = new List<Nodo>();

            foreach(var i in l)
            {
                if (i.getInfo() == s)
                    r.AddRange(i.getFolPos());
            }

            return r;
        }
    }
}
