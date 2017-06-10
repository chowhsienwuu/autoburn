package com.autoburn.msghandler;

import android.util.Log;

/**
 * Created by chowhsienwu on 2017/5/4.
 */
public class RxMsgHandlerInfo extends RxMsgHandlerBase {
    public RxMsgHandlerInfo(){
        super(MSG_TYPE_INFO);
    }

    @Override
    protected Void doInBackground(String... params) {
        Msg = params[0];

        Log.i(TAG, " the Msg is " + Msg);
        return null;
    }
}

