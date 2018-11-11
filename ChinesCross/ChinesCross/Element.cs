using System;
using System.Collections.Generic;
using System.Text;

namespace ChinesCross
{
    class Element
    {
        public int length;

        public List<bool> group = new List<bool>();
        //public int length { get { return length; } }

        public Element(int x , bool value)
        {
            length = x;
            for (int i = 0;  i < x;  i++)
            {
                group.Add(value);
            }
        }

        public void Draw()
        {
            foreach (bool b in group)
            {
                if (b) Console.Write("O");
                else Console.Write("X");
            }
        }
    }
}
