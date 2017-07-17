using Autoburn.util;
using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autoburn.Manager
{
    class WarpAdbManager
    {
        public const string TAG = "WarpAdbManager";

        private string adbpath = "adb.exe";

        private DeviceManager DeviceManager = null;

        private AdbSocket AdbSocket = null;
        private void InitAdbSocket()
        {
            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipendpoint = new IPEndPoint(ipaddress, 5037);//the default .
            AdbSocket = new AdbSocket(ipendpoint);
        }

        public WarpAdbManager(DeviceManager manager)
        {
            DeviceManager = manager;

            AdbServerStatus status = AdbServer.Instance.GetStatus();

            if (!status.IsRunning)
            {
                SystemLog.E(TAG, "ADB 没有运行! 重新启动ADB...");
                AdbServer.Instance.StartServer(adbpath, true);
            }
            status = AdbServer.Instance.GetStatus();
            if (status.IsRunning)
            {
                InitAdbSocket();
                Moniter();
            }
            ProgLog.D(TAG, "" + status.Version + ".." + status.IsRunning);

            //start moniter the devices plugin in/out event.
          
        }

        private void test()
        {
           // Device device = new Device(new DeviceData());
        }

        internal void Stop()
        {
            // AdbServer.Instance.Sto
            Tools.Tools.RunCmd("adb kill-server");
        }

        //
        #region ADB 监听
        public event EventHandler<DeviceDataEventArgs> DeviceStatusChanged;

        private void Moniter()
        {
            var monitor = new DeviceMonitor(AdbSocket);
            monitor.DeviceConnected += this.OnDeviceConnected;
            monitor.DeviceDisconnected += this.onDeviceDisConnected;
            monitor.Start();
        }

        void OnDeviceConnected(object sender, DeviceDataEventArgs e)
        {
            e.Device.State = DeviceState.Online;
            DeviceStatusChanged?.Invoke(this, e);
            Console.WriteLine($"The device {e.Device.Name} has connected to this PC ." + e.Device.State);
        }
        void onDeviceDisConnected(object sender, DeviceDataEventArgs e)
        {
            e.Device.State = DeviceState.Offline;
            DeviceStatusChanged?.Invoke(this, e);
            Console.WriteLine($"The device {e.Device.Name} has disconnected to this PC " + e.Device.State);
        }

        public DeviceData GetCurrentAdbDeviceData()
        {
            try
            {
                var devices = AdbClient.Instance.GetDevices();
                if (devices.Count > 0)
                {
                    return devices.First();
                }
            }
            catch
            {

            }
            DeviceData retData = new DeviceData();
            retData.State = DeviceState.Offline;
            return retData;
        }
        #endregion

        void UploadFile()
        {
            var device = AdbClient.Instance.GetDevices().First();
            
            using (SyncService service = new SyncService(AdbSocket, device))
            using (Stream stream = File.OpenRead(@"C:\MyFile.txt"))
            {
                service.Push(stream, "/data/MyFile.txt", 0777, DateTime.Now, new FileUpDownProgress<int>(), CancellationToken.None);
            }
        }

        class FileUpDownProgress<T> : IProgress<T>
        {
            T lastVaue;
            public void Report(T value)
            {
               if (value.Equals(lastVaue))
                {
                    return;
                }
                lastVaue = value;
                // the value is.
            }
        }

    }
}
