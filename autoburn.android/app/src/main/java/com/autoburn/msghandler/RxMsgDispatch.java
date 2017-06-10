package com.autoburn.msghandler;

import android.util.Log;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.HashSet;

/**
 * Created by chowhsienwu on 2017/5/4.
 */
public class RxMsgDispatch {
    public static final String TAG = "RxMsgDispatch";

    public RxMsgDispatch(){
        addHandler();
    }

    private void addHandler(){
        mSupportRxMsg.clear();
        mSupportRxMsg.add(new RxMsgHandlerInfo().Type);
        mSupportRxMsg.add(new RxMsgHandlerTest().Type);
    }

    private HashSet<String> mSupportRxMsg= new HashSet<String>();

    public void stop(){
        mSupportRxMsg.clear();
    }

    public void processRxMsg(String str){
        if (str == null || str.length() < 1){
            return;
        }
        RxMsgHandlerBase rxMsgHandlerBase = null;
        try {
            JSONObject jo = new JSONObject(str);
            String msgType = null;
            msgType = jo.getString(MsgBase.MSG_TYPE_STRING);
            Log.i(TAG, "the json type is  " + msgType);
            switch (msgType) {
                case MsgBase.MSG_TYPE_INFO:
                    rxMsgHandlerBase = new RxMsgHandlerInfo();
                    break;
                case MsgBase.MSG_TYPE_TEST:
                    rxMsgHandlerBase = new RxMsgHandlerTest();
                default:
                    break;
            }
        } catch (JSONException e) {
            e.printStackTrace();
        }

        if (rxMsgHandlerBase != null){
            // parse the msg in a new asynctask
            rxMsgHandlerBase.execute(str);
        }

    }

}
