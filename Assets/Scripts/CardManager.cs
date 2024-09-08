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
        CardList.AllCards.Add(new Card("������� �������", "��������", "Sprites/Cards/�������", 1, 1));
        CardList.AllCards.Add(new Card("����� �������", "����� �� �������", "Sprites/Cards/����� �������", 2, 3));
        CardList.AllCards.Add(new Card("�����", "������", "Sprites/Cards/�����", 3, 2));
        CardList.AllCards.Add(new Card("���������", "�������������", "Sprites/Cards/���������", 2, 2));
        CardList.AllCards.Add(new Card("�������", "�� ��������!", "Sprites/Cards/�������", 1, 5));
    }
}
