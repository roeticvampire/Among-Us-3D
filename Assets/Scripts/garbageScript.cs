using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class garbageScript : MonoBehaviour,IDragHandler,IEndDragHandler
{
    private Vector2 startPosition;
    [SerializeField] private float minbottomDistance;
    [SerializeField] private float maxBottomDistance;
    [SerializeField] private RectTransform rect;
    [SerializeField] private Canvas canvas;
    void Start()
    {
        startPosition=transform.position;
    }

    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 swipe = eventData.delta;
        swipe.x=0f;
        swipe = rect.anchoredPosition + swipe / canvas.scaleFactor;
        swipe.y = Mathf.Clamp(swipe.y, -maxBottomDistance,maxBottomDistance);
        rect.anchoredPosition= swipe;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (rect.anchoredPosition.y > minbottomDistance)
        {
            resetSwipe();
            return;
        }
        //Assuming the work is done
        //TODO: Notify task is done
        resetSwipe();
        SelectionManager.isWorkingOnTasks = false;
        
        
    }
    
    
    void resetSwipe()
    {
        rect.position = Vector2.Lerp(transform.position,startPosition,2f);
    }  
    
    void swipeSuccessful(){
        //Send info to list of Tasks completed
        //Disable this task for future
        resetSwipe();
        SelectionManager.isWorkingOnTasks = false;

    }
    
}
