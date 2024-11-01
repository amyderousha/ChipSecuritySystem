using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        public static List<ColorChip> colorChips = new List<ColorChip>() {
                new ColorChip(Color.Blue, Color.Yellow),
                new ColorChip(Color.Red, Color.Green),
                new ColorChip(Color.Yellow, Color.Red),
                new ColorChip(Color.Orange, Color.Purple),
            };
        static void Main(string[] args)
        {
            var chips = SortChips(colorChips);

            if (chips.Count > 0)
            {
                //print results
                foreach (var chip in chips)
                {
                    Console.WriteLine(chip.ToString());
                }
            }
            else
            {
                Console.WriteLine(Constants.ErrorMessage);
            }
            Console.ReadLine();
        }

        public static List<ColorChip> SortChips(List<ColorChip> colorChips)
        {
            var result = new List<ColorChip>();

            if (colorChips.Count > 0)
            {
                result.Add(colorChips.Where(c => c.StartColor == Color.Blue).First());
                for (int i = 0; i < result.Count; i++)
                {
                    for (int j = 0; j < colorChips.Count; j++)
                    {
                        //check if any colorChips have a start color that matches the end color of last chip in result
                        if (colorChips[j].StartColor == result[i].EndColor)
                        {
                            result.Add(colorChips[j]);
                        }
                    }
                }
            }
            else
            {
                return null;
            }
            return result;
        }
    }
}
