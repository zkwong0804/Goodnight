using System;
using System.Threading;
using System.Diagnostics;

namespace Goodnight
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                int live = 0;
                if (int.TryParse(args[0], out live))
                {
                    switch (args[1])
                    {
                        case "sec":
                            break;
                        case "min":
                            live *= 60;
                            break;
                        case "hr":
                            live *= 60 * 60;
                            break;
                        default:
                            Console.WriteLine("Invalid time unit!");
                            _printGuidline();
                            return;

                    }

                    for (int countdown = live; countdown > 0; countdown--)
                    {
                        Console.WriteLine($"The browser of choice will be closed in {countdown}");
                        Thread.Sleep(1000);
                    }

                    try
                    {


                        foreach (var process in Process.GetProcessesByName("msedge")) process.Kill();
                    }
                    catch
                    {
                        Console.WriteLine("Opsie... seems there is nothing to be closed!");
                    }


                }
                else
                {
                    Console.WriteLine("Invalid live time!");
                    _printGuidline();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid args!");
                _printGuidline();
                return;
            }

            void _printGuidline()
            {
                Console.WriteLine("Usage: ./Goodnight <live-time> <time-unit>");
                Console.WriteLine("\nlive-time:\tTotal live time of browswer");
                Console.WriteLine("\ntime-unit:\tTime unit to use");
                Console.WriteLine("\nAvailable time unit:");
                Console.WriteLine("sec => Seconds");
                Console.WriteLine("min => Minutes");
                Console.WriteLine("hr => Hours");
            }
        }
    }
}
