using System;
using System.Text;
using Microsoft.Azure.Devices;
using RohdeSchwarz.Iot.Middleware.Client;

namespace IotCommandLineClient
{
    class Program
    {
        const string IOT_HUB_CONNECTION_STRING = "<your hub's connection string>"; // e.g. "HostName=Delos-Mesa-Hub.azure-devices.net;SharedAccessKeyName=..."
        const string GATEWAY_DEVICE_ID = "<your gateway's id>"; // e.g. "qa-gateway1"
        const string INSTRUMENT_CONNECTION = "<your instrument's connection>"; // e.g. "TCPIP::192.168.0.100::INSTR"

        static void Main(string[] _)
        {
            // Create the Service Client
            var serviceClient = ServiceClient.CreateFromConnectionString(IOT_HUB_CONNECTION_STRING, TransportType.Amqp);
            // Initiate the VISA instance
            var visa = new IotVisa(serviceClient, GATEWAY_DEVICE_ID);

            visa.ViOpenDefaultRM(out int rm);
            visa.ViOpen(rm, INSTRUMENT_CONNECTION, 0, 1000, out int vi);
            var request = Encoding.ASCII.GetBytes("*IDN?");
            visa.ViWrite(vi, request, request.Length, out int _);
            var response = new byte[1024];
            visa.ViRead(vi, response, response.Length, out int _);
            visa.ViClose(vi);
            visa.ViClose(rm);

            // Print out the response
            Console.WriteLine($"IDN Response: {Encoding.ASCII.GetString(response)}");
            // Pause the console window
            Console.ReadLine(); 
        }
    }
}
