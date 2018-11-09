using System;
using System.Collections.Generic;
using System.Text;

namespace ChinesCross
{
    class Element
    {
        public List<bool> group = new List<bool>();

        public Element(int x)
        {
            for (int i = 0;  i < x;  i++)
            {
                group.Add(true);
            }
        }
    }
}
