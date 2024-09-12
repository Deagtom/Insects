using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardProperty : MonoBehaviour
{
    public Card selfCard;
    public Image image;
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI info;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI defence;

    [SerializeField] private GameObject _hideObject;

    public void HideCardInfo(Card card)
    {
        selfCard = card;
        _hideObject.SetActive(true);
    }

    public void ShowCardInfo(Card card)
    {
        selfCard = card;
        _hideObject.SetActive(false);

        image.sprite = Resources.Load<Sprite>(card.imagePath);
        image.preserveAspect = true;
        cardName.text = card.name;
        info.text = card.info;

        attack.text = card.attack.ToString();
        defence.text = card.defence.ToString();
    }
}