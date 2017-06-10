package com.autoburn;


import android.content.Intent;
import android.os.Handler;
import android.os.Looper;
import android.os.Message;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ProgressBar;
import android.widget.TextView;

import com.autoburn.ftp.FtpDownUpFile;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {
    public static final String TAG = "zxw";
    private Intent mIntent = null;

    private TextView mPcStatus = null;
    private TextView mSelfIp = null;
    private TextView mPcIP = null;
    public static Handler mUiHandler = null;

    FtpDownUpFile mFtpDownUpFile = null;
    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.ftptest:
                mFtpDownUpFile = new FtpDownUpFile("192.168.0.103", 21, "1.rar",
                        "/sdcard/1.rar", null);
                mFtpDownUpFile.start();
                break;
            default:
                break;
        }
    }

    class UiHandler extends Handler {


        public UiHandler(Looper mainLooper) {
            super(mainLooper);
        }

        public void handleMessage(Message msg) {
            Log.e(TAG, "in UI handleMessage : " + msg.what);
            switch (msg.what) {
                case  StatusChange.PCB_SELF_IP:
                    mSelfIp.setText("IP : " + msg.obj.toString());
                    break;
                case StatusChange.TCP_CONNECT_PC_OK:
                    mPcStatus.setText("PC status : " + "已连接PC");
                    mPcIP.setText("PC IP : " + msg.obj.toString());
                    break;
                case StatusChange.TCP_CONNECT_PC_ERROR:
                case StatusChange.TCP_ERROR:
                case StatusChange.TCP_CMD_NET_ERROR:
                    mPcStatus.setText("PC status : " + "末连接PC");
                    mPcIP.setText("PC IP : " );
                    break;
                default:
                    break;
            }
            super.handleMessage(msg);
        }
    }


    Button mFtpTest = null;
    ProgressBar mFtpProgressBar = null;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mUiHandler = new UiHandler(getMainLooper());

        mIntent = new Intent(MainActivity.this, ComService.class);
        startService(mIntent);

        mPcStatus = (TextView)findViewById(R.id.pcStatus);
        mSelfIp = (TextView)findViewById(R.id.selfip);

        mPcIP= (TextView)findViewById(R.id.clientip);
        mFtpTest = (Button)findViewById(R.id.ftptest);
        mFtpTest.setOnClickListener(this);

        mFtpProgressBar = (ProgressBar)findViewById(R.id.ftpprogressBar);

    }

}
