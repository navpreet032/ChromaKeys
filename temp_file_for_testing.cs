using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaKeys
{
    internal class temp_file_for_testing
    {
        public  static List<Utils.KeyValSpeed> JSON(string animation_nam)
        {
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
            Utils.push_animation(notification_keyValueSpeedList, 4, 255, 0, 0, new bool[] { true, true, true, true }, 150, true);
            Utils.push_animation(notification_keyValueSpeedList, 4, 255, 0, 0, new bool[] { true, true, true, false }, 150, true);
            Utils.push_animation(notification_keyValueSpeedList, 4, 255, 0, 0, new bool[] { true, true, true, true }, 50, true);
            if(animation_nam == "notification")
                return notification_keyValueSpeedList;

            List<Utils.KeyValSpeed> keyValueSpeedList = new List<Utils.KeyValSpeed>();
            Utils.push_animation(keyValueSpeedList, 1, 255, 0, 0, new bool[] { true, true, true, true }, 500, true);
            Utils.push_animation(keyValueSpeedList, 2, 0, 255, 0, new bool[] { false, true, true, true }, 500, true);
            Utils.push_animation(keyValueSpeedList, 3, 0, 0, 255, new bool[] { false, false, true, true }, 500, true);
            Utils.push_animation(keyValueSpeedList, 3, 255, 0, 0, new bool[] { true, true, true, false }, 500, true);
            Utils.push_animation(keyValueSpeedList, 2, 255, 0, 0, new bool[] { true, true, false, true }, 500, true);
            Utils.push_animation(keyValueSpeedList, 1, 255, 0, 0, new bool[] { true, false, true, true }, 500, true);
            Utils.push_animation(keyValueSpeedList, 2, 255, 0, 0, new bool[] { false, true, true, true }, 500, true);
            Utils.push_animation(keyValueSpeedList, 3, 255, 100, 50, new bool[] { false, false, false, false }, 1000, true);
            Utils.push_animation(keyValueSpeedList, 1, 50, 100, 255, new bool[] { true, true, false, false }, 500, true);
            Utils.push_animation(keyValueSpeedList, 2, 255, 255, 255, new bool[] { true, true, true, false }, 500, true);
            Utils.push_animation(keyValueSpeedList, 3, 255, 255, 255, new bool[] { true, true, true, true }, 500, true);
            if (animation_nam == "pattern1")
                return keyValueSpeedList;

            List<Utils.KeyValSpeed> keyValueSpeedList2 = new List<Utils.KeyValSpeed>();
            Utils.push_animation(keyValueSpeedList2, 1, 255, 100, 100, new bool[] { true, true, true, true }, 500, true);
            return keyValueSpeedList2;
        }
    }
}
