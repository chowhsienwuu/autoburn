using System;
using System.Text;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using Autoburn.util;

namespace Autoburn.Manager
{
    public class JsonStringClientHandler : ChannelHandlerAdapter
    {
        public const string TAG = "JsonStringClientHandler";
        readonly IByteBuffer initialMessage;
       
        private NettyJsonCmdManager NettyJsonCmdManager = null;

        public JsonStringClientHandler(NettyJsonCmdManager nettyjsoncmdmanager)
        {
            NettyJsonCmdManager = nettyjsoncmdmanager;
            this.initialMessage = Unpooled.Buffer();
            byte[] messageBytes = Encoding.UTF8.GetBytes("Hello world");
            this.initialMessage.WriteBytes(messageBytes);
        }

        public override void ChannelActive(IChannelHandlerContext context)
        {
            SystemLog.I(TAG, "Netty 网络连接已建立");
            NettyJsonCmdManager.SendStringAppendDelimite("heoool?");
        }

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            //前面用了string decoder, 所以应当为
            var receiverMsg = message as string;
            
            if (DeviceManager.Instance.RxMsgDispatch != null && !string.IsNullOrEmpty(receiverMsg))
            {
                DeviceManager.Instance.RxMsgDispatch.ProcessRxMsg(receiverMsg);
            }

            ProgLog.D(TAG, "NEtty收到数据: " + receiverMsg);
        }

        public override void ChannelReadComplete(IChannelHandlerContext context) => context.Flush();

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            SystemLog.I(TAG, "Netty 网络连接 出现异常,将关闭连接 : " + exception.ToString());
            context.CloseAsync();
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            SystemLog.I(TAG, "Netty 网络连接断开");
            context.CloseAsync();
        }
    }
}