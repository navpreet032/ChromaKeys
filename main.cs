using System;
using System.Text;
using System.IO.Pipes;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using TsDotNetLib;
using ChromaKeys;



    public class entry
    {
       

            // Main function to run all codes
        static async Task Main()
        {
        int setColor = 28;
        int setZone = 29;
        ulong zone_status = encoding.encode_ZoneStates(true, true, true, false);
        ulong zone_color = encoding.encode_ZoneColor(1, 255, 150, 255);

        await ChromaKeys.namedpipe.WMI_SetKbRGB(zone_color, setColor);
        }
    }

