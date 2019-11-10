namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // set up prefixes
            string[] prefixes = new string[1];
            prefixes[0] = "http://localhost:8080/";

            // create new listener
            Listener listener = new Listener(prefixes);
        }
    }
}
