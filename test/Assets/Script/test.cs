using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
	void Start(){
		NetManager.AddEventListener(NetManager.NetEvent.ConnectSucc, OnConnectSucc);
		NetManager.AddEventListener(NetManager.NetEvent.ConnectFail, OnConnectFail);
		NetManager.AddEventListener(NetManager.NetEvent.Close, OnConnectClose);

        NetManager.AddMsgListener("TestMsg",OnTestMsg);
		// NetManager.AddMsgListener("MsgRegister", OnMsgRegister);
		// NetManager.AddMsgListener("MsgLogin", OnMsgLogin);
		// NetManager.AddMsgListener("MsgKick", OnMsgKick);
		// NetManager.AddMsgListener("MsgGetText", OnMsgGetText);
		// NetManager.AddMsgListener("MsgSaveText", OnMsgSaveText);
	}

	void Update(){
		NetManager.Update();
	}

    public void OnConnectClick () {
		NetManager.Connect("127.0.0.1",9000);
	}

    public void OnCloseClick () {
        NetManager.Close();
    }

    //连接成功回调
	void OnConnectSucc(string err){
		Debug.Log("OnConnectSucc");

	}

	//连接失败回调
	void OnConnectFail(string err){
		Debug.Log("OnConnectFail " + err);
	}

	//关闭连接
	void OnConnectClose(string err){
		Debug.Log("OnConnectClose");
	}

    public void PingClick () {
		TestMsg msg = new TestMsg();
		NetManager.Send(msg);
	}

    public void OnTestMsg(MsgBase msgBase) {
        TestMsg msg = (TestMsg)msgBase;
        if(msg.result == 0){
			Debug.Log("0");
		}
		else{
			Debug.Log("1");
		}
    }
}
