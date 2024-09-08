using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardProperty : MonoBehaviour
{
    public Card selfCard;
    public Image image;
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI info;

    public void HideCardInfo(Card card)
    {
        selfCard = card;
        image.sprite = null;
        cardName.text = "";
        info.text = "";
    }

    public void ShowCardInfo(Card card)
    {
        selfCard = card;
        image.sprite = card.image;
        image.preserveAspect = true;
        cardName.text = card.name;
        info.text = card.info;
    }

    private void Start()
    {
        //ShowCardInfo(CardList.AllCards[transform.GetSiblingIndex()]);
    }
}