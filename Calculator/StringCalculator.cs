using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class StringCalculator
    {
        public static int add(string number)
        {
            if (number == "") return 0;
            int ans = 0;
            String[] array;
            char[] r=new char[3];
            if (number.Length > 2 && number.StartsWith("//"))
            {
                r[0] = number[2];
                r[1] = '\n';
                r[2] = '/';
            }
            else
            {
                r[0] = ',';
                r[1] = '\n';
            }
            array = number.Split(r, StringSplitOptions.RemoveEmptyEntries);
            string mess="negatives not allowed: ";
            for (int i = 0; i < array.Length; i++)if(int.Parse(array[i])<0)
            {
                mess += int.Parse(array[i]) + " ";
            }
            if (mess != "negatives not allowed: ")
            {
                throw new Exception(mess);
                //throw new System.ArgumentOutOfRangeException(mess);
            }
            for (int i = 0; i < array.Length; i++) if (int.Parse(array[i]) <= 1000)
            {
                ans += int.Parse(array[i]);
            }
            return ans;
        }
    }
}
