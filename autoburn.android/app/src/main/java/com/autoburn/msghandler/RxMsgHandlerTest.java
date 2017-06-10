package com.autoburn.msghandler;

import android.util.Log;

/**
 * Created by chowhsienwu on 2017/5/4.
 */
public class RxMsgHandlerTest extends RxMsgHandlerBase {
    public RxMsgHandlerTest(){
        super(MSG_TYPE_TEST);
    }

    @Override
    protected Void doInBackground(String... params) {
        Msg = params[0];

        Log.i(TAG, " the Msg is " + Msg );
        return null;
    }
}

