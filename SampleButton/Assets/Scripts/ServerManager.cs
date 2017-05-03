using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[System.Serializable]
public enum sstatus
{
    General= 0xAAAA00,
    Busy = 0xAA0000,
    Free = 0x00AA00,
}

[System.Serializable]
public class ServerInfo
{
    public string name;
    public string ip;
    public uint port;
    public sstatus status;
}

public class ServerManager : MonoBehaviour
{
    public Button enterButton;
    public List<ServerInfo> servers;
    public SimpleObjectPool buttonObjectPool;
    public Transform contentPanel;
    public Text showServer;

    public ServerInfo currentServer= null;

    private Dictionary<string, ServerInfo> DServers = new Dictionary<string, ServerInfo>();

    void Start() {
        
        enterButton.onClick.AddListener(OnEnter);

        AddServers();
    }

    private void RemoveServers()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    static Color ConvertHexToColor( uint c)
    {  
        Color32 color;
        color.r = (byte)(c >> 16 & 0xff);
        color.g = (byte)(c >> 8 & 0xff);
        color.b = (byte)(c >> 0 & 0xff);
        color.a = 0xff;

        return color;
    }

    private void AddServers()
    {

        foreach (var item in servers)
        {

            DServers.Add(item.name, item);

            GameObject newButton = buttonObjectPool.GetObject();

            newButton.transform.SetParent(contentPanel);

            newButton.transform.localScale = Vector3.one;
            newButton.transform.localPosition = Vector3.zero;
            newButton.transform.localRotation = Quaternion.AngleAxis(0f, new Vector3(0f, 15f, 0f));
            
            ServerItem sampleButton = newButton.GetComponent<ServerItem>();
            sampleButton.Setup(item, this);

            if (currentServer.name == "")
            {
                currentServer = item;
                showServer.text = item.name;
            }
            
            var st= sampleButton.transform.Find("Status").gameObject;
            if (st != null)
            {
                st.GetComponent<Image>().color = ConvertHexToColor((uint)item.status);
            }            
        }
    }

    private void OnEnter()  {

        var serverinfo = DServers[showServer.text] as ServerInfo;

        if (serverinfo != null)
        {            
            Debug.Log(string.Format("success to enter [{0}] ip ={1}:{2}!", serverinfo.name, serverinfo.ip, serverinfo.port));
        }else
        {
            Debug.LogError(string.Format("fail to enter nill server!"));
        }
    }
}
