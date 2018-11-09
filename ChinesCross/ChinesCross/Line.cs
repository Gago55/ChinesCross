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

        public void Solve()
        {
            List<bool> result = new List<bool>();
            List<List<bool>> permutations = new List<List<bool>>();

            for (int i = 0; i < length; i++)
            {
                result.Add(false);
            }

            if(lims.Count==1)
            {
                Element num = lims[0];

                for (int i = 0; i <= length - num.group.Count; i++)
                {
                    List<bool> perm = new List<bool>();
                    for (int k = 0; k < length; k++)
                    {
                        perm.Add(false);
                    }
                    for (int j = i; j < num.group.Count + i; j++)
                    {
                        perm[j] = true;
                    }
                    permutations.Add(perm);
                }


                List<bool> middleResult = new List<bool>();
                
                for (int i = 0; i < length; i++)
                {
                    middleResult.Add(true);
                }

                foreach (List<bool> perm in permutations)
                {
                    for (int i = 0; i < length; i++)
                    {
                        middleResult[i] = middleResult[i] & perm[i];
                    }
                }

                result = middleResult;
            }
        }
    }
}
