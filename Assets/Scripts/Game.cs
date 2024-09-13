using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public List<Card> enemyDeck;
    public List<Card> enemyHand;
    public List<Card> enemyFrontField;
    public List<Card> enemyBackField;
    public List<Card> selfDeck;
    public List<Card> selfHand;
    public List<Card> selfFrontField;
    public List<Card> selfBackField;

    public int currentRound;
    public int selfWins;
    public int enemyWins;

    public Game()
    {
        enemyDeck = GiveDeckCard();
        selfDeck = GiveDeckCard();

        enemyHand = new List<Card>();
        selfHand = new List<Card>();

        enemyFrontField = new List<Card>();
        enemyBackField = new List<Card>();

        selfFrontField = new List<Card>();
        selfBackField = new List<Card>();
    }

    private List<Card> GiveDeckCard()
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < 10; i++)
            list.Add(CardList.AllCards[Random.Range(0, CardList.AllCards.Count)]);
        return list;
    }


    public void StartNewRound()
    {
        // Логика для начала нового раунда
        currentRound++;
        // Очистить руки и поля
    }

    public void EndRound(bool isSelfWinner)
    {
        // Логика для окончания раунда
        if (isSelfWinner)
            selfWins++;
        else
            enemyWins++;

        if (selfWins == 2 || enemyWins == 2)
        {
            // Завершение игры
        }
        else
        {
            StartNewRound();
        }
    }

    public void PassTurn()
    {
        // Логика для пасса
    }
}