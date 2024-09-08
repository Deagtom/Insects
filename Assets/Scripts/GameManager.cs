using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Game
{
    public List<Card> enemyDeck;
    private List<Card> _enemyHand;
    private List<Card> _enemyField;
    public List<Card> selfDeck;
    private List<Card> _selfHand;
    private List<Card> _selfField;

    public Game()
    {
        enemyDeck = GiveDeckCard();
        selfDeck = GiveDeckCard();

        _enemyHand = new List<Card>();
        _selfHand = new List<Card>();

        _enemyField = new List<Card>();
        _selfField = new List<Card>();
    }

    private List<Card> GiveDeckCard()
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < 10; i++)
            list.Add(CardList.AllCards[Random.Range(0, CardList.AllCards.Count)]);
        return list;
    }
}

public class GameManager : MonoBehaviour
{
    private Game _currentGame;
    [SerializeField] private Transform _enemyHand;
    [SerializeField] private Transform _selfHand;
    [SerializeField] private GameObject _cardPrefab;

    private int _turn;
    private int _turnTime;
    [SerializeField] private TextMeshProUGUI _turnTimeText;
    [SerializeField] private Button _endTurnButton;

    private Coroutine _turnCoroutine;

    public bool isSelfTurn
    {
        get
        {
            return _turn % 2 == 0;
        }
    }

    private void Start()
    {
        _turn = 0;

        _currentGame = new Game();
        GiveHandCard(_currentGame.selfDeck, _selfHand);
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
        GiveCardToHand(_currentGame.selfDeck, _selfHand);
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
}