using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Autoburn.Manager
{
    class NettyJsonCmdManager
    {
        public const string TAG = "NettyJsonCmdManager";
        public const string DelimiterString = "$$$$$$$$$$";
        public void Stop()
        {

        }

        public void Start()
        {

        }


        async Task RunClientAsync()
        {
            var group = new MultithreadEventLoopGroup();
            string targetHost = null;
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

                        pipeline.AddLast("echo", new EchoClientHandler());
                    }));

                IChannel clientChannel = await bootstrap.ConnectAsync(new IPEndPoint());

                Console.ReadLine();

                await clientChannel.CloseAsync();
            }
            finally
            {
                await group.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));
            }
        }
    }
}
