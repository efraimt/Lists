using System;

namespace Extensions
{

    static class StringExtensions
    {
        public static bool IsName(this string s)
        {
            foreach (var ch in s)
            {
                if (ch < '9' && ch >= '0') return false;
            }
            return true;
        }

        public static bool HasChar(this string s, char ch1)
        {
            foreach (var ch in s)
            {
                if (ch == ch1) return true;
            }
            return false;
        }
    }


    class Program
    {



        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var firstName = "yakir";

            //if (!IsName(firstName))
            //    Console.WriteLine("Al Taavod Ali!!!!");



            if (!firstName.IsName())
                Console.WriteLine("");


            var b1 = StringExtensions.HasChar(firstName, 'u');
            b1=firstName.HasChar('u');




        }
    }
}
