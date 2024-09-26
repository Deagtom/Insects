using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeckBuilder : MonoBehaviour
{
    [SerializeField] private Transform _availableCardsContainer;
    [SerializeField] private Transform _selectedCardsContainer;
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private TextMeshProUGUI _deckSizeText;
    [SerializeField] private TextMeshProUGUI _deckName;
    [SerializeField] private DeckManager _deckManager;

    private List<Card> _availableCards;
    private List<Card> _selectedDeck;

    private const int _maxDeckSize = 10;
    private const int _maxCopiesOfCard = 3;

    private void Start()
    {
        _availableCards = CardList.AllCards;
        _selectedDeck = new List<Card>();

        ShowAvailableCards();
        UpdateDeckSizeText();
    }

    void ShowAvailableCards()
    {
        foreach (Card card in _availableCards)
        {
            GameObject cardObject = Instantiate(_cardPrefab, _availableCardsContainer);
            cardObject.GetComponent<CardMovement>().enabled = false;
            cardObject.GetComponent<CardProperty>().ShowCardInfo(card);
            cardObject.GetComponentInChildren<Button>().onClick.AddListener(() => SelectCard(card));
        }
    }

    void SelectCard(Card card)
    {
        if (_selectedDeck.Count < _maxDeckSize)
        {
            int cardCount = _selectedDeck.FindAll(c => c.id == card.id).Count;
            if (cardCount < _maxCopiesOfCard)
            {
                _selectedDeck.Add(card);
                UpdateDeckSizeText();
            }
        }
        UpdateSelectedCardsUI();
    }

    void RemoveCard(Card card)
    {
        _selectedDeck.Remove(card);
        UpdateSelectedCardsUI();
        UpdateDeckSizeText();
    }

    void UpdateSelectedCardsUI()
    {
        foreach (Transform child in _selectedCardsContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (Card card in _selectedDeck)
        {
            GameObject cardObject = Instantiate(_cardPrefab, _selectedCardsContainer);
            cardObject.GetComponent<CardProperty>().ShowCardInfo(card);

            cardObject.GetComponentInChildren<Button>().onClick.AddListener(() => RemoveCard(card));
        }
    }

    void UpdateDeckSizeText()
    {
        _deckSizeText.text = $"Размер колоды: {_selectedDeck.Count}";
    }

    public void ConfirmDeck()
    {
        if (_selectedDeck.Count < _maxDeckSize)
        {
            Debug.Log("Колода слишком мала");
            return;
        }
        if (_deckName.text.Length == 0)
        {
            Debug.Log("Назовите колоду");
            return;
        }

        _deckManager.SaveDeck(_selectedDeck, _deckName.text);
        Debug.Log("Колода сохранена.");
    }

    public void BackToMenu()
    {
        _availableCards.Clear();
        SceneManager.LoadScene("Menu");
    }
}