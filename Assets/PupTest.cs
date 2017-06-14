using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;


public class PupTest : MonoBehaviour {

    public Text theText;
    public string myString;
    WebSocket WS = new WebSocket("ws://cryptic-temple-63830.herokuapp.com");
                                    // Use this for initialization
    void Start () {
        WS.OnMessage += MyHandler;
        WS.Connect();
	}
	
	// Update is called once per frame
	void Update () {
        if (myString != "")
            AddString();
	}

    void MyHandler(object sender, MessageEventArgs e)
    {
        Debug.Log(e.Data);
        myString = e.Data;
    }

    private void OnApplicationQuit()
    {
        WS.Close();
    }

    public void AddString()
    {
        theText.text += " \n "+ myString;
        myString = "";
    }
}
