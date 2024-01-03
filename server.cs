using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ChromaKeys
{
    
    public class ColorRequest
    {
        public List<ulong> Colors { get; set; }
    }
    public class PatternItem
    {
        public int Zone { get; set; }
        public ulong R { get; set; }
        public ulong G { get; set; }
        public ulong B { get; set; }
        public bool[] States { get; set; }
        public int Speed { get; set; }
        public bool IsStatic { get; set; }
    }

    public class PatternRequest
    {
        public string Name { get; set; }
        public List<PatternItem> Data { get; set; }
    }

    

    [Route("api/[controller]")]
    [ApiController]
    public class PatternsController : ControllerBase
    {
        private static readonly SemaphoreSlim _rgbSemaphore = new SemaphoreSlim(1, 1);

        // POST api/patterns/set_static_color
        [HttpPost("set_static_color")]
        public async Task<ActionResult> SetStaticColor([FromBody] ColorRequest req)
        {
            await _rgbSemaphore.WaitAsync();
            try
            {
                //logic to set the static color
                await Api_entry_handles.run_staticAllZonesHandel(req.Colors[0], req.Colors[1], req.Colors[2]);
            }
            finally
            {
                _rgbSemaphore.Release();
            }
            return Ok($"Static color set to: R:{req.Colors[0]}, G:{req.Colors[1]}, B:{req.Colors[2]}");
        }

        // POST api/patterns/holy_fun
        [HttpPost("holy_fun")]  
        public ActionResult HolyFun([FromBody] List<string> funList)
        {
            // Add logic for set rgb per zone

            return Ok($"Holy function called with {funList.Count} items.");
        }

        // POST api/patterns/set_pattern
        [HttpPost("set_pattern")]
        public async Task<ActionResult> SetPattern([FromBody] PatternRequest patternRequest)
        {
            await _rgbSemaphore.WaitAsync();
            try
            {
                List<Utils.KeyValSpeed> pattern_list = new List<Utils.KeyValSpeed>();

                void make_Animation(List<Utils.KeyValSpeed> list, PatternItem data)
                {
                    Utils.push_animation(list, data.Zone, data.R, data.G, data.B, data.States, data.Speed, data.IsStatic);
                }
                foreach (var item in patternRequest.Data)
                {
                    make_Animation(pattern_list, item);
                }
                if (pattern_list.Count > 0)
                {
                    Utils.WritePatternToJsonFile(Utils.JSON_path.get_JsonPath(), patternRequest.Name, pattern_list);

                }
                else
                {
                    return BadRequest("Can't Save the pattern");
                }
            }
            finally { _rgbSemaphore.Release(); }
            return Ok($"Pattern '{patternRequest.Name}' set with {patternRequest.Data.Count} items.");
        }

        // POST api/patterns/play_notification
        [HttpPost("play_notification")]
        public async Task<ActionResult> PlayNotification([FromBody] string notification)
        {
            await _rgbSemaphore.WaitAsync();

            try {
                try
                {

                    await Api_entry_handles.run_notificationHandel(notification);
                }
                catch (Exception e)
                {
                    return BadRequest($"{e.Message}");
                }
            }
            finally {
                _rgbSemaphore.Release();
            }
            

            return Ok($"Notification '{notification}' played.");
        }
    }

    public class PatternData
    {
        public string Name { get; set; }
        public List<ulong> Data { get; set; } // Adjust this according to your pattern data structure
    }
}

