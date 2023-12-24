
using System.IO.Pipes;

using TsDotNetLib;


namespace ChromaKeys
{
    internal class namedpipe
    {
       

        public static async Task<uint> WMI_SetKbRGB(ulong input, int identifier)
        {
            uint num2;
            try

            {

                NamedPipeClientStream cline_stream = new NamedPipeClientStream(".", "PredatorSense_service_namedpipe", PipeDirection.InOut);
                cline_stream.Connect();
                uint num = await Task.Run<uint>(delegate
                {
                    IPCMethods.SendCommandByNamedPipe(cline_stream, identifier, new object[] { input });
                    cline_stream.WaitForPipeDrain();
                    byte[] array = new byte[9];
                    cline_stream.Read(array, 0, array.Length);
                  
                    return BitConverter.ToUInt32(array, 5);
                }).ConfigureAwait(false);
                cline_stream.Close();
                num2 = num;
            }
            catch (Exception)
            {
                num2 = uint.MaxValue;
            }
            return 0;
        }

        public static async Task ANIM_WMI_SetKbRGB(List<Utils.KeyValSpeed> input, bool run)
        {
            try
            {
                using (NamedPipeClientStream cline_stream = new NamedPipeClientStream(".", "PredatorSense_service_namedpipe", PipeDirection.InOut))
                {

                    cline_stream.Connect();
                    while (run)
                    {
                        foreach (var pair in input)
                        {
                            try
                            {
                                if (pair.identifier == 28)
                                {
                                    IPCMethods.SendCommandByNamedPipe(cline_stream, 28, new object[] { pair.input });
                                }
                                else
                                {
                                    IPCMethods.SendCommandByNamedPipe(cline_stream, 29, new object[] { pair.input });
                                }

                                cline_stream.WaitForPipeDrain();
                                Thread.Sleep(pair.Speed);
                            }
                            catch (Exception ex)
                            {
                                   
                                // Log or handle the exception
                                Console.WriteLine("Exception in loop: " + ex.Message);
                                // Consider whether to break out of the loop or not
                            }
                        }
                       
                    }
                }
            }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in ANIM_WMI_SetKbRGB: " + ex.Message);
                }

        }

        
        public static async Task<uint> Notification_WMI_SetKbRGB(List<Utils.KeyValSpeed> input) 
        {
            uint num2;
            try

            {

                NamedPipeClientStream cline_stream = new NamedPipeClientStream(".", "PredatorSense_service_namedpipe", PipeDirection.InOut);
                cline_stream.Connect();
                uint num = await Task.Run<uint>(delegate
                {
                   
                        foreach (var pair in input)
                        {
                            if (pair.identifier == 28)
                            {
                                IPCMethods.SendCommandByNamedPipe(cline_stream, 28, new object[] { pair.input });
                            }
                            else
                            {
                                IPCMethods.SendCommandByNamedPipe(cline_stream, 29, new object[] { pair.input });
                            }

                            cline_stream.WaitForPipeDrain();
                            Thread.Sleep(pair.Speed);
                        }
                        Thread.Sleep(50);
                    
                    byte[] array = new byte[9];
                    cline_stream.Read(array, 0, array.Length);
                   
                    return BitConverter.ToUInt32(array, 5);
                }).ConfigureAwait(false);
                cline_stream.Close();
                num2 = num;
                Utils.stateTable.AddLast("notif");
            }
            catch (Exception)
            {
                num2 = uint.MaxValue; 
            }
            
            List<ulong> list = Utils.RGB_table.get_RGB();
            
            //GET DATA From JSON Based on NAME
            //List<Utils.KeyValSpeed> prev_input = Utils.ReadPatternFromJsonFile(Utils.JSON_path.get_JsonPath(), Utils.pattern_table.get_patternName());
            await Utils.Rollback(Utils.pattern_table.get_patternName(), list[0], list[1], list[2]);
          
            return 0;
        }

        public static async Task<uint> WMI_setAllZones(ulong R, ulong G, ulong B)
        {   
            uint num2;
            try

            {

                NamedPipeClientStream cline_stream = new NamedPipeClientStream(".", "PredatorSense_service_namedpipe", PipeDirection.InOut);
                cline_stream.Connect();
                uint num = await Task.Run<uint>(delegate
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        ulong input = encoding.encode_ZoneColor(i, R, G, B);
                    IPCMethods.SendCommandByNamedPipe(cline_stream, 28, new object[] { input });
                    cline_stream.WaitForPipeDrain();
                    }
                    byte[] array = new byte[9];
                    cline_stream.Read(array, 0, array.Length);
                    
                    return BitConverter.ToUInt32(array, 5);
                }).ConfigureAwait(false);
                cline_stream.Close();
                num2 = num;
            }
            catch (Exception)
            {
                num2 = uint.MaxValue;
            }
            return 0;
        }
    }
}
