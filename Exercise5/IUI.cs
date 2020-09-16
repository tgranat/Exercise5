namespace Exercise5
{
    public interface IUI
    {
        void PrintLine(string line);
        int ReadInt();
        int ReadInt(string prompt);
        string ReadLine();
        string ReadLine(string prompt);
    }
}