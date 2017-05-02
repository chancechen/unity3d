using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerItem : MonoBehaviour {

    public Button btn;
    public Text current;

    private Text showServer;

	// Use this for initialization
	void Start () {

        
        btn.onClick.AddListener(OnChoose);   
	}

    private void OnChoose()
    {
        showServer.text = current.text;
        showServer.color = current.color;
        
    }

    public void Setup(ServerInfo info, ServerManager mgr) {

        current.text = info.name;
        showServer = mgr.showServer;
    }
}
