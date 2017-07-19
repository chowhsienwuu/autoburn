using Autoburn.util;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn.Manager
{
     public class NettyJsonCmdManager : IDisposable
    {
        public const string TAG = "NettyJsonCmdManager";
        public const string DelimiterString = "$$$$$$$$$$";

        public void Dispose()
        {
            ProgLog.D(TAG, ".Dispose called");
            Stop();
        }

        public void Stop()
        {
            ProgLog.D(TAG, ".Stop called");
            clientChannel?.CloseAsync();
            group?.ShutdownGracefullyAsync();
        }

        public void Start()
        {
            ProgLog.D(TAG, ".Start called");
            RunClientAsync();
        }

        private MultithreadEventLoopGroup group;
        private IChannel clientChannel;
        private JsonStringClientHandler JsonStringClientHandler = null;

        public NettyJsonCmdManager()
        {
            JsonStringClientHandler = new JsonStringClientHandler(this);
        }

        public void SendStringAppendDelimite(string args)
        {
            if (string.IsNullOrEmpty(args) || clientChannel == null || !clientChannel.Active)
            {
                //error happend.
            }
            clientChannel.WriteAndFlushAsync(args + DelimiterString);
        }

        private async Task RunClientAsync()
        {
            group = new MultithreadEventLoopGroup();
            try
            {
                var bootstrap = new Bootstrap();
                bootstrap
                    .Group(group)
                    .Channel<TcpSocketChannel>()
                    .Option(ChannelOption.TcpNodelay, true)
                    .Handler(new ActionChannelInitializer<ISocketChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline;
                        //1. set Delimiter..
                        IByteBuffer Delimiter = Unpooled.WrappedBuffer(Encoding.UTF8.GetBytes(DelimiterString));
                        DelimiterBasedFrameDecoder delimiterdecoder = new DelimiterBasedFrameDecoder(1024, Delimiter);
                        pipeline.AddLast("Delimiter", delimiterdecoder);

                        //2, add string encode and decode.
                        pipeline.AddLast("stringDecoder", new StringDecoder(Encoding.UTF8));
                        pipeline.AddLast("stringEncoder", new StringEncoder(Encoding.UTF8));

                        //add string parse.

                        pipeline.AddLast("JsonStringClientHandler", JsonStringClientHandler);
                    }));

                clientChannel = await bootstrap.ConnectAsync(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000));
            }
            finally
            {
            }
        }

    }
}
