using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 

namespace Main
{
    internal class InfixToPostfix
    {
        private String infix;
        private Stack<Symbol> temp = new Stack<Symbol>();
        private Stack<Symbol> stackPost = new Stack<Symbol>();
        private Stack<Symbol> op = new Stack<Symbol>();
        private string postfix;
        private bool ts;

        public InfixToPostfix(String s)
        {
            this.infix = s;

            convert();
        }

        public int jer(string c)
        {
            switch (c)
            {
                case "(":
                    {
                        return 0;
                    }
                case "*":
                    {
                        return 3;
                    }
                case ".":
                    {
                        return 2;
                    }
                case "|":
                    {
                        return 1;
                    }
            }

            return -1;
        }

        public void convert()
        {
            string s = this.infix;
            int i = 0;

            while (i < this.infix.Length)
            {
                switch (this.infix[i])
                {
                    case '{':                      
                    case '(':
                        if (ts)
                            signo(".");
                        op.Push(new Symbol("(",true));
                        break;
                    case ')':
                        while (op.Count != 0 && op.Peek().getSym() != "(")
                            temp.Push(op.Pop());
                        if (op.Count != 0)
                            op.Pop();
                        break;
                    case ']':
                    case '}':
                        while (op.Count != 0 && op.Peek().getSym() != "(")
                            temp.Push(op.Pop());
                        if (op.Count != 0)
                            op.Pop();
                        op.Push(new Symbol("*",true));
                        break;
                    case '|':
                        signo(this.infix[i].ToString());
                        break;
                    case '[':
                        if (s[i + 1] == '@' && s[i + 2] == 'N' && s[i + 3] == '&')
                        {
                            for (int j = 0; j < 256; j++)
                            {
                                char c = (char)j;
                                if (s[i + 4] == 'S' && c != '"')
                                    temp.Push(new Symbol(c.ToString(), false));
                                if (s[i + 4] == 'C' && c != '\'')
                                    temp.Push(new Symbol(c.ToString(), false));
                                if (j < 255)
                                    signo("|");
                            }
                            i = i + 5;
                        }
                        else
                        {
                            if (ts)
                                signo(".");
                            op.Push(new Symbol("(", true));
                            break;
                        }
                        break;
                    case ' ':
                        break;
                    default:
                        {
                            if (ts)
                            {
                                signo("|");
                            }
                            temp.Push(new Symbol(this.infix[i].ToString(), false));
                            ts = true;
                        }
                        break;
                }
                i++;

            }

            while (op.Count > 0)
            {
                temp.Push(op.Pop());
            }

            postfix = "";

            while(temp.Count > 0)
            {
                stackPost.Push(temp.Pop());
            }
        }

        public void signo(string c)
        {
            while (op.Count != 0 && jer(c) <= jer(op.Peek().getSym()))
            {
                temp.Push(op.Pop());
            }
            if (c == "*" || c == "+")
            {
                temp.Push(new Symbol(c,true));
                ts = true;
            }
            else
            {
                op.Push(new Symbol(c,true));
                ts = false;
            }
        }





        public string toString()
        {
            Stack<Symbol> temp = this.stackPost;
            string res = "";

            while(temp.Count > 0)
            {
                res = res + temp.Pop().getSym();
            }

            return res;
        }

        public Stack<Symbol> getStackPost()
        {
            return this.stackPost;
        }

        public string getPostfix()
        {
            return this.postfix;
        }

    }
}

