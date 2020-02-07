using System;


namespace DebugConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            SetupConsole();
            int port = ProcessArguments(args);
            Listener listener = new Listener(port);
        }

        static void SetupConsole()
        {
            Console.Title = "DebugConsole";
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DebugConsole running.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static int ProcessArguments(string[] args)
        {
            try
            {
                int port;
                if (args.Length >= 1)
                    port = int.Parse(args[0]);
                else
                    port = Listener.PortDefault;

                return port;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProcessArguments() exception caught: " + ex.Message);
                return Listener.PortDefault;
            }
        }
    }
}