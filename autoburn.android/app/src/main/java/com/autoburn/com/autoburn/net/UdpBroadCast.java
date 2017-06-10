package com.autoburn.com.autoburn.net;

import android.support.annotation.Nullable;
import android.util.Log;

import com.autoburn.StatusChange;
import com.autoburn.config.DefaultConfig;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.InterfaceAddress;
import java.net.NetworkInterface;
import java.net.SocketException;
import java.net.UnknownHostException;
import java.util.Enumeration;
import java.util.List;

/**
 * Created by hsienwu.chow on 2017/3/27.
 */

public class UdpBroadCast implements Runnable {
    public static final String TAG = "UdpBroadCast";
    public StatusChange mCallBack = null;

    private int mPcPort = DefaultConfig.PCB_UDP_BROADCAST_PORT;
    private DatagramSocket ds = null;

    private String getBroadCastAddr(InetAddress ia) throws SocketException, UnknownHostException {
        NetworkInterface netInterface = NetworkInterface.getByInetAddress(ia);
        if (!netInterface.isLoopback() && netInterface.isUp()) {
            List<InterfaceAddress> interfaceAddresses = netInterface.getInterfaceAddresses();
            for (InterfaceAddress interfaceAddress : interfaceAddresses) {
                System.out.println(interfaceAddress.getNetworkPrefixLength());
                if (interfaceAddress.getBroadcast() != null) {
                    Log.i(TAG, interfaceAddress.getBroadcast().getHostAddress());// 输出广播地址
                    return interfaceAddress.getBroadcast().getHostAddress();
                }
            }
        }
        return "";
    }
    @Nullable
    private InetAddress getLocalIpAddress() {
        try {
            for (Enumeration<NetworkInterface> en = NetworkInterface.getNetworkInterfaces(); en.hasMoreElements(); ) {
                NetworkInterface intf = en.nextElement();
                for (Enumeration<InetAddress> enumIpAddr = intf.getInetAddresses(); enumIpAddr.hasMoreElements(); ) {
                    InetAddress inetAddress = enumIpAddr.nextElement();
                    //skip ipv6
                    if (!inetAddress.isLoopbackAddress() && !inetAddress.getHostAddress().toString().contains(":")) {
                        return inetAddress;
                    }
                }
            }
        } catch (SocketException ex) {
            Log.e(TAG, ex.toString());
        }
        return null;
    }

    private InetAddress mSelfIPAddress = null;
    private InetAddress mBroadCastAddr = null;

    @Override
    public void run() {
        while (mKeepRunning) {
            if (!mHasInit){
                init();
            }
            if (mHasInit && !mHasError) {
                String json = getBroadCastJson();
                DatagramPacket dp = new DatagramPacket(json.getBytes(), 0, json.length());
                try {
                    ds.send(dp);
                } catch (IOException e) {
                    e.printStackTrace();
                    mHasError = true;
                }
            }
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            if (mHasError && mKeepRunning){
                ds.disconnect();
                ds.close();
                mHasError = true;
                mHasInit = false;
            }
        }
        ds.disconnect();
        ds.close();
        Log.i(TAG, "udpbroadcast thread end");
    }

    public void stop(){
        mKeepRunning = false;
        ds.disconnect();
        ds.close();
    }
    private void init(){
        mSelfIPAddress = getLocalIpAddress();
        try {
            mBroadCastAddr = InetAddress.getByName(getBroadCastAddr(mSelfIPAddress));
        } catch (Exception e) {
            e.printStackTrace();
        }

        if (mSelfIPAddress == null || mBroadCastAddr == null) {
            return;
        }
        if (mCallBack != null){
            mCallBack.statusChange(StatusChange.PCB_SELF_IP, new Object[]{mSelfIPAddress.getHostAddress().toString() });
        }
        //
        DefaultConfig.PcbIPAddr = mSelfIPAddress.getHostAddress().toString();

       // Log.i(TAG, "ip: " + mSelfIPAddress.getHostAddress() + " broadcast :" + mBroadCastAddr.getHostAddress());
        try {
            ds = new DatagramSocket();
            ds.setBroadcast(true);
            ds.connect(mBroadCastAddr, mPcPort);
            mHasInit = true;
            mHasError = false;
        } catch (SocketException e) {
            e.printStackTrace();
            mHasError = false;
        }
    }

    private boolean mHasInit = false;
    private boolean mHasError = false;
    private boolean mKeepRunning = true;

    private int mMsgIndex = 1;
    private String getBroadCastJson() {
        if (mSelfIPAddress == null || mBroadCastAddr == null) {
            return "";
        }

        JSONObject jo = new JSONObject();
        try {
            jo.put("msgtype", "broadcast");
            jo.put("promt", "testpcb");
            jo.put("index", mMsgIndex++);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return jo.toString();
    }
}
