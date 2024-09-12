using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckSelectionMenu : MonoBehaviour
{
    [SerializeField] private GameObject _deckButtonPrefab;
    [SerializeField] private Transform _deckListContainer;

    private DeckManager _deckManager;

    private void Start()
    {
        _deckManager = FindFirstObjectByType<DeckManager>();

        List<string> allDecks = _deckManager.LoadAllDecks();
        DisplayDecks(allDecks);
    }

    void DisplayDecks(List<string> allDecks)
    {
        foreach (string deckName in allDecks)
        {
            GameObject deckButton = Instantiate(_deckButtonPrefab, _deckListContainer);
            deckButton.GetComponentInChildren<TextMeshProUGUI>().text = deckName;

            deckButton.GetComponent<Button>().onClick.AddListener(() => SelectDeck(deckName));
        }
    }

    void SelectDeck(string deckName)
    {
        List<Card> selectedDeck = _deckManager.LoadDeck(deckName);

        if (selectedDeck != null && selectedDeck.Count > 0)
        {
            DeckHolder.Instance.SetPlayerDeck(selectedDeck);
        }
        else
        {
            Debug.LogWarning("¬ыбранна€ колода пуста или не найдена.");
        }
    }
}