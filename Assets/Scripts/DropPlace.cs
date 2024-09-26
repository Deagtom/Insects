using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlaceScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public FieldType type;

    public void OnDrop(PointerEventData eventData)
    {
        if (type == FieldType.SECOND_PLAYER_HAND_HAND_FRONT_FIELD || type == FieldType.SECOND_PLAYER_HAND_HAND_BACK_FIELD || type == FieldType.SECOND_PLAYER_HAND_HAND)
            return;

        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();
        if (card)
            card.defaultParent = transform;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null || type == FieldType.SECOND_PLAYER_HAND_HAND_FRONT_FIELD || type == FieldType.SECOND_PLAYER_HAND_HAND_BACK_FIELD || type == FieldType.SECOND_PLAYER_HAND_HAND)
            return;

        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();

        if (card)
            card.defaultTempCardParent = transform;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();

        if (card && card.defaultTempCardParent == transform)
            card.defaultTempCardParent = card.defaultParent;
    }
}