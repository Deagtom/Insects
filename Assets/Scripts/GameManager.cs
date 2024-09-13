using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Mirror;


public class GameManager : NetworkBehaviour
{
    public static GameManager Instance { get; private set; }
    private Game _currentGame;
    [SerializeField] private GameObject _cardPrefab;

    [Header("Fields")]
    [SerializeField] private Transform _selfHand;
    [SerializeField] private Transform _selfFrontField;
    [SerializeField] private Transform _selfBackField;
    [SerializeField] private Transform _enemyHand;
    [SerializeField] private Transform _enemyFrontField;
    [SerializeField] private Transform _enemyBackField;

    [Header("Turn & Time")]
    [SerializeField] private TextMeshProUGUI _turnTimeText;
    [SerializeField] private Button _endTurnButton;
    private int _turn;
    private int _turnTime;
    private Coroutine _turnCoroutine;

    private List<Card> _playerDeck;

    public bool isSelfTurn
    {
        get
        {
            return _turn % 2 == 0;
        }
    }


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (PlayerManager.Instance != null && EnemyManager.Instance != null)
        {
            SetLocalPlayer(PlayerManager.Instance);
            SetEnemyPlayer(EnemyManager.Instance);
        }

        _turn = 0;
        _playerDeck = DeckHolder.Instance.playerDeck;
        _currentGame = new Game();

        GiveHandCard(_playerDeck, _selfHand);
        GiveHandCard(_currentGame.enemyDeck, _enemyHand);

        StartNewTurn();
    }

    private void GiveHandCard(List<Card> deck, Transform hand)
    {
        int i = 0;
        while (i++ < 4)
        {
            GiveCardToHand(deck, hand);
        }
    }

    private void GiveCardToHand(List<Card> deck, Transform hand)
    {
        if (deck.Count == 0)
            return;

        Card card = deck[0];

        GameObject cardGameObject = Instantiate(_cardPrefab, hand, false);

        if (hand == _enemyHand)
            cardGameObject.GetComponent<CardProperty>().HideCardInfo(card);
        else
            cardGameObject.GetComponent<CardProperty>().ShowCardInfo(card);

        deck.RemoveAt(0);
    }

    public void ChangeTurn()
    {
        _turn++;

        _endTurnButton.interactable = isSelfTurn;

        StartNewTurn();
    }

    private void StartNewTurn()
    {
        if (_turnCoroutine != null)
            StopCoroutine(_turnCoroutine);

        if (isSelfTurn)
            GiveNewCards();

        _turnCoroutine = StartCoroutine(TurnFunc());
    }

    private void GiveNewCards()
    {
        GiveCardToHand(_currentGame.enemyDeck, _enemyHand);
        GiveCardToHand(_playerDeck, _selfHand);
    }

    private IEnumerator TurnFunc()
    {
        _turnTime = 30;
        _turnTimeText.text = _turnTime.ToString();

        if (isSelfTurn)
        {
            while (_turnTime-- > 0)
            {
                _turnTimeText.text = _turnTime.ToString();
                yield return new WaitForSeconds(1);
            }
        }
        else
        {
            while (_turnTime-- > 27)
            {
                _turnTimeText.text = _turnTime.ToString();
                yield return new WaitForSeconds(1);
            }
        }

        ChangeTurn();
    }

    public void SetLocalPlayer(PlayerManager localPlayer)
    {
        localPlayer.handTransform = _selfHand;
        localPlayer.frontFieldTransform = _selfFrontField;
        localPlayer.backFieldTransform = _selfBackField;
    }

    public void SetEnemyPlayer(EnemyManager enemyPlayer)
    {
        enemyPlayer.handTransform = _enemyHand;
        enemyPlayer.frontFieldTransform = _enemyFrontField;
        enemyPlayer.backFieldTransform = _enemyBackField;
    }
}