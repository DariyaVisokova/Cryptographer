using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptographer
{
    public class EncoderVigener 
    {
        public static string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public const int ruAlphLength = 33;


        public static char TakeSymvFromIndex(int index)
        {
            char symv = alphabet[index - 1];
            return symv;
        }
        public static int TakeIndexFromSymv(char symv)
        {
            int numString = alphabet.IndexOf(symv) + 1;
            return numString;
        }
        public static int EncrChangPos(char text, char key)
        {

            int indexPos = (TakeIndexFromSymv(text) + TakeIndexFromSymv(key) - 1) % ruAlphLength;
            if (indexPos == 0)
            {
                indexPos = ruAlphLength;
            }
            return indexPos;
        }
        public static int DecrChangPos(char text, char key)
        {

            int indexPos = (TakeIndexFromSymv(text) - TakeIndexFromSymv(key) + 67) % ruAlphLength;
            if (indexPos == 0)
            {
                indexPos = ruAlphLength;
            }
            return indexPos;
        }

        public static string Encode(string input, string keyword)
        {
            string result = "";
            int counter = 0;
            int index = 0;


            for (int i = 0; i < input.Length; i++)
            {
                if (alphabet.Contains(input[i]))
                {
                    if (TakeIndexFromSymv(input[i]) <= ruAlphLength)
                    {
                        index = EncrChangPos(input[i], keyword[counter]);
                        result += TakeSymvFromIndex(index);
                    }
                    else
                    {
                        index = EncrChangPos(input[i], keyword[counter]);
                        index += ruAlphLength;
                        result += TakeSymvFromIndex(index);
                    }
                    counter++;
                }
                else
                {
                    result += input[i];
                }
                if (counter == keyword.Length)
                {
                    counter = 0;
                }
            }
            return result;
        }
        public static string Decode(string input, string keyword)
        {
            string result = "";
            int count = 0;
            int index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (alphabet.Contains(input[i]))
                {
                    if (TakeIndexFromSymv(input[i]) <= ruAlphLength)
                    {
                        index = DecrChangPos(input[i], keyword[count]);
                        result += TakeSymvFromIndex(index);
                    }
                    else
                    {
                        index = DecrChangPos(input[i], keyword[count]);
                        index += ruAlphLength;
                        result += TakeSymvFromIndex(index);
                    }
                    count++;
                }
                else
                {
                    result += input[i];
                }
                if (count == keyword.Length)
                {
                    count = 0;
                }
            }
            return result;
        }

    }
    
}
