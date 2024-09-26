using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class DeckHolder : MonoBehaviour
{
    public static DeckHolder Instance { get; private set; }

    public List<Card> playerDeck = new List<Card>();

    private void Awake()
    {
        Instance = this;
    }

    public void SetDeck(List<Card> selectedDeck)
    {
        playerDeck.Clear();
        foreach (var card in selectedDeck)
        {
            playerDeck.Add(card);
        }

        if (NetworkClient.active)
        {
            PlayerManager playerManager = FindAnyObjectByType<PlayerManager>();
            playerManager.CmdSetDeck(playerDeck);
        }
    }
}