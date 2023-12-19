using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Console.WriteLine(BitConverter.ToUInt32(array, 5));
                    Console.WriteLine(BitConverter.ToString(array));
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
