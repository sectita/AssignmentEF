using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;


public class NetWorkUI : NetworkBehaviour
{
    [SerializeField] Button hostButton;
    [SerializeField] Button clientButton;
    [SerializeField] Text textClientNumbers;

    private NetworkVariable<int> numPlayers = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);

    private void Awake()
    {
        hostButton.onClick.AddListener(() => { NetworkManager.Singleton.StartHost(); });
        clientButton.onClick.AddListener(() => { NetworkManager.Singleton.StartClient(); });

    }
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        textClientNumbers.text = "connections-"+ numPlayers.Value.ToString();
        if (!IsServer) return;
        numPlayers.Value = NetworkManager.Singleton.ConnectedClients.Count;
    }
}
