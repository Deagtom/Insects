using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class DeckHolder : MonoBehaviour
{
    public static DeckHolder Instance { get; private set; }

    public List<Card> playerDeck;

    private void Awake()
    {
        Instance = this;
    }

    public void SetDeck(List<Card> selectedDeck)
    {
        playerDeck = selectedDeck;
        if (NetworkClient.active && PlayerManager.Instance != null)
        {
            PlayerManager.Instance.CmdSetDeck(selectedDeck);
        }
    }
}