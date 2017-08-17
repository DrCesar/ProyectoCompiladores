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
        private Stack<string> stackPost = new Stack<string>();
        private Stack<string> op = new Stack<string>();
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
                case "+":
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
            s = s.ToLower();

            while (i < s.Length)
            {
                switch (s[i])
                {
                    case '(':
                        if (ts)
                            signo(".");
                        op.Push("(");
                        break;
                    case ')':
                        while (op.Count != 0 && op.Peek() != "(")
                            stackPost.Push(op.Pop());
                        if (op.Count != 0)
                            op.Pop();
                        break;
                    case '|':
                    case '*':
                    case '.':
                    case '+':
                        signo(s[i].ToString());
                        break;
                    case '?':
                        signo("|");
                        op.Push("@");
                        break;
                    default:
                        {
                            if (ts)
                            {
                                signo(".");
                            }
                            stackPost.Push(s[i].ToString());
                            ts = true;
                        }
                        break;
                }
                i++;

            }

            while (op.Count > 0)
            {
                stackPost.Push(op.Pop());
            }

            postfix = "";

            while(stackPost.Count > 0)
            {
                postfix = stackPost.Pop() + postfix;
            }
        }

        public void preSigno(string c)
        {
            if (ts)
            {
                signo("*");
            }
            signo(c);
        }

        public void signo(string c)
        {
            while (op.Count != 0 && jer(c) <= jer(op.Peek()))
            {
                stackPost.Push(op.Pop());
            }
            if (c == "*" || c == "+")
            {
                stackPost.Push(c);
                ts = true;
            }
            else
            {
                op.Push(c);
                ts = false;
            }
        }





        public string toString()
        {
            Stack<string> temp = this.stackPost;
            string res = "";

            while(temp.Count > 0)
            {
                res = temp.Pop() + res;
            }

            return res;
        }

        public Stack<string> getStackPost()
        {
            return this.stackPost;
        }

        public string getPostfix()
        {
            return this.postfix;
        }

    }
}

