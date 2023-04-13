using AssetFinanziari.Interface;
using AssetFinanziari.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetFinanziari.Static
{
    internal class WorldBank
    {
        public static bool Transfer(CommercialBank from, CommercialBank to)
        {
            if (from.CentralBank is ISwiftSystem && to.CentralBank is ISwiftSystem)
            {
                return true;
            }
            else if (from.CentralBank is not ISwiftSystem )
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($" bank {from.Name} from {from.Country} is not in the Swift System. " +
                    $"It's  under Sanction! ");
                Console.ResetColor();
                
            }
            else if (to.CentralBank is not ISwiftSystem)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"bank {to.Name} from {to.Country} is not in the Swift System. " +
                    $"It's  under Sanction! ");
                Console.ResetColor();

              
            }
            return false;

        }
    }
}
