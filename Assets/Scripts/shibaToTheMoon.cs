using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class shibaToTheMoon : MonoBehaviour,IDragHandler,IEndDragHandler
{

    private Vector2 startPosition;
    [SerializeField] private RectTransform shiba;
    [SerializeField] private RectTransform moon;
    [SerializeField] private Canvas canvas;
    [SerializeField] private float maxVerticalHeight;
    [SerializeField] private float maxHorizontalMovement;
    [SerializeField] private float maxAllowedTargetDistance;
    
    void Start()
    {
        startPosition = shiba.anchoredPosition;
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector2 swipe = eventData.delta;
        swipe = shiba.anchoredPosition + swipe / canvas.scaleFactor;
        swipe.x = Mathf.Clamp(swipe.x, -maxHorizontalMovement,maxHorizontalMovement);
        swipe.y = Mathf.Clamp(swipe.y, -maxVerticalHeight,maxVerticalHeight);
        shiba.anchoredPosition= swipe;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if ((shiba.anchoredPosition - moon.anchoredPosition).magnitude < maxAllowedTargetDistance)
        {
            shiba.anchoredPosition = startPosition;
            SelectionManager.isWorkingOnTasks = false;
        }
        else
            shiba.anchoredPosition = startPosition;


    }
    
    
}
