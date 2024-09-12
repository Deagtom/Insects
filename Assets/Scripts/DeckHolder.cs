using System.Collections.Generic;
using UnityEngine;

public class DeckHolder : MonoBehaviour
{
    public static DeckHolder Instance { get; private set; }

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

    public void SetPlayerDeck(List<Card> deck) => playerDeck = deck;
}
