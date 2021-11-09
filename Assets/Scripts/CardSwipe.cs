using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardSwipe : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private Vector2 startPosition;
    [SerializeField] private float minSpeed=1f;
    [SerializeField] private float maxSpeed=1000f;
    [SerializeField] private float minRightDistance;
    [SerializeField] private float maxRightDistance;
    [SerializeField] private RectTransform rect;
    [SerializeField] private Canvas canvas;
    private float startTime;

    [SerializeField] private TextMeshProUGUI bottomText;
    // Start is called before the first frame update
    public void OnDrag(PointerEventData eventData){
        Vector2 swipe = eventData.delta;
        swipe.y=0f;
        swipe = rect.anchoredPosition + swipe / canvas.scaleFactor;
        swipe.x = Mathf.Clamp(swipe.x, -maxRightDistance,maxRightDistance);
        rect.anchoredPosition= swipe;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startTime = Time.time;
    }
    public void OnEndDrag(PointerEventData eventData){
        if (eventData.position.x < minRightDistance)
        {
            resetSwipe();
            return;
        }
        Vector2 path=eventData.position-startPosition;
        float cdistance=path.magnitude/canvas.scaleFactor;
        Debug.Log("Current Distance: " + cdistance);

        float cspeed= path.magnitude/(Time.time-startTime);
        // Debug.Log(startTime+ " to " + Time.time );
        Debug.Log(cspeed);
        if(cspeed<minSpeed) {
            //Too slow
            bottomText.SetText("Too Slow! Try Again");
            resetSwipe();
        }
        else if(cspeed> maxSpeed) {
            //Too Fast
            bottomText.SetText("Too Fast! Try Again");
            resetSwipe();
        }
        else swipeSuccessful();
    }

    void resetSwipe()
    {
        rect.position = Vector2.Lerp(transform.position,startPosition,2f);
    }   
    void swipeSuccessful(){
        //Send info to list of Tasks completed
        //Disable this task for future
        resetSwipe();
        bottomText.SetText("Swipe the Card");
        SelectionManager.isWorkingOnTasks = false;

    }

    void Start(){
        startPosition=transform.position;
    }

    
}
