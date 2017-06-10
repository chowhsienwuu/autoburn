package com.autoburn.ftp;

import java.io.IOException;

import android.util.Log;

import com.enterprisedt.net.ftp.EventListener;
import com.enterprisedt.net.ftp.FTPException;
import com.enterprisedt.net.ftp.FileTransferClient;


/**
 * Created by hsienwu.chow on 2017/4/7.
 */

public class FtpDownUpFile implements Runnable {
    public static final String TAG = "zxw";

    public interface FTPDownUpFileStatus{
        int STATUS_INIT_OK = 0X1;
        int STATUS_RUNNING = 0x2;
        int STATUS_ERROR_ABORD = 0x3;
        void statusChange(int i);
    }

    private FTPDownUpFileStatus mstatusCallback = null;
    public void registerFTPDownUpFileStatus(FTPDownUpFileStatus f){
        mstatusCallback = f;
    }

    @Override
    public void run() {
        Log.e(TAG, " The FtpDownUpFile TID: " + Thread.currentThread().getId());
        mFileTransferClient = new FileTransferClient ();
        try {
            mFileTransferClient.setRemoteHost(mFTPServerIp);
            mFileTransferClient.setRemotePort(mFTPServerPort);
            mFileTransferClient.setUserName("anonymous");
            mFileTransferClient.setPassword("anonymous");
            mFileTransferClient.connect();
            
            if(mFTPDataTransferListener != null && mFileTransferClient.isConnected()){
            	mFileTransferClient.setEventListener(mFTPDataTransferListener);
            }

            if (mstatusCallback != null){
            }
            Log.e(TAG, "before download");
            mFileTransferClient.downloadFile(mLocalFile, mRemoteFile);
            Log.e(TAG, "end download");
        } catch (Exception e) {
            e.printStackTrace();
        }finally {
            if (mFileTransferClient == null){
                return;
            }
            try {
				mFileTransferClient.disconnect();
			} catch (FTPException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
        }
    }

    private Thread mworkThread = null;
    private FileTransferClient  mFileTransferClient = null;
    private String mFTPServerIp = null;
    private int mFTPServerPort = 0;
    private String mRemoteFile = null;
    private String mLocalFile = null;
    private EventListener mFTPDataTransferListener = null;
    public String RemoteFtpFile = null;

    public long TransFileSize = 1;
    public FtpDownUpFile(){
        mworkThread = new Thread(this);
    }

    public void start(){
        if(mworkThread != null){
            mworkThread.start();
        }
    }

    public FtpDownUpFile(String serverip, int serverport){
        this();
        mFTPServerIp = serverip;
        mFTPServerPort = serverport;
    }

    public FtpDownUpFile(String serverip, int serverport, String remoteFile, String localfile){
        this(serverip, serverport);
        mFTPServerIp = serverip;
        mFTPServerPort = serverport;
        mRemoteFile = remoteFile;
        mLocalFile = localfile;
    }

    public FtpDownUpFile(String serverip, int serverport, String remoteFile, String localfile, EventListener  ftl){
        this(serverip, serverport);
        mFTPServerIp = serverip;
        mFTPServerPort = serverport;
        mRemoteFile = remoteFile;
        mLocalFile = localfile;
        mFTPDataTransferListener = ftl;
    }

}































