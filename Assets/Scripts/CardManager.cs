using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Card
{
    public string name;
    public string info;
    public string imagePath;
    public int attack;
    public int defence;
    public int id;

    public Card(string name, string info, string imagePath, int attack, int defence, int id)
    {
        this.name = name;
        this.info = info;
        this.imagePath = imagePath;
        this.attack = attack;
        this.defence = defence;
        this.id = id;
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
        CardList.AllCards.Add(new Card("������� ������", "�������� �������", "Sprites/Cards/������� ������", 3, 2, 0));
        CardList.AllCards.Add(new Card("����� �������", "����� �� �������", "Sprites/Cards/����� �������", 2, 3, 1));
        CardList.AllCards.Add(new Card("�����", "������", "Sprites/Cards/�����", 3, 2, 2));
        CardList.AllCards.Add(new Card("���������", "�������������", "Sprites/Cards/���������", 2, 2, 3));
        CardList.AllCards.Add(new Card("�������", "�� ��������!", "Sprites/Cards/�������", 1, 5, 4));
        CardList.AllCards.Add(new Card("��������", "����� �������", "Sprites/Cards/��������", 2, 1, 5));
        CardList.AllCards.Add(new Card("��� ���������", "���� �� �������", "Sprites/Cards/��� ���������", 6, 2, 6));
        CardList.AllCards.Add(new Card("����", "����� �������", "Sprites/Cards/����", 4, 3, 7));
        CardList.AllCards.Add(new Card("����", "������", "Sprites/Cards/����", 5, 3, 8));
        CardList.AllCards.Add(new Card("������", "����� ������", "Sprites/Cards/������", 3, 2, 9));
        CardList.AllCards.Add(new Card("���������� �������", "�� ��� ��� � ���� ��������", "Sprites/Cards/���������� �������", 8, 6, 10));
        CardList.AllCards.Add(new Card("���", "���-�� ���������� �����..", "Sprites/Cards/���", 4, 2, 11));
        CardList.AllCards.Add(new Card("���� ����", "�� � ���� �� ����� �������", "Sprites/Cards/���� ����", 2, 3, 12));
        CardList.AllCards.Add(new Card("������", "�������� ��?", "Sprites/Cards/������", 1, 1, 13));
        CardList.AllCards.Add(new Card("������ ������", "�������� ��� ������ �������", "Sprites/Cards/������ ������", 3, 3, 14));
        CardList.AllCards.Add(new Card("���", "�������", "Sprites/Cards/���", 0, 1, 15));
        CardList.AllCards.Add(new Card("׸���� ���", "� � ����, ��� �� �����", "Sprites/Cards/׸���� ���", 6, 5, 16));
        CardList.AllCards.Add(new Card("����", "��� ������ � �������", "Sprites/Cards/����", 1, 1, 17));
        CardList.AllCards.Add(new Card("��� ����������", "������� ���", "Sprites/Cards/��� ����������", 0, 1, 18));
    }
}