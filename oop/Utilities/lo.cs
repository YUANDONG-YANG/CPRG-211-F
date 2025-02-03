using System;

namespace oop.Utilities
{
    /// <summary>
    /// Utility class for logging messages to the console.
    /// </summary>
    public static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }
}
