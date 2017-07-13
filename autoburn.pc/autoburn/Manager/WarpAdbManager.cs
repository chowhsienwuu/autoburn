using Autoburn.util;
using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn.Manager
{
    class WarpAdbManager
    {
        public const string TAG = "WarpAdbManager";

        private string adbpath = "adb.exe";

        private DeviceManager DeviceManager = null;

        private AdbSocket AdbSocket = null;
        public WarpAdbManager(DeviceManager manager)
        {
            DeviceManager = manager;
            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipendpoint = new IPEndPoint(ipaddress, 5037);//the default .
            AdbSocket = new AdbSocket(ipendpoint);

            AdbServerStatus status = AdbServer.Instance.GetStatus();

            if (!status.IsRunning)
            {
                SystemLog.E(TAG, "ADB 没有运行! 重新启动ADB...");
                AdbServer.Instance.StartServer(adbpath, true);
            }
            status = AdbServer.Instance.GetStatus();

            ProgLog.D(TAG, "" + status.Version + ".." + status.IsRunning);
        }


        private void Moniter()
        {
            var monitor = new DeviceMonitor(AdbSocket);
            monitor.DeviceConnected += this.OnDeviceConnected;
            monitor.Start();
        }

        void OnDeviceConnected(object sender, DeviceDataEventArgs e)
        {
            Console.WriteLine($"The device {e.Device.Name} has connected to this PC");
        }

        void UploadFile()
        {
            var device = AdbClient.Instance.GetDevices().First();

            using (SyncService service = new SyncService(AdbSocket, device))
            using (Stream stream = File.OpenRead(@"C:\MyFile.txt"))
            {
                service.Push(stream, "/data/MyFile.txt", null, CancellationToken.None);
            }
        }

    }
}
