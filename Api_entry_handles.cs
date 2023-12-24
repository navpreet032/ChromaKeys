using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaKeys
{
    internal class Api_entry_handles
    {// Write code to set animation in json
        public static async Task run_staticAllZonesHandel(ulong R,ulong G, ulong B) { 
            await namedpipe.WMI_setAllZones(R, G, B);
            // set RGB_table
            Utils.RGB_table.add_Rgb(R, G, B);
            Utils.stateTable.AddLast("static");

        }
        public static async Task run_animnationHandel(string anim_name) {
            
            List<Utils.KeyValSpeed> anim = Utils.ReadPatternFromJsonFile(Utils.JSON_path.get_JsonPath(),anim_name);
            await namedpipe.ANIM_WMI_SetKbRGB(anim,true);
            // set state_table
            Utils.pattern_table.set_patternTable(anim_name);
            Utils.stateTable.AddLast("anim");
        }
        public static async Task run_notificationHandel(string notif_name) {
            
            Utils.pattern_table.set_patternTable(notif_name);
            List<Utils.KeyValSpeed> notif = Utils.ReadPatternFromJsonFile(Utils.JSON_path.get_JsonPath(), notif_name);
            await namedpipe.Notification_WMI_SetKbRGB(notif);
            // set state_table
            
        }

    }
}
