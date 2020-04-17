using System;

namespace FLUX
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n███████╗██╗     ██╗   ██╗██╗  ██╗ \n██╔════╝██║     ██║   ██║╚██╗██╔╝ \n█████╗  ██║     ██║   ██║ ╚███╔╝ \n█████╗  ██║     ██║   ██║ ╚███╔╝ \n██╔══╝  ██║     ██║   ██║ ██╔██╗ \n██║     ███████╗╚██████╔╝██╔╝ ██╗ \n╚═╝     ╚══════╝ ╚═════╝ ╚═╝  ╚═╝\n");
            Bot bot = new Bot();
            bot.TaskAsync().GetAwaiter().GetResult();
        }
    }
}
