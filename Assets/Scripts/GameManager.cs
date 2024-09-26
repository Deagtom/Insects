using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    [SerializeField] private GameObject _cardPrefab;

    [SerializeField] [SyncVar] private Transform _firstPlayerHand;
    [SerializeField] [SyncVar] private Transform _firstPlayerFrontField;
    [SerializeField] [SyncVar] private Transform _firstPlayerBackField;
    [SerializeField] [SyncVar] private Transform _secondPlayerHand;
    [SerializeField] [SyncVar] private Transform _secondPlayerFrontField;
    [SerializeField] [SyncVar] private Transform _secondPlayerBackField;

    private PlayerManager _firstPlayer;
    private PlayerManager _secondPlayer;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        _firstPlayer = FindFirstPlayer();
        _secondPlayer = FindSecondPlayer(_firstPlayer);

        if (_firstPlayer != null && _secondPlayer != null)
        {
            SetFirstPlayer(_firstPlayer);
            SetSecondPlayer(_secondPlayer);
            GiveHandCard(_firstPlayer.deck, _firstPlayerHand);
            GiveHandCard(_secondPlayer.deck, _secondPlayerHand);

            TurnManager.Instance.StartTurn();
        }
    }
    private PlayerManager FindFirstPlayer()
    {
        foreach (var player in FindObjectsByType<PlayerManager>(FindObjectsSortMode.None))
        {
            if (player.isFirstPlayer)
            {
                return player;
            }
        }
        return null;
    }

    private PlayerManager FindSecondPlayer(PlayerManager firstPlayer)
    {
        foreach (var player in FindObjectsByType<PlayerManager>(FindObjectsSortMode.None))
        {
            if (player != firstPlayer)
            {
                return player;
            }
        }
        return null;
    }

    public void SetFirstPlayer(PlayerManager localPlayer)
    {
        localPlayer.InitializePlayer(_firstPlayerHand, _firstPlayerFrontField, _firstPlayerBackField, DeckHolder.Instance.playerDeck);
    }

    public void SetSecondPlayer(PlayerManager enemyPlayer)
    {
        enemyPlayer.InitializePlayer(_secondPlayerHand, _secondPlayerFrontField, _secondPlayerBackField, DeckHolder.Instance.playerDeck);
    }

    [Server]
    private void GiveHandCard(List<Card> deck, Transform hand)
    {
        for (int i = 0; i < 4; i++)
        {
            GiveCardToHand(deck, hand);
        }
    }

    [Server]
    private void GiveCardToHand(List<Card> deck, Transform hand)
    {
        if (deck.Count == 0)
            return;

        Card card = deck[0];
        GameObject cardGameObject = Instantiate(_cardPrefab, hand, false);
        NetworkServer.Spawn(cardGameObject);

        CardProperty cardProperty = cardGameObject.GetComponent<CardProperty>();
        if (hand == _secondPlayerHand)
            cardProperty.HideCardInfo(card);
        else
            cardProperty.ShowCardInfo(card);

        deck.RemoveAt(0);
    }

    public void StopGame()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
            NetworkManager.singleton.StopHost();
        else if (NetworkClient.isConnected)
            NetworkManager.singleton.StopClient();
        else if (NetworkServer.active)
            NetworkManager.singleton.StopServer();
    }
}