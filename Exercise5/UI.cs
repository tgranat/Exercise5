using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Exercise5
{
    public class UI : IUI
    {
        public void PrintLine(string line)
        {
            Console.WriteLine(line);
        }

        public string ReadLine() => ReadLine("");

        public string ReadLine(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public int ReadInt(int min, int max) => ReadInt("", min, max);   
        public int ReadInt() => ReadInt("", 0, 10000);
        public int ReadInt(string prompt) => ReadInt(prompt, 0, 10000);
        public int ReadInt(string prompt, int min, int max)
        {
            int result;
            do
            {
                string line = ReadLine(prompt);
                if (int.TryParse(line, out result))
                {
                    if (result < min || result > max)
                    {
                        Console.WriteLine($"Input has to be in the range {min} - {max}");
                        continue;
                    }
                    else
                    {
                        return result;
                    }
                }
                else
                {
                    Console.WriteLine("Input has to be an integer!");
                }
            } while (true);
        }
    }
}
