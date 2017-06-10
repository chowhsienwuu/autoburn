package com.autoburn.com.autoburn.net;

import android.util.Log;
import com.autoburn.ComService;
import com.autoburn.StatusChange;
import com.autoburn.config.DefaultConfig;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

/**
 * Created by hsienwu.chow on 2017/3/28.
 */

public class TcpServer implements Runnable {
    public static final String TAG = "TcpServer";
    public StatusChange mCallBack = null;

    private ServerSocket mServerSocket = null;
    int mTcpListenPort = DefaultConfig.PCB_TCP_SERVER_LISTEN_PORT;
    private Socket mClientSocket = null;

    @Override
    public void run() {
        while (mKeepRunning) {
            if (!mHasInit){
                bindTcpPort();
            }
            if (mServerSocket != null && !mServerSocket.isClosed() && mHasInit) {
                try {
                    //this will block until a client try to connect server(the borad.)
                    mClientSocket = mServerSocket.accept();
                    mClientSocket.setKeepAlive(true);
                    mClientSocket.setTcpNoDelay(true);
                } catch (IOException e) {
                    e.printStackTrace();
                    mHasError = true;
                }
            }

            if (mClientSocket != null && mClientSocket.isConnected() && !mHasError) {
                ComService.mCmdClientSocket = new CmdClientSocket(mClientSocket);
                ComService.mCmdClientSocket.mCallBack = this.mCallBack;
                ComService.mCmdClientSocket.start();
                Log.i(TAG, "accept a socket +  "  + ComService.mCmdClientSocket.mCallBack);
            }

            if (mHasError && mKeepRunning){
                disConnectTcp(); // release res. wait 1 sec to try again
                if (mCallBack != null){
                    mCallBack.statusChange(StatusChange.TCP_CONNECT_PC_ERROR, null);
                }
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                mHasInit = false;
            }
        }
        disConnectTcp();
    }

    private boolean mKeepRunning = true;
    private boolean mHasInit = false;
    private boolean mHasError = false;

    public void stop(){
        mKeepRunning = false;
        disConnectTcp();
    }

    private void disConnectTcp() {
        if (mServerSocket != null) {
            try {
                mServerSocket.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
            mServerSocket = null;
        }
        Log.i(TAG, "tcpCmdChannel disconnect ");
    }

    private void bindTcpPort() {
        if (mServerSocket == null) {
            try {
                mServerSocket = new ServerSocket(mTcpListenPort);
                mHasInit = true;
                Log.i(TAG, "tcpServer Started");
            } catch (IOException e) {
                Log.e(TAG, "bind error try other port");
                mTcpListenPort += 0;
                e.printStackTrace();
                mHasError = true;
            }
        }
    }
}
