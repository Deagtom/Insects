using UnityEngine;
using Mirror;
using System.Collections.Generic;

public class PlayerManager : NetworkBehaviour
{
    [SyncVar] public string playerName;
    [SyncVar] public bool isReady;
    [SyncVar] public bool isFirstPlayer;

    public string imagePath;

    public Transform handTransform;
    public Transform frontFieldTransform;
    public Transform backFieldTransform;

    [SyncVar] public List<Card> hand;
    [SyncVar] public List<Card> frontField;
    [SyncVar] public List<Card> backField;

    public List<Card> deck = new List<Card>();

    private void Awake() => DontDestroyOnLoad(gameObject);

    public override void OnStartClient()
    {
        base.OnStartClient();
        LobbyManager.Instance.AssignAvatarAndButton(this);
    }

    public void InitializePlayer(Transform hand, Transform frontField, Transform backField, List<Card> playerDeck)
    {
        if (playerDeck == null)
        {
            Debug.LogError("Колода равна null");
            return;
        }

        handTransform = hand;
        frontFieldTransform = frontField;
        backFieldTransform = backField;

        SetDeck(playerDeck);

        this.hand = new List<Card>();
        this.frontField = new List<Card>();
        this.backField = new List<Card>();
    }

    [Command]
    public void CmdSetDeck(List<Card> selectedDeck)
    {
        SetDeck(selectedDeck);
        RpcSetDeck(selectedDeck);
    }

    [ClientRpc]
    private void RpcSetDeck(List<Card> selectedDeck)
    {
        if (!isServer)
        {
            SetDeck(selectedDeck);
        }
    }

    private void SetDeck(List<Card> selectedDeck)
    {
        deck.Clear();
        foreach (var card in selectedDeck)
            deck.Add(card);
    }

    [Command]
    public void CmdToggleReady()
    {
        isReady = !isReady;
        RpcToggleReady(isReady);
    }

    [ClientRpc]
    private void RpcToggleReady(bool readyStatus)
    {
        isReady = readyStatus;
        LobbyManager.Instance.CheckIfAllPlayersReady();
    }
}