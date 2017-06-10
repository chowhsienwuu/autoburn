package com.autoburn.com.autoburn.net;

import android.util.Log;

import com.autoburn.StatusChange;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

/**
 * Created by hsienwu.chow on 2017/3/28.
 */

public class CmdClientSocket {
    public static final String TAG = "zxw";
    public StatusChange mCallBack = null;

    private Socket mSocket = null;
    private InputStream mPc2Borad = null;
    private OutputStream mBorad2Pc = null;

    public CmdClientSocket(Socket sk) {
        mSocket = sk;
    }

    public void start(){
        try {
            mPc2Borad = mSocket.getInputStream();
            mBorad2Pc = mSocket.getOutputStream();
        } catch (IOException e) {
            Log.e(TAG, "socketparse error");
            e.printStackTrace();
            if (mCallBack != null){
                mCallBack.statusChange(StatusChange.TCP_CMD_NET_ERROR, null);
            }
            return;
        }
        new Thread(new Runnable() {
            @Override
            public void run() {
                Thread.currentThread().setName("NET_CMD_RX");
                receiveWork();
                Log.e(TAG, "NET_CMD_RX end");
            }
        }).start();

        Thread mSendThread = new Thread(new Runnable() {
            @Override
            public void run() {
                Thread.currentThread().setName("NET_CMD_TX");
                sendWork();
                Log.e(TAG, "NET_CMD_TX end");
            }
        });
        mSendThread.start();
    }

    private byte[] mSendBuffer = null;
    private byte[] mReceiveBuffer = new byte[1024];
    private boolean mKeepRunning = true;

    public void sendData(String str) {
        synchronized (mBorad2Pc) {
            mSendBuffer = str.getBytes();
            mBorad2Pc.notifyAll();
          //  Log.i(TAG, "sendWork notifyAll");
        }
    }

    private void sendWork() {
        Log.i(TAG, "sendWork start");
        while (mKeepRunning) {
            synchronized (mBorad2Pc) {
                boolean hasError = false;
                try {
                    mBorad2Pc.wait();
                } catch (InterruptedException e) {
                    e.printStackTrace();
                    hasError = true;
                }
                try {
                    if (mSendBuffer != null) {
                        mBorad2Pc.write(mSendBuffer);
                        Log.i(TAG, "send data " + mSendBuffer.length);
                    }
                } catch (IOException e) {
                    Log.e(TAG, "send bytes to pc error");
                    e.printStackTrace();
                    hasError = true;
                }
                if (hasError) {
                    if (mCallBack != null){
                        mCallBack.statusChange(StatusChange.TCP_CMD_NET_ERROR, null);
                    }
                    break;
                }
            }
        }
        stop();
    }

    public void stop() {
        mKeepRunning = false;
        synchronized (mBorad2Pc) {
            mBorad2Pc.notifyAll();
        }
        if (mBorad2Pc != null) {
            try {
                mBorad2Pc.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        if (mPc2Borad != null) {
            try {
                mPc2Borad.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        try {
            mSocket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    //
    private void receiveWork() {
        while (mKeepRunning) {
            int len = 0;
            boolean hasError = false;
            try {
                Log.i(TAG, "..receiveWork start" + mCallBack);
                if (mCallBack != null){
                    mCallBack.statusChange(StatusChange.TCP_CONNECT_PC_OK, new Object[]{mSocket.getInetAddress().getHostAddress().toString()});
                }
                len = mPc2Borad.read(mReceiveBuffer);
            } catch (IOException e) {
                hasError = true;
                Log.e(TAG, "receive error");
                e.printStackTrace();
            }

            Log.i(TAG, "rece len :" + len);
            if (len == 0) {
                continue;
            } else if (len < 0) { // the the connect is closed , len will < 0 as -1;
                if (mCallBack != null){
                    mCallBack.statusChange(StatusChange.TCP_CMD_NET_ERROR, null);
                }
                break;
            }else {
              //  ComService.mCmdParse.parseString(new String(mReceiveBuffer, 0, len));
                if (mCallBack != null){
                    mCallBack.statusChange(StatusChange.TCP_GET_CMD,  new Object[]{new String(mReceiveBuffer, 0, len)});
                }
            }
        }
        stop();
    }
}
