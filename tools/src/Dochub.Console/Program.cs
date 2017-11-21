using System;
using System.IO;
using Dochub.Console.Managers;
using Dochub.Console.Models;
using Dochub.Console.Services;
using Newtonsoft.Json;

namespace Dochub.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = Args.GetCommands(args);

            if (commands.Init)
            {
                var manager = new InitializeManager();

                manager.Init();

                return;
            }
        }
    }
}
