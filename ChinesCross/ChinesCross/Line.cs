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

            else if(lims.Count > 1)
            {
                List<string> zeros = new List<string>();
                SolveWithZeros(ref zeros);
            }

            return result;
        }

        public void SolveWithZeros(ref List<string> zeros)
        {
            int maxZeroValue = length ;
            int fields = lims.Count + 1;

            foreach(Element element in lims)
            {
                maxZeroValue -= element.length;
            }


            double count = Math.Pow(Convert.ToDouble(maxZeroValue + 1), fields);

            for (int i = 0; i < count; i++)
            {
                string num = DecimalToArbitrarySystem(i, maxZeroValue + 1);
                num = num.PadLeft(fields, '0');
                bool print = true;
                int sum = 0;
                for (int j = 0; j < num.Length; j++)
                {
                    int index = Convert.ToInt32(num[j]) - 48;

                    if (j != 0 && j != num.Length - 1)
                    {
                        if (index < 1)
                            print = false;
                    }

                    sum += index;
                }

                if (sum != maxZeroValue)
                    print = false;
                if (print)
                {
                    //for (int j = 0; j < num.Length; j++)
                    //{
                    //    int index = Convert.ToInt32(num[j]) - 48;
                    //    Console.Write(index + " ");//" (" + j + ") ");
                    //}
                    //Console.Write(num);

                    //Console.WriteLine();

                    zeros.Add(num);
                }


            }
        }


        public static string DecimalToArbitrarySystem(long decimalNumber, int radix)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " +
                    Digits.Length.ToString());

            if (decimalNumber == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(decimalNumber);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / radix;
            }

            string result = new String(charArray, index + 1, BitsInLong - index - 1);
            if (decimalNumber < 0)
            {
                result = "-" + result;
            }

            return result;
        }
    }
}
