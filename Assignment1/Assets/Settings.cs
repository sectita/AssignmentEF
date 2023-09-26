using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using Unity.Collections;

public class Settings : NetworkBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    public List<Color> colors = new List<Color>();
    [SerializeField] Text playerString;

    NetworkVariable<FixedString128Bytes> playerStringSize = new NetworkVariable<FixedString128Bytes>
        ("Player-0", NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    
    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    public override void OnNetworkSpawn()
    {
        playerStringSize.Value = "Player- " + (OwnerClientId + 1);
        playerString.text = playerStringSize.Value.ToString();
        meshRenderer.material.color = colors[(int)OwnerClientId];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
