using System;
using System.Collections.Generic;
using System.Text;

namespace ChinesCross
{
    class Line
    {
        public int length;
        public List<Element> lims;

        public Line(int x , List<Element> nums)
        {
            length = x;
            lims = nums;
        }

        public Element Solve()
        {
            Element result = new Element(length , false);
            List<List<bool>> permutations = new List<List<bool>>();


            if(lims.Count==1)
            {
                Element num = lims[0];

                for (int i = 0; i <= length - num.group.Count; i++)
                {
                    Element perm = new Element(length , false);
                    
                    for (int j = i; j < num.group.Count + i; j++)
                    {
                        perm.group[j] = true;
                    }
                    permutations.Add(perm.group);
                }


                Element middleResult = new Element(length , true);
                
                foreach (List<bool> perm in permutations)
                {
                    for (int i = 0; i < length; i++)
                    {
                        middleResult.group[i] = middleResult.group[i] & perm[i];
                    }
                }

                result = middleResult;
                
            }

            return result;
        }
    }
}
