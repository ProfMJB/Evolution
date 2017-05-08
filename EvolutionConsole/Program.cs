using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evolution;

namespace EvolutionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const int tests = 400;
            int blue = 0;
            for (int i = 0; i < tests; i++)
            {
                Console.WriteLine("=====================");

                Gene<bool> genes1 = new Gene<bool>(true, false);
                Blob blob1 = new Blob(genes1);
                Console.WriteLine(blob1);
                Console.WriteLine(blob1.IsBlue);

                Gene<bool> genes2 = new Gene<bool>(true, false);
                Blob blob2 = new Blob(genes2);
                Console.WriteLine(blob2);
                Console.WriteLine(blob2.IsBlue);

                Blob blob3 = (Blob)Creature.Breed<Blob>(blob1, blob2);
                Console.WriteLine(blob3);
                Console.WriteLine(blob3.IsBlue);

                if (blob3.IsBlue)
                    blue++;
            }

            Console.WriteLine("{0} : {1:0.0}%", blue, (100.0 * blue) / tests);
            Console.ReadLine();
        }
    }
}
