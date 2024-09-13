using UnityEngine;

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