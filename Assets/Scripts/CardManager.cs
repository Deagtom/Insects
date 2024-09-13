using UnityEngine;

public class CardManager : MonoBehaviour
{
    private void Awake()
    {
        CardList.AllCards.Add(new Card("Муравей Солдат", "Охранник работяг", "Sprites/Cards/Муравей Солдат", 3, 2, 0));
        CardList.AllCards.Add(new Card("Божья Коровка", "Лучше не трогать", "Sprites/Cards/Божья Коровка", 2, 3, 1));
        CardList.AllCards.Add(new Card("Пчела", "Жужжит", "Sprites/Cards/Пчела", 3, 2, 2));
        CardList.AllCards.Add(new Card("Светлячок", "Ослепительный", "Sprites/Cards/Светлячок", 2, 2, 3));
        CardList.AllCards.Add(new Card("Мокрица", "Не пробьёшь!", "Sprites/Cards/Мокрица", 1, 5, 4));
        CardList.AllCards.Add(new Card("Гусеница", "Почти Бабочка", "Sprites/Cards/Гусеница", 2, 1, 5));
        CardList.AllCards.Add(new Card("Жук Бомбардир", "Себя не подорви", "Sprites/Cards/Жук Бомбардир", 6, 2, 6));
        CardList.AllCards.Add(new Card("Моль", "Дайте поспать", "Sprites/Cards/Моль", 4, 3, 7));
        CardList.AllCards.Add(new Card("Клоп", "Воняет", "Sprites/Cards/Клоп", 5, 3, 8));
        CardList.AllCards.Add(new Card("Москит", "Любит сосать", "Sprites/Cards/Москит", 3, 2, 9));
        CardList.AllCards.Add(new Card("Орхидейный Богомол", "Не дай бог к нему подойдёшь", "Sprites/Cards/Орхидейный Богомол", 8, 6, 10));
        CardList.AllCards.Add(new Card("Оса", "Чем-то напоминает пчелу..", "Sprites/Cards/Оса", 4, 2, 11));
        CardList.AllCards.Add(new Card("Паук Ткач", "Ну и сиди на своей паутине", "Sprites/Cards/Паук Ткач", 2, 3, 12));
        CardList.AllCards.Add(new Card("Паучок", "Вырастит ли?", "Sprites/Cards/Паучок", 1, 1, 13));
        CardList.AllCards.Add(new Card("Термит Солдат", "Охранник уже других работяг", "Sprites/Cards/Термит Солдат", 3, 3, 14));
        CardList.AllCards.Add(new Card("Тля", "Вкусный", "Sprites/Cards/Тля", 0, 1, 15));
        CardList.AllCards.Add(new Card("Чёрный Бык", "Я и вижу, что не белый", "Sprites/Cards/Чёрный Бык", 6, 5, 16));
        CardList.AllCards.Add(new Card("Клещ", "Как заноза в заднице", "Sprites/Cards/Клещ", 1, 1, 17));
        CardList.AllCards.Add(new Card("Жук Долгоносик", "Вкуснее Тли", "Sprites/Cards/Жук Долгоносик", 0, 1, 18));
    }
}