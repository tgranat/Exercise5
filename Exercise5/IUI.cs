namespace Exercise5
{
    public interface IUI
    {
        void PrintLine(string line);
        int ReadInt();
        int ReadInt(int min, int max);
        int ReadInt(string prompt);
        int ReadInt(string prompt, int min, int max);
        string ReadLine();
        string ReadLine(string prompt);
    }
}