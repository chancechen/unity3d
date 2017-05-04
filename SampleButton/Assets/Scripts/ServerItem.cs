using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerItem : MonoBehaviour {

    public Button btn;
    public Text current;

    private Text tipInfo;
    private Text showServer;
    private ServerManager ServerMgr;
    private string tipDes;
	// Use this for initialization
	void Start () {

        
        btn.onClick.AddListener(OnChoose);
        
        var info = GameObject.Find("Panel/Background/ChoosedServer/ChooseButton/TipInfo");
        if (info != null)
        {
            tipInfo = info.GetComponent<Text>();
            tipDes = tipInfo.text;
        }
    }

    public void OnChoose()
    {
        showServer.text = current.text;
        showServer.color = current.color;

        var desc = tipDes;
        var server= ServerMgr.GetServer( current.text );
        if (server != null)
        {
            desc = string.Format("服务器<B>{0}</B>，{1}", ServerMgr.GetStateDescName(server.status), tipDes);
        }

        tipInfo.text = desc;
        var st = btn.transform.Find("Status").gameObject;
        if (st != null)
        {
            tipInfo.color = st.GetComponent<Image>().color;
        }
    }

    public void Setup(ServerInfo info, ServerManager mgr) {

        current.text = info.name;
        showServer = mgr.showServer;
        ServerMgr = mgr;        
    }
}
