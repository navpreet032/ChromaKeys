using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChromaKeys
{
    internal class Utils
    {
        public class JSON_path() {
            static string path = @"E:\\C#NitroNamedPIPE\\ChromaKeys\\anim_data.json";
            public static string get_JsonPath()
            {
                return path;
            }
            public static void set_JsonPath(string str)
            {
                path = str;
            }
        }

        public class Color
        {// store's recent used colors
            
               public ulong R { get; set; }
               public ulong G { get; set; }
               public ulong B { get; set; }
            public Color(ulong r, ulong g, ulong b)
            {
                R = r;
                G = g;
                B = b;
            }


        }
        public class RGB_table
        {
            public static List<Color> colors = new List<Color>();

            // add rgb values in list
            public static void add_Rgb(ulong R, ulong G, ulong B)
            {
                Color c = new Color(R, G, B);
                colors.Add(c);
            }
           
            public static List<ulong>get_RGB()
            {
                
                    List<ulong> list = new List<ulong>();
                    list.Add(colors.ElementAt(colors.Count - 1).R);
                    list.Add(colors.ElementAt(colors.Count - 1).G);
                    list.Add(colors.ElementAt(colors.Count - 1).B);
                    return list;
                
            }
        }

        public class pattern_table
        {// stores recent used anim/notif names
            // NOTE : remember to add code to empty the List
            static List<string> patterns = new List<string>();
            public static void set_patternTable(string item)
            {
                if(!patterns.Contains(item))
                    patterns.Add(item);
                
            }
            public static string get_patternName()
            {
               if(patterns.Count != 0) 
                    return patterns.ElementAt(patterns.Count - 1).ToString();
               else
                throw new InvalidOperationException("The pattern table is empty.");
            }
        }
       public  class stateTable()
        {
            public 
            static List<string> state_table = new List<string>();
            // Method to get the last KeyValuePair from the list
            public static string GetLast()
            {
                if (state_table.Count == 0)
                {
                    throw new InvalidOperationException("The state table is empty.");
                }

                return state_table.Last();
            }

            // Method to delete the last KeyValuePair from the list
            public static void DeleteAtLast()
            {
                foreach(var item in state_table)
                    Console.WriteLine(item.ToString());
                if (state_table.Count == 0)
                {
                    throw new InvalidOperationException("The state table is empty.");
                }
                Console.WriteLine(state_table[state_table.Count() - 1]);
                state_table.RemoveAt(state_table.Count()-1 );
            }

            // Method to get all KeyValuePairs from the list
            public static List<string> GetAll()
            {
                return state_table;
            }

            // Method to add a KeyValuePair at the end of the list
            public static void AddLast(string key)
            {
                state_table.Add(key);
            }
            // Method to  get the key of the last element
            public static string GetKeyOfLastElement()
            {
                
                if (state_table.Count == 0)
                {
                    throw new InvalidOperationException("The state table is empty.");
                }

                return state_table.Last();
            }


        }
        public class KeyValSpeed
        {// structure for storing data
            public ulong input { get; set; }
            public int identifier { get; set; }
            public int Speed { get; set; }

            // constructor
            public KeyValSpeed(ulong key, int id, int speed)
            {
                input = key;
                identifier = id;
                Speed = speed;
            }
        }

        // Method to write a single pattern to JSON file
        public static void WritePatternToJsonFile(string jsonFilePath, string patternName, List<KeyValSpeed> patternData)
        {
            // Read the existing JSON file if it exists
            Dictionary<string, List<KeyValSpeed>> allPatterns = new Dictionary<string, List<KeyValSpeed>>();
            if (File.Exists(jsonFilePath))
            {
                string existingJson = File.ReadAllText(jsonFilePath);
                allPatterns = JsonConvert.DeserializeObject<Dictionary<string, List<KeyValSpeed>>>(existingJson) ?? new Dictionary<string, List<KeyValSpeed>>();
            }

            // Add or update the pattern data
            allPatterns[patternName] = patternData;

            // Write updated data back to JSON
            string json = JsonConvert.SerializeObject(allPatterns, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }
        // Method to read a single pattern from JSON file
        public static List<KeyValSpeed> ReadPatternFromJsonFile(string jsonFilePath, string patternName)
        {
            // Check if the file exists
            if (!File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException("The JSON file was not found.", jsonFilePath);
            }

            // Read the JSON content
            string jsonContent = File.ReadAllText(jsonFilePath);
            var allPatterns = JsonConvert.DeserializeObject<Dictionary<string, List<KeyValSpeed>>>(jsonContent);

            // Retrieve the pattern data if it exists
            if (allPatterns != null && allPatterns.TryGetValue(patternName, out List<KeyValSpeed> patternData))
            {
                return patternData;
            }
            else
            {
                throw new KeyNotFoundException($"The pattern '{patternName}' was not found in the JSON file.");
            }
        }

        // Method to push animation data to List
        public static void push_animation(List<KeyValSpeed> keyValueSpeedList, int zone_idx, ulong R, ulong G, ulong B, bool[] zone_prevStates, int speed, bool color_or_zone)
        {
            //zone index for zone color (R, G, B) 
            // zone_states , animationSpeed, 
            // color_or_zone == true color is added first in animation


            ulong zone_color_data = encoding.encode_ZoneColor(zone_idx, R, G, B);
            ulong zone_status_data = encoding.encode_ZoneStates(zone_prevStates[0], zone_prevStates[1], zone_prevStates[2], zone_prevStates[3]);

            KeyValSpeed colorData = new KeyValSpeed(zone_color_data, 28, speed);
            KeyValSpeed statusData = new KeyValSpeed(zone_status_data, 29, speed);

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

        // Rollback function

        public static async Task<int> Rollback(string input, ulong R,ulong G, ulong B)
        {   
            // static, anim, notif and data for animation/notification anim_List and RGB for static lighting
            
            
               
                    stateTable.DeleteAtLast();
                if (stateTable.GetKeyOfLastElement() == "static") { 
                    stateTable.DeleteAtLast();
                    List<Color> colorList = new List<Color>();
                    colorList.Add(new Color(R, G, B));
                    await Api_entry_handles.run_staticAllZonesHandel(R, G, B);
                    
                }
                else if (stateTable.GetKeyOfLastElement() == "anim") { 
                    stateTable.DeleteAtLast();
                    await Api_entry_handles.run_animnationHandel(input);
                    //await namedpipe.ANIM_WMI_SetKbRGB(input, true);
                }
                else  { 
                    stateTable.DeleteAtLast();
                   // await namedpipe.Notification_WMI_SetKbRGB(input);
                    await Api_entry_handles.run_notificationHandel(input);
                }
            
            // temp value
            return 0;
        }
    }
}
