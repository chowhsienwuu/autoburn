using Autoburn.util;
using Echo.Client;
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
                try
                {
                    CurrentDeviceData = AdbClient.Instance.GetDevices().First();
                    SystemLog.I(TAG, "获得设备连接:" + CurrentDeviceData.Name);
                }
                catch
                {
                    SystemLog.E(TAG, "获得设备连接错误:");
                }
            }
            ProgLog.D(TAG, "" + status.Version + ".." + status.IsRunning);

            //start moniter the devices plugin in/out event.
       //     test();
        }

        public string GetProperty(string name)
        {
            if (currentDevice != null && currentDevice.IsOnline)
            {
                return currentDevice.GetProperty(name);
            }
            return string.Empty;
        }


        private void SetAdbForward()
        {
            if (currentDeviceData != null && currentDeviceData.State.Equals(DeviceState.Online))
            {
                // f
                // stop .
                Tools.Tools.RunCmd("adb shell am broadcast -a NotifyServiceStop");

                AdbClient.Instance.RemoveAllForwards(currentDeviceData);
                AdbClient.Instance.CreateForward(currentDeviceData, "tcp:5000", "tcp:13000", true);

                Tools.Tools.RunCmd("adb shell am broadcast -a NotifyServiceStart");
                SystemLog.I(TAG, "添加ADB forward转发");
                if (index++ == 0)
                {
                    Task.Run(new Action(test
                        ));
                }
            }
        }
        private int index = 0;

        private void test()
        {
            ProgLog.D(TAG, "nettyrest");
            MYNetttyTest.Stop();
            MYNetttyTest.Start();
            // Device device = new Device(new DeviceData());
            //if (currentDevice != null && currentDevice.IsOnline)
            //{
            //  var dataprop =   currentDevice.GetProperty("viatel.device.excp.data");
            //    ProgLog.D(TAG, ".." + dataprop);
            //}
        }

        internal void Stop()
        {
            // AdbServer.Instance.Sto
            Tools.Tools.RunCmd("adb kill-server");
        }

        private DeviceData currentDeviceData = new DeviceData();
        public DeviceData CurrentDeviceData
        {
            get
            {
                return currentDeviceData;
            }
            private set
            {
                currentDeviceData = value;
                // 
                if (currentDeviceData != null && currentDeviceData.State.Equals(DeviceState.Online))
                {
                    CurrentDevice = new Device(currentDeviceData);
                    SystemLog.I(TAG, "..新建DEVICE:" + CurrentDevice.Product);

                    SetAdbForward();
                }
                else if (currentDeviceData != null && currentDeviceData.State.Equals(DeviceState.Offline))
                {
                    // not connect.
                    
                }
            }
        }

        public Device CurrentDevice
        {
            get
            {
                return currentDevice;
            }

            private set
            {
                currentDevice = value;
            }
        }

        private Device currentDevice = null;



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

        private void OnDeviceConnected(object sender, DeviceDataEventArgs e)
        {
            e.Device.State = DeviceState.Online;
            CurrentDeviceData = e.Device;

            DeviceStatusChanged?.Invoke(this, e);
            Console.WriteLine($"The device {e.Device.Name} has connected to this PC ." + e.Device.State);
        }
        private void onDeviceDisConnected(object sender, DeviceDataEventArgs e)
        {
            e.Device.State = DeviceState.Offline;
            CurrentDeviceData = e.Device;

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
