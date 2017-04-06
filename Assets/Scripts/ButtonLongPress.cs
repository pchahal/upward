using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonLongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField]
    [Tooltip("How long must pointer be down on this object to trigger a long press")]
    private float holdTime = 1f;
    Tweener tweener;
    RectTransform rectTransform;

    // Remove all comment tags (except this one) to handle the onClick event!
    //private bool held = false;
    //public UnityEvent onClick = new UnityEvent();

    public UnityEvent onLongPress = new UnityEvent();


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //held = false;
        InvokeRepeating("OnLongPress", 0, holdTime);

        tweener = transform.DOScale(.5f, .5f).SetLoops(-1, LoopType.Yoyo);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CancelInvoke("OnLongPress");
        tweener.Kill(true);
        rectTransform.localScale = new Vector3(1, 1, 1);

        //if (!held)
        //    onClick.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CancelInvoke("OnLongPress");
    }

    private void OnLongPress()
    {
        //held = true;
        onLongPress.Invoke();
        EventManager.Instance.PostNotification(EVENT_TYPE.ADD_BALLLOONS, this, null);
        Debug.Log("longpress");
    }


}