//----------------------------------------------------------------------------------------------------
// AUTHOR: Jeremy Zoitas.
//----------------------------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ScrollRect))]
public class AutoScroll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //----------------------------------------------------------------------------------------------------
    // Sets up references to other objects
    //----------------------------------------------------------------------------------------------------
    RectTransform scrollRectTransform;
    RectTransform contentPanel;
    RectTransform selectedRectTransform;
    GameObject lastSelected;

    Vector2 targetPos;

    //----------------------------------------------------------------------------------------------------
    // Use this for initialization
    //----------------------------------------------------------------------------------------------------
    void Start()
    {
        scrollRectTransform = GetComponent<RectTransform>();

        if (contentPanel == null)
            contentPanel = GetComponent<ScrollRect>().content;

        targetPos = contentPanel.anchoredPosition;
    }

    //----------------------------------------------------------------------------------------------------
    // Update is called once per frame, Checks if the mouse is over the dropdown box and if so it calls 
    // autoscroll.
    //----------------------------------------------------------------------------------------------------
    void Update()
    {
        if (!_mouseHover)
            Autoscroll();
    }

    //----------------------------------------------------------------------------------------------------
    // Checks if the mouse is hovering over and sets it to true or false, it also lets the user see what 
    // is selected in the dropdown menu and lets the user scroll with the keyboard and controller.
    //----------------------------------------------------------------------------------------------------
    public void Autoscroll()
    {
        if (contentPanel == null)
            contentPanel = GetComponent<ScrollRect>().content;

        GameObject selected = EventSystem.current.currentSelectedGameObject;

        if (selected == null)
        {
            return;
        }
        if (selected.transform.parent != contentPanel.transform)
        {
            return;
        }
        if (selected == lastSelected)
        {
            return;
        }

        selectedRectTransform = (RectTransform)selected.transform;
        targetPos.x = contentPanel.anchoredPosition.x;
        targetPos.y = -(selectedRectTransform.localPosition.y) - (selectedRectTransform.rect.height / 2);
        targetPos.y = Mathf.Clamp(targetPos.y - 140, 0, contentPanel.sizeDelta.y - scrollRectTransform.sizeDelta.y);
        contentPanel.anchoredPosition = targetPos;
        lastSelected = selected;
    }

    bool _mouseHover;
    public void OnPointerEnter(PointerEventData eventData)
    {
        _mouseHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _mouseHover = false;
    }
}
