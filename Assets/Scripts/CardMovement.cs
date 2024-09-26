using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _tooltipPanel;

    private Camera _mainCamera;
    private Vector3 _offset;

    public Transform defaultParent;
    public Transform defaultTempCardParent;
    private GameObject _tempCard;

    private static bool _isDragNow;
    public bool isDraggable;

    private void Awake()
    {
        _tooltipPanel.SetActive(false);

        _mainCamera = Camera.main;
        _tempCard = GameObject.Find("TempCard");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _offset = transform.position - _mainCamera.ScreenToWorldPoint(eventData.position);
        
        defaultParent = defaultTempCardParent = transform.parent;

        isDraggable = defaultParent.GetComponent<DropPlaceScript>().type == FieldType.FIRST_PLAYER_HAND &&
                      TurnManager.Instance.IsPlayerTurn;

        if (!isDraggable)
            return;

        _tempCard.transform.SetParent(defaultParent);
        _tempCard.transform.SetSiblingIndex(transform.GetSiblingIndex());

        transform.SetParent(defaultParent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable)
            return;

        _isDragNow = true;
        _tooltipPanel.SetActive(false);
        Vector3 newPosition = _mainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = newPosition + _offset;

        if (_tempCard.transform.parent != defaultTempCardParent)
            _tempCard.transform.SetParent(defaultTempCardParent);

        CheckPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDraggable)
            return;

        _isDragNow = false;
        transform.SetParent(defaultParent);
        transform.SetSiblingIndex(_tempCard.transform.GetSiblingIndex());

        _tempCard.transform.SetParent(GameObject.Find("Canvas").transform);
        _tempCard.transform.localPosition = new Vector3(3000, 0);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_isDragNow)
            _tooltipPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) => _tooltipPanel.SetActive(false);

    private void CheckPosition()
    {
        int newIndex = defaultTempCardParent.childCount;

        for (int i = 0; i < defaultTempCardParent.childCount; i++)
        {
            if (transform.position.x < defaultTempCardParent.GetChild(i).position.x)
            {
                newIndex = i;

                if (_tempCard.transform.GetSiblingIndex() < newIndex)
                    newIndex--;

                break;
            }
        }

        _tempCard.transform.SetSiblingIndex(newIndex);
    }
}