using System;
using Raylib;
using static Raylib.Raylib;

namespace LD44
{
    public class Util
    {
        public Util()
        {
        }

        public static Raylib.Color[] colors = { GetColor(0x004d80) };

        public static void ProcessCSVTrixelArray(string array, int width, int height, ref TrixelGrid trixelGrid)
        {
            string[] csvColors = array.Split(',');
            Console.WriteLine("split array");
            int x = 0;
            int y = 0;
            for (int i = 0; i < csvColors.Length; i++)
            {
                x++;
                if (x == width)
                {
                    x = 0;
                    y++;
                }
                if (i == 1023) break;
                Console.WriteLine(x + " " + y);
                trixelGrid.SetTrixelAt(x, y, new Trixel(new Vector2(x * 32, y * 32), GetColor(int.Parse(csvColors[i]))));
                Console.WriteLine("set");


            }
        }

        public static int RoundUp(int numToRound, int multiple)
        {
            if (multiple == 0)
                return numToRound;

            int remainder = numToRound % multiple;
            if (remainder == 0)
                return numToRound;

            return numToRound + multiple - remainder;
        }

        public static string PadZeroes(int number, int digits)
        {
            string output = "";
            if (number < (10 ^ (digits - 1)))
            {
                for (int i = 0; i < digits - 1; i++)
                {
                    output += "0";
                }
                output += number;
            }
            else
            {
                output = number.ToString();
            }
            return output;
        }
    }
}
