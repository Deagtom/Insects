using UnityEngine;
using Mirror;
using System.Collections.Generic;

public class PlayerManager : NetworkBehaviour
{
    public Transform handTransform;
    public Transform frontFieldTransform;
    public Transform backFieldTransform;

    public static PlayerManager Instance { get; private set; }

    [SyncVar] 
    public List<Card> playerDeck;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        if (!isLocalPlayer)
            this.enabled = false;
        else
            GameManager.Instance.SetLocalPlayer(this);
    }

    [Command]
    public void CmdSetDeck(List<Card> selectedDeck)
    {
        playerDeck = selectedDeck;

        RpcSetDeck(selectedDeck);
    }

    [ClientRpc]
    void RpcSetDeck(List<Card> selectedDeck)
    {
        playerDeck = selectedDeck;
    }
}