using System;
using System.Text;
using System.IO.Pipes;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using TsDotNetLib;
using ChromaKeys;
using static ChromaKeys.Utils;



    public class entry
    {
       

            // Main function to run all codes
        static async Task Main()
        {
        int setColor = 28;
        int setZone = 29;
        ulong zone_status = encoding.encode_ZoneStates(true, true, true, false);
        ulong zone_color = encoding.encode_ZoneColor(1, 255, 150, 255);
        //await ChromaKeys.namedpipe.WMI_setAllZones(0,255,200);

        List<Utils.KeyValSpeed> keyValueSpeedList = new List<Utils.KeyValSpeed>();
        Utils.push_animation(keyValueSpeedList,1, 255, 0, 0, new bool[] { true, true, true, true }, 500, true);
        Utils.push_animation(keyValueSpeedList, 2, 0, 255, 0, new bool[] { false, true, true, true }, 500, true);
        Utils.push_animation(keyValueSpeedList, 3, 0, 0, 255, new bool[] { false, false, true, true }, 500, true);
        Utils.push_animation(keyValueSpeedList, 3, 255, 0, 0, new bool[] { true, true, true, false }, 500, true);
        Utils.push_animation(keyValueSpeedList, 2, 255, 0, 0, new bool[] { true, true, false, true }, 500, true);
        Utils.push_animation(keyValueSpeedList, 1, 255, 0, 0, new bool[] { true, false, true, true }, 500, true);
        Utils.push_animation(keyValueSpeedList, 2, 255, 0, 0, new bool[] { false, true, true, true }, 500, true);
        Utils.push_animation(keyValueSpeedList, 3, 255, 100, 50, new bool[] { false, false , false , false }, 1000, true);
        Utils.push_animation(keyValueSpeedList, 1, 50, 100, 255, new bool[] { true, true, false, false }, 500, true);
        Utils.push_animation(keyValueSpeedList, 2, 255, 255, 255, new bool[] { true, true, true, false}, 500, true);
        Utils.push_animation(keyValueSpeedList, 3, 255, 255, 255, new bool[] { true, true, true, true }, 500, true);
        
       
        Console.WriteLine(keyValueSpeedList.Count);
       // await ChromaKeys.namedpipe.ANIM_WMI_SetKbRGB(keyValueSpeedList, true);
        List<Utils.KeyValSpeed> notification_keyValueSpeedList = new List<Utils.KeyValSpeed>();
        Utils.push_animation(notification_keyValueSpeedList, 1, 255, 0, 255, new bool[] { false, false, false, false }, 0, true);
        Utils.push_animation(notification_keyValueSpeedList, 1, 255, 0, 255, new bool[] { true, false, false, false }, 200, true);
        Utils.push_animation(notification_keyValueSpeedList, 1, 255, 0, 255, new bool[] { false, false, false, false }, 200, true);
        Utils.push_animation(notification_keyValueSpeedList, 1, 255, 0, 255, new bool[] { true, false, false, false }, 200, true);
        Utils.push_animation(notification_keyValueSpeedList, 2, 255, 0, 0, new bool[] { true, true, false, false }, 200, true);
        Utils.push_animation(notification_keyValueSpeedList, 2, 255, 0, 0, new bool[] { true, false, false, false }, 100, true);
        Utils.push_animation(notification_keyValueSpeedList, 2, 255, 0, 0, new bool[] { true, true, false, false }, 200, true);
        Utils.push_animation(notification_keyValueSpeedList, 3, 255, 0, 0, new bool[] { true, true, true, false }, 200, false);
        Utils.push_animation(notification_keyValueSpeedList, 3, 255, 0, 255, new bool[] { true, true, false, false }, 150, true);
        Utils.push_animation(notification_keyValueSpeedList, 3, 255, 0, 255, new bool[] { true, true, true, false }, 100, false);
        Utils.push_animation(notification_keyValueSpeedList, 4, 255, 0, 0, new bool[] { true, true, true, true }, 150, true);
        Utils.push_animation(notification_keyValueSpeedList, 4, 255, 0, 0, new bool[] { true, true, true, false }, 100, true);
        Utils.push_animation(notification_keyValueSpeedList, 4, 255, 0, 0, new bool[] { true, true, true, true}, 150, true);
        Utils.push_animation(notification_keyValueSpeedList, 4, 255, 0, 0, new bool[] { true, true, true, false}, 150, true);
        Utils.push_animation(notification_keyValueSpeedList, 4, 255, 0, 0, new bool[] { true, true, true, true}, 50, true);
        
        await ChromaKeys.namedpipe.Notification_WMI_SetKbRGB(notification_keyValueSpeedList);

    }
    }

