using System;
using System.Collections.Generic;
using System.Text;

namespace ChinesCross
{
    class Element
    {
        public List<bool> group = new List<bool>();

        public Element(int x , bool value)
        {
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
