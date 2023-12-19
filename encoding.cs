using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaKeys
{
    internal class encoding
    {
        public static ulong encode_ZoneStates(bool zone1On, bool zone2On, bool zone3On, bool zone4On)
        {
            ulong encodedState = 8UL; // Base value (assuming it's always needed)

            // Define the mask for each zone
            ulong zone1Mask = 1099511627776UL; // Zone 1
            ulong zone2Mask = 2199023255552UL; // Zone 2
            ulong zone3Mask = 4398046511104UL; // Zone 3
            ulong zone4Mask = 8796093022208UL; // Zone 4

            // Apply mask if zone is on
            if (zone1On) encodedState |= zone1Mask;
            if (zone2On) encodedState |= zone2Mask;
            if (zone3On) encodedState |= zone3Mask;
            if (zone4On) encodedState |= zone4Mask;

            return encodedState;
        }

        public static ulong encode_ZoneColor(int zone, ulong R, ulong G, ulong B)
        {
            ulong output = 0UL;
            if (zone == 1)
            {
                output = 1UL | (R << 8) | (G << 16) | (B << 24);
            }
            else if (zone == 2)
            {
                output = 2UL | (R << 8) | (G << 16) | (B << 24);
            }
            else if (zone == 3)
            {
                output = 4UL | (R << 8) | (G << 16) | (B << 24);
            }
            else if (zone == 4)
            {
                output = 8UL | (R << 8) | (G << 16) | (B << 24);
            }
            return output;
        
    }
    }
}
