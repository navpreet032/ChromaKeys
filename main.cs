using System;
using System.Text;
using System.IO.Pipes;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using TsDotNetLib;
using ChromaKeys;
using static ChromaKeys.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;



public class Entry
    {
       
        
            // Main function to run all codes
        static async Task Main(string[] args)
        {

        //List<KeyValSpeed> tmp = temp_file_for_testing.JSON("notification");
        //Utils.WritePatternToJsonFile(@"E:\\C#NitroNamedPIPE\\ChromaKeys\\anim_data.json","pattern2", tmp);
        //await Api_entry_handles.run_animnationHandel("pattern1"); ❌ animation works only for 2-4 iterations
        var webHostTask = CreateHostBuilder(args).Build().RunAsync();
        // turn all Zones ON
        await namedpipe.WMI_SetKbRGB(16492674416648, 29);
        await Api_entry_handles.run_staticAllZonesHandel(100,0,150);


        await webHostTask;

    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>(); // Ensure you have a Startup class defined
            });
}

