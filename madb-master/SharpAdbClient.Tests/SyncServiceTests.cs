﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace SharpAdbClient.Tests
{
    [TestClass]
    public class SyncServiceTests : SocketBasedTests
    {
        [TestInitialize]
        public void Initialize()
        {
            // Toggle the integration test flag to true to run on an actual adb server
            // (and to build/validate the test cases), set to false to use the mocked
            // adb sockets.
            // In release mode, this flag is ignored and the mocked adb sockets are always used.
            base.Initialize(integrationTest: false, doDispose: false);
        }

        [TestMethod]
        public void StatTest()
        {
            DeviceData device = new DeviceData()
            {
                Serial = "169.254.109.177:5555",
                State = DeviceState.Online
            };

            FileStatistics value = null;

            this.RunTest(
                OkResponses(2),
                NoResponseMessages,
                Requests("host:transport:169.254.109.177:5555", "sync:"),
                SyncRequests(SyncCommand.STAT, "/fstab.donatello"),
                new SyncCommand[] { SyncCommand.STAT },
                new byte[][] { new byte[] { 160, 129, 0, 0, 85, 2, 0, 0, 0, 0, 0, 0 } },
                null,
                () =>
                {
                    using (SyncService service = new SyncService(this.Socket, device))
                    {
                        value = service.Stat("/fstab.donatello");
                    }
                });

            Assert.IsNotNull(value);
            Assert.AreEqual(UnixFileMode.Regular, value.FileMode & UnixFileMode.TypeMask);
            Assert.AreEqual(597, value.Size);
            Assert.AreEqual(DateTimeHelper.Epoch.ToLocalTime(), value.Time);
        }

        [TestMethod]
        public void GetListingTest()
        {
            DeviceData device = new DeviceData()
            {
                Serial = "169.254.109.177:5555",
                State = DeviceState.Online
            };

            List<FileStatistics> value = null;

            this.RunTest(
                OkResponses(2),
                ResponseMessages(".", "..", "sdcard0", "emulated"),
                Requests("host:transport:169.254.109.177:5555", "sync:"),
                SyncRequests(SyncCommand.LIST, "/storage"),
                new SyncCommand[] { SyncCommand.DENT, SyncCommand.DENT, SyncCommand.DENT, SyncCommand.DENT, SyncCommand.DONE },
                new byte[][]
                {
                    new byte[] { 233, 65, 0, 0, 0, 0, 0, 0, 152, 130, 56, 86 },
                    new byte[] { 237, 65, 0, 0, 0, 0, 0, 0, 152, 130, 56, 86 },
                    new byte[] { 255, 161, 0, 0, 24, 0, 0, 0, 152, 130, 56, 86 },
                    new byte[] { 109, 65, 0, 0, 0, 0, 0, 0, 152, 130, 56, 86 }
                },
                null,
                () =>
                {
                    using (SyncService service = new SyncService(device))
                    {
                        value = service.GetDirectoryListing("/storage").ToList();
                    }
                });

            Assert.AreEqual(4, value.Count);

            var time = new DateTime(2015, 11, 3, 9, 47, 4, DateTimeKind.Utc).ToLocalTime();

            var dir = value[0];
            Assert.AreEqual(".", dir.Path);
            Assert.AreEqual((UnixFileMode)16873, dir.FileMode);
            Assert.AreEqual(0, dir.Size);
            Assert.AreEqual(time, dir.Time);

            var parentDir = value[1];
            Assert.AreEqual("..", parentDir.Path);
            Assert.AreEqual((UnixFileMode)16877, parentDir.FileMode);
            Assert.AreEqual(0, parentDir.Size);
            Assert.AreEqual(time, parentDir.Time);

            var sdcard0 = value[2];
            Assert.AreEqual("sdcard0", sdcard0.Path);
            Assert.AreEqual((UnixFileMode)41471, sdcard0.FileMode);
            Assert.AreEqual(24, sdcard0.Size);
            Assert.AreEqual(time, sdcard0.Time);

            var emulated = value[3];
            Assert.AreEqual("emulated", emulated.Path);
            Assert.AreEqual((UnixFileMode)16749, emulated.FileMode);
            Assert.AreEqual(0, emulated.Size);
            Assert.AreEqual(time, emulated.Time);
        }

        [TestMethod]
        [DeploymentItem(@"fstab.bin")]
        public void PullTest()
        {
            DeviceData device = new DeviceData()
            {
                Serial = "169.254.109.177:5555",
                State = DeviceState.Online
            };

            MemoryStream stream = new MemoryStream();
            var content = File.ReadAllBytes("fstab.bin");
            var contentLength = BitConverter.GetBytes(content.Length);

            this.RunTest(
                OkResponses(2),
                ResponseMessages(),
                Requests("host:transport:169.254.109.177:5555", "sync:"),
                SyncRequests(SyncCommand.STAT, "/fstab.donatello").Union(SyncRequests(SyncCommand.RECV, "/fstab.donatello")),
                new SyncCommand[] { SyncCommand.STAT, SyncCommand.DATA, SyncCommand.DONE },
                new byte[][]
                {
                    new byte[] { 160, 129, 0, 0, 85, 2, 0, 0, 0, 0, 0, 0 },
                    contentLength,
                    content
                },
                null,
                () =>
                {
                    using (SyncService service = new SyncService(this.Socket, device))
                    {
                        service.Pull("/fstab.donatello", stream, null, CancellationToken.None);
                    }
                });

            // Make sure the data that has been sent to the stream is the expected data
            CollectionAssert.AreEqual(content, stream.ToArray());
        }

        [TestMethod]
        [DeploymentItem(@"fstab.bin")]
        public void PushTest()
        {
            DeviceData device = new DeviceData()
            {
                Serial = "169.254.109.177:5555",
                State = DeviceState.Online
            };

            Stream stream = File.OpenRead("fstab.bin");
            var content = File.ReadAllBytes("fstab.bin");
            var contentMessage = new List<byte>();
            contentMessage.AddRange(SyncCommandConverter.GetBytes(SyncCommand.DATA));
            contentMessage.AddRange(BitConverter.GetBytes(content.Length));
            contentMessage.AddRange(content);

            this.RunTest(
                OkResponses(2),
                ResponseMessages(),
                Requests("host:transport:169.254.109.177:5555", "sync:"),
                SyncRequests(
                    SyncCommand.SEND, "/sdcard/test,644",
                    SyncCommand.DONE, "1446505200"),
                new SyncCommand[] { SyncCommand.OKAY },
                null,
                new byte[][]
                {
                    contentMessage.ToArray()
                },
                () =>
                {
                    using (SyncService service = new SyncService(this.Socket, device))
                    {
                        service.Push(stream, "/sdcard/test", 0644, new DateTime(2015, 11, 2, 23, 0, 0, DateTimeKind.Utc), null, CancellationToken.None);
                    }
                });
        }
    }
}
