package com.autoburn;


/**
 * Created by chowhsienwu on 2017/4/19.
 */
public interface StatusChange {

    int PCB_SELF_IP = 1;

    int UDP_INIT_OK = 2;
    int UDP_ERROR = 3;

    int TCP_INIT_OK = 4;
    int TCP_ERROR = 5;
    int TCP_CONNECT_PC_OK = 6;
    int TCP_CONNECT_PC_ERROR = 7;
    int TCP_CMD_NET_ERROR = 8;
    int TCP_GET_CMD = 9;

    int FTP_INIT_OK = 100;
    int FTP_UPDATE_PROGRESS = 101;
    int FTP_END = 102;
    int FTP_ERROR = 103;

    void statusChange(int reason, Object[] oa);
}
