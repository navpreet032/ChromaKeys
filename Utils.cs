using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaKeys
{
    internal class Utils
    {
        public class KeyValSpeed
        {// structure for storing data
            public ulong input { get; set; }
            public int identifier { get; set; }
            public int Speed { get; set; }

            public KeyValSpeed(ulong key, int id, int speed)
            {
                input = key;
                identifier = id;
                Speed = speed;
            }
        }

        public static void push_animation (List<KeyValSpeed> keyValueSpeedList,int zone_idx,ulong R,ulong G, ulong B,bool[] zone_prevStates,int speed, bool color_or_zone){
            //zone index for zone color (R, G, B) 
            // zone_states , animationSpeed, 
            // color_or_zone == true color is added first in animation

           
            ulong zone_color_data = encoding.encode_ZoneColor(zone_idx, R, G, B);
            ulong zone_status_data = encoding.encode_ZoneStates(zone_prevStates[0], zone_prevStates[1], zone_prevStates[2], zone_prevStates[3]);

            KeyValSpeed colorData = new KeyValSpeed( zone_color_data,28,speed );
            KeyValSpeed statusData = new KeyValSpeed( zone_status_data,29,speed );

            if (color_or_zone)
            {
                // identifier = 28
                keyValueSpeedList.Add(colorData);
                keyValueSpeedList.Add(statusData);

            }
            else
            {
                // identifier = 29
                keyValueSpeedList.Add(statusData);
                keyValueSpeedList.Add(colorData);
            }
            
            
            

        }
    }
}
