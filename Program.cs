using System;
using System.Collections.Generic;
using System.Linq;

namespace IS_LAB1
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Примеры использования функций
            string inputText1 = "ЕЖИК";
            string inputText2 = "В_ТУМАНЕ";

            string resultAdd = AddTxt(inputText1, inputText2);
            Console.WriteLine($"Сложение: {resultAdd}");

            string resultSub = SubTxt("БАРОН", "ВАРАН");
            Console.WriteLine($"Вычитание: {resultSub}");

            char sym = 'Д';
            Console.WriteLine(Sym2Num(sym));

            int num = 12;
            Console.WriteLine(Num2Sym(num));

            string str = "ОЛВАОКУ";
            int[] arr = new int[6];
            arr = Text2Array(str);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
            int[] myArray = new int[6] { 0, 2, 3, 4, 5, 6 };
            Console.WriteLine(Array2Text(myArray));

            char sym1 = 'Р';
            char sym2 = 'В';
            Console.WriteLine(AddS(sym1, sym2));
            Console.WriteLine(SubS(sym1, sym2));
        }

        //Символ в число
        public static int Sym2Num(char sym)
        {
            int tmp = (int)sym;
            if (tmp != 95) // ASCII для символа '_' 
            {
                return tmp - 1039 - (tmp > 1066 ? 1 : 0);
            }
            return 0; // Для пробела 
        }

        //Число в символ
        public static char Num2Sym(int num)
        {
            if (num != 0)
            {
                int tmp = num + 1039 + (num > 26 ? 1 : 0);
                return (char)tmp;
            }
            return '_';
        }

        //Текст в массив
        public static int[] Text2Array(string input)
        {
            int[] output = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = Sym2Num(input[i]);
            }
            return output;
        }

        //Массив в текст
        public static string Array2Text(int[] arr)
        {
            string output = "";
            foreach (int num in arr)
            {
                output += Num2Sym(num);
            }
            return output;
        }

        //Сложение символов
        public static char AddS(char s1, char s2)
        {
            int tmp = Sym2Num(s1) + Sym2Num(s2);
            return Num2Sym(tmp % 32);
        }

        //Вычитание символов
        public static char SubS(char s1, char s2)
        {
            int tmp = Sym2Num(s1) - Sym2Num(s2) + 32;
            return Num2Sym(tmp % 32);
        }

        //Сложение текстов
        public static string AddTxt(string T1_IN, string T2_IN)
        {
            string output = "";
            int m = Math.Min(T1_IN.Length, T2_IN.Length);
            string longerText = T1_IN.Length > T2_IN.Length ? T1_IN : T2_IN;

            for (int i = 0; i < m; i++)
            {
                output += AddS(T1_IN[i], T2_IN[i]);
            }

            if (longerText.Length > m)
            {
                output += longerText.Substring(m);
            }

            return output;
        }

        //Вычитание текстов
        public static string SubTxt(string T1_IN, string T2_IN)
        {
            string output = "";
            int m = Math.Min(T1_IN.Length, T2_IN.Length);
            string longerText = T1_IN.Length > T2_IN.Length ? T1_IN : T2_IN;
            bool isFirstLonger = T1_IN.Length > T2_IN.Length;

            for (int i = 0; i < m; i++)
            {
                output += SubS(T1_IN[i], T2_IN[i]);
            }

            if (longerText.Length > m)
            {
                for (int i = m; i < longerText.Length; i++)
                {
                    char t = longerText[i];
                    output += isFirstLonger ? SubS(t, '_') : SubS('_', t);
                }
            }

            return output;
        }
    }
}