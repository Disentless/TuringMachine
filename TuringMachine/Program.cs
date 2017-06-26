using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    class Program
    {
        struct Inst
        {
            public char t;
            public int q;
            public int move;
            public int new_q;
            public char w;

            public Inst(char _t, char _w, int _q, int _new_q, int _move)
            {
                t = _t;
                q = _q;
                move = _move;
                new_q = _new_q;
                w = _w;
            }
        }

        static void Main(string[] args)
        {
            const int x1 = 7;
            const int x2 = 6;
            var input = new Func<char[]>(() =>
            {
                char[] res = new char[x1 + x2 + 2];
                res[0] = res[res.Length - 1] = ' ';
                //study
                for (int i = 1; i < res.Length - 1; ++i)
                {
                    res[i] = '|';
                }
                //custom
                //res[Math.Max(x1, x2) + 1] = '_';
                //for (int i = 1; i < res.Length - 1; ++i)
                //{
                //    if (res[i] == '_') continue;
                //    res[i] = '|';
                //}
                return res;
            })();
            int s = Math.Max(x1, x2) + 2;
            int q = 1;
            const char e = '\0';
            const char p = ' ';
            const char a = 'a';
            const char b = 'b';
            const char x = 'x';
            List<Inst> list = new List<Inst>();
            List<Inst> list_c = new List<Inst>();
            //1
            list_c.Add(new Inst('|', x, 1, 2, +1));
            list_c.Add(new Inst('|', e, 2, 2, +1));
            list_c.Add(new Inst('|', e, 3, 3, -1));
            //4--

            list_c.Add(new Inst(p, e, 1, 4, -1));
            list_c.Add(new Inst(p, e, 2, 3, -1));
            list_c.Add(new Inst(p, e, 3, 1, +1));
            list_c.Add(new Inst(p, e, 4, 2, -1));

            list_c.Add(new Inst(x, e, 1, 1, +1));
            list_c.Add(new Inst(x, e, 2, 2, +1));
            list_c.Add(new Inst(x, e, 3, 3, -1));
            list_c.Add(new Inst(x, '|', 4, 4, -1));

            list_c.Add(new Inst('_', e, 1, 5, +1));
            list_c.Add(new Inst('_', e, 2, 1, +1));
            list_c.Add(new Inst('_', e, 3, 3, -1));
            list_c.Add(new Inst('_', e, 4, 1, +1));

            //1
            //------------------------------------
            list.Add(new Inst('|', a, 1, 2, +1));
            list.Add(new Inst(a, e, 1, 1, -1));
            list.Add(new Inst(b, e, 1, 1, -1));
            list.Add(new Inst(p, e, 1, 3, +1));
            //2
            //------------------------------------
            list.Add(new Inst('|', b, 2, 1, -1));
            list.Add(new Inst(a, e, 2, 2, +1));
            list.Add(new Inst(b, e, 2, 2, +1));
            list.Add(new Inst(p, e, 2, 4, -1));
            //3
            //------------------------------------
            list.Add(new Inst('|', e, 3, 1, -1));
            list.Add(new Inst(a, p, 3, 3, +1));
            list.Add(new Inst(b, '|', 3, 3, +1));
            list.Add(new Inst(p, e, 3, 5, -1));
            //4
            //------------------------------------
            list.Add(new Inst('|', e, 4, 1, +1));
            list.Add(new Inst(a, '|', 4, 4, -1));
            list.Add(new Inst(b, p, 4, 4, -1));
            list.Add(new Inst(p, e, 4, 1, +1));
            //5
            list_c.Add(new Inst(x, '|', 5, 5, +1));
            list_c.Add(new Inst('|', x, 5, 5, +1));
            list_c.Add(new Inst(p, e, 5, 7, -1));
            //------------------------------------
            list.Add(new Inst('|', p, 5, 6, -1));
            list.Add(new Inst(p, e, 5, 0, 0));
            list.Add(new Inst('0', e, 5, 0, 0));
            list.Add(new Inst('1', e, 5, 0, 0));
            list.Add(new Inst('2', e, 5, 0, 0));
            list.Add(new Inst('3', e, 5, 0, 0));
            list.Add(new Inst('4', e, 5, 0, 0));
            list.Add(new Inst('5', e, 5, 0, 0));
            list.Add(new Inst('6', e, 5, 0, 0));
            list.Add(new Inst('7', e, 5, 0, 0));
            list.Add(new Inst('8', e, 5, 0, 0));
            list.Add(new Inst('9', e, 5, 0, 0));
            //6
            list_c.Add(new Inst(x, e, 6, 6, -1));
            list_c.Add(new Inst('_', '0', 6, 8, +1));
            list_c.Add(new Inst('|', e, 6, 6, -1));
            list_c.Add(new Inst('0', '1', 6, 8, +1));
            list_c.Add(new Inst('1', '2', 6, 8, +1));
            list_c.Add(new Inst('2', '3', 6, 8, +1));
            list_c.Add(new Inst('3', '4', 6, 8, +1));
            list_c.Add(new Inst('4', '5', 6, 8, +1));
            list_c.Add(new Inst('5', '6', 6, 8, +1));
            list_c.Add(new Inst('6', '7', 6, 8, +1));
            list_c.Add(new Inst('7', '8', 6, 8, +1));
            list_c.Add(new Inst('8', '9', 6, 8, +1));
            list_c.Add(new Inst('9', '0', 6, 6, -1));
            //--------------------------------------
            list.Add(new Inst('|', e, 6, 6, -1));
            list.Add(new Inst(p, '1', 6, 7, +1));
            list.Add(new Inst('0', '1', 6, 7, +1));
            list.Add(new Inst('1', '2', 6, 7, +1));
            list.Add(new Inst('2', '3', 6, 7, +1));
            list.Add(new Inst('3', '4', 6, 7, +1));
            list.Add(new Inst('4', '5', 6, 7, +1));
            list.Add(new Inst('5', '6', 6, 7, +1));
            list.Add(new Inst('6', '7', 6, 7, +1));
            list.Add(new Inst('7', '8', 6, 7, +1));
            list.Add(new Inst('8', '9', 6, 7, +1));
            list.Add(new Inst('9', '0', 6, 6, -1));
            //7
            list_c.Add(new Inst('|', p, 7, 6, -1));
            list_c.Add(new Inst(x, p, 7, 7, -1));
            list_c.Add(new Inst('_', p, 7, 5, -1));
            list_c.Add(new Inst(p, e, 7, 0, -1));
            list_c.Add(new Inst('0', e, 7, 7, -1));
            list_c.Add(new Inst('1', e, 7, 7, -1));
            list_c.Add(new Inst('2', e, 7, 7, -1));
            list_c.Add(new Inst('3', e, 7, 7, -1));
            list_c.Add(new Inst('4', e, 7, 7, -1));
            list_c.Add(new Inst('5', e, 7, 7, -1));
            list_c.Add(new Inst('6', e, 7, 7, -1));
            list_c.Add(new Inst('7', e, 7, 7, -1));
            list_c.Add(new Inst('8', e, 7, 7, -1));
            list_c.Add(new Inst('9', e, 7, 7, -1));
            //---------------------------------------
            list.Add(new Inst('|', e, 7, 7, +1));
            list.Add(new Inst(p, e, 7, 5, -1));
            list.Add(new Inst('0', e, 7, 7, +1));
            list.Add(new Inst('1', e, 7, 7, +1));
            list.Add(new Inst('2', e, 7, 7, +1));
            list.Add(new Inst('3', e, 7, 7, +1));
            list.Add(new Inst('4', e, 7, 7, +1));
            list.Add(new Inst('5', e, 7, 7, +1));
            list.Add(new Inst('6', e, 7, 7, +1));
            list.Add(new Inst('7', e, 7, 7, +1));
            list.Add(new Inst('8', e, 7, 7, +1));
            list.Add(new Inst('9', e, 7, 7, +1));
            //8
            list_c.Add(new Inst(p, e, 8, 7, -1));
            list_c.Add(new Inst(x, e, 8, 8, +1));
            list_c.Add(new Inst('_', e, 8, 8, 0));
            list_c.Add(new Inst('|', e, 8, 8, +1));
            list_c.Add(new Inst('0', e, 8, 8, +1));
            list_c.Add(new Inst('1', e, 8, 8, +1));
            list_c.Add(new Inst('2', e, 8, 8, +1));
            list_c.Add(new Inst('3', e, 8, 8, +1));
            list_c.Add(new Inst('4', e, 8, 8, +1));
            list_c.Add(new Inst('5', e, 8, 8, +1));
            list_c.Add(new Inst('6', e, 8, 8, +1));
            list_c.Add(new Inst('7', e, 8, 8, +1));
            list_c.Add(new Inst('8', e, 8, 8, +1));
            list_c.Add(new Inst('9', e, 8, 8, +1));
            while (q != 0)
            {
                foreach (var l in list)
                {
                    if (l.q == q && l.t == input[s])
                    {
                        if (l.w != '\0') input[s] = l.w;
                        q = l.new_q;
                        s += l.move;
                        break;
                    }
                }

                if (q > 0)
                {
                    for (int i = 0; i < s; ++i)
                    {
                        Console.Write(' ');
                    }
                    Console.WriteLine('#');
                    Console.WriteLine(input);
                    Console.WriteLine("s=" + s.ToString() + "   q" + q.ToString());
                    Console.ReadKey(true);
                }
            }
        }
    }
}
