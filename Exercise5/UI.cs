using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Exercise5
{
    // TODO extract interface

    public class UI
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

        public int ReadInt() => ReadInt("");
        public int ReadInt(string prompt)
        {
            int result;
            do
            {
                string line = ReadLine(prompt);
                if (int.TryParse(line, out result))
                    return result;
                else
                    Console.WriteLine("Input has to be an integer!");
            } while (true);
        }
    }
}
