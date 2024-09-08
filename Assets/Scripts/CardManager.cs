using System.Collections.Generic;
using UnityEngine;

public struct Card
{
    public string name;
    public string info;
    public Sprite image;
    public int attack;
    public int defence;

    public Card(string name, string info, string imagePath, int attack, int defence)
    {
        this.name = name;
        this.info = info;
        image = Resources.Load<Sprite>(imagePath);
        this.attack = attack;
        this.defence = defence;
    }
}

public static class CardList
{
    public static List<Card> AllCards = new List<Card>();
}

public class CardManager : MonoBehaviour
{
    private void Awake()
    {
        CardList.AllCards.Add(new Card("Муравей Рабочий", "Работяга", "Sprites/Cards/Муравей", 1, 1));
        CardList.AllCards.Add(new Card("Божья Коровка", "Лучше не трогать", "Sprites/Cards/Божья Коровка", 2, 3));
        CardList.AllCards.Add(new Card("Пчела", "Жужжит", "Sprites/Cards/Пчела", 3, 2));
        CardList.AllCards.Add(new Card("Светлячок", "Ослепительный", "Sprites/Cards/Светлячок", 2, 2));
        CardList.AllCards.Add(new Card("Мокрица", "Не пробьёшь!", "Sprites/Cards/Мокрица", 1, 5));
    }
}
