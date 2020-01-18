using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapPlotting
{
    class Program
    {
        private static bool[,] map_plotting = new bool[14, 31];

        public static void Main()
        {
            PromptCoords();
            MoreCoords();

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        public static void PromptCoords()
        {
            bool x_output;
            int x_co;
            bool y_output;
            int y_co;

            do
            {
                Console.Write("Place a marker at which X coordinate? (0-30): ");
                string x_input = Console.ReadLine();

                x_output = int.TryParse(x_input, out x_co);

                if (!x_output)
                {
                    Console.WriteLine("Invalid input.");
                }

                if (x_co < 0 || x_co > 30)
                {
                    Console.WriteLine("Out of range.");
                }

            } while (!x_output || x_co < 0 || x_co > 30);

            do
            {
                Console.Write("Place a marker at which Y coordinate? (0-13): ");
                string y_input = Console.ReadLine();

                y_output = int.TryParse(y_input, out y_co);

                if (!y_output)
                {
                    Console.WriteLine("Invalid input.");
                }

                if (y_co < 0 || y_co > 13)
                {
                    Console.WriteLine("Out of range.");
                }
            } while (!y_output || y_co < 0 || y_co > 13);

            map_plotting[y_co, x_co] = true;
        }

        public static void MoreCoords()
        {
            Console.Write("More? (y/n): ");
            string input = Console.ReadLine();

            if (input == "y")
            {
                PromptCoords();
                MoreCoords();
            }

            else if (input == "n")
            {
                for (int row = 0; row < 14; row++)
                {
                    for (int column = 0; column < 31; column++)
                    {
                        if (!map_plotting[row, column])
                        {
                            Console.Write(".");
                        }

                        else if (map_plotting[row, column])
                        {
                            Console.Write("X");
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}

