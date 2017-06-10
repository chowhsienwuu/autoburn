package com.autoburn;

import android.app.Service;
import android.content.Intent;
import android.os.Binder;
import android.os.IBinder;
import android.os.Message;
import android.util.Log;

import com.autoburn.com.autoburn.net.CmdClientSocket;
import com.autoburn.com.autoburn.net.TcpServer;
import com.autoburn.com.autoburn.net.UdpBroadCast;
import com.autoburn.msghandler.RxMsgDispatch;

public class ComService extends Service implements StatusChange{
    private static final String TAG = "zxw";

    @Override
    public void onCreate() {
        super.onCreate();
        Log.i(TAG, "comService-onCreate");
        //start tcp server
        mRxMsgDispatch = new RxMsgDispatch();
        startTcpServer();

        //udp discovery for pc.
        startUdpBroadCast();
 //    {"msgtype": "info"}

    }
    RxMsgDispatch mRxMsgDispatch;


    public static UdpBroadCast mUdpBroadCast = null;
    public static TcpServer mTcpServer = null;
    public static CmdClientSocket mCmdClientSocket = null;

    private void startUdpBroadCast() {
        mUdpBroadCast = new UdpBroadCast();
        mUdpBroadCast.mCallBack = this;
        Thread udpBroadCast = new Thread(mUdpBroadCast);
        udpBroadCast.setName("UdpBroadCast");
        udpBroadCast.start();
    }

    private void startTcpServer() {
        mTcpServer = new TcpServer();
        mTcpServer.mCallBack = this;
        Thread tcpServerThread = new Thread(mTcpServer);
        tcpServerThread.setName("TcpServer-accept");
        tcpServerThread.start();
    }


    public void stop(){
        if (mUdpBroadCast != null){
            mUdpBroadCast.stop();
        }
        if (mTcpServer != null){
            mTcpServer.stop();
        }
    }

    @Override
    public void statusChange(int reason, Object[] oa) {
        Message msg = new Message();
        msg.what = reason;
        switch (reason){
            case StatusChange.PCB_SELF_IP:
                msg.obj = oa[0];
                break;
            case StatusChange.TCP_CONNECT_PC_ERROR:
            case StatusChange.TCP_CMD_NET_ERROR:
                break;
            case StatusChange.TCP_CONNECT_PC_OK:
                msg.obj = oa[0];
                break;
            case StatusChange.TCP_GET_CMD:
                mRxMsgDispatch.processRxMsg(oa[0].toString());
                break;
            default:
                break;
        }
        Log.e(TAG, "statusChange: " + reason);
        MainActivity.mUiHandler.sendMessage(msg);
    }












    //////////////////////////////////////////////////
  
    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        Log.i(TAG, "comService-onStartCommand");
        return START_NOT_STICKY;//super.onStartCommand(intent, flags, startId);
    }
  
    @Override
    public IBinder onBind(Intent intent) {
        Log.i(TAG, "comService-onBind");
        return new comBuild();
    }  
      
    @Override
    public void onDestroy() {  
        Log.i(TAG, "comService-onDestroy");
        super.onDestroy();
    }



    public class comBuild extends Binder {
        public ComService getComService()  
        {  
            return ComService.this;  
        }  
    }
}  

