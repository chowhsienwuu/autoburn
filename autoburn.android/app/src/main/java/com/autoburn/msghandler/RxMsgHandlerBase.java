package com.autoburn.msghandler;

import android.os.AsyncTask;
/**
 * Created by chowhsienwu on 2017/5/4.
 */
public class RxMsgHandlerBase  extends  AsyncTask<String, Void, Void> implements MsgBase{

    public static final String TAG = "RxMsgHandlerBase";
    public String Type;
    public String Msg;

    public RxMsgHandlerBase(String type){
        Type = type;
    }

    /* from AsyncTask*/
    @Override
    protected Void doInBackground(String... params) {

        return null;
    }

    // to process
}
