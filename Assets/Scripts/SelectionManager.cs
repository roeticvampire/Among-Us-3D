using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Canvas copyDataCanvas;
    [SerializeField] private Canvas swipeCardCanvas;
    [SerializeField] private Canvas garbageCanvas;
    [SerializeField] private Canvas temperatureCanvas;
    [SerializeField] private Canvas launchSequenceCanvas;
    [SerializeField] private Canvas hackMainframeCanvas;
    [SerializeField] private Canvas switchesCanvas;
    [SerializeField] private Canvas medbayScanCanvas;
    [SerializeField] private Canvas shibaMoonCanvas;

    [SerializeField] private Transform player;

    public static int target;
    [SerializeField] private Text targetDisplay;
    

    [SerializeField] private Canvas defaultUICanvas;
    [SerializeField] private Image ventImage;
    [SerializeField] private Image useImage;
    [SerializeField] private Image reportImage;
    [SerializeField] private Image sabotageImage;

    
    
    private Dictionary<string, Canvas> canvasMap;
    public static bool isWorkingOnTasks;
    private bool currentState;
    [SerializeField] private string selectableTag="Selectable";
    [SerializeField] private string ventTag="Vent";
    // Start is called before the first frame update
    [SerializeField] Canvas taskScreen;
    // Update is called once per frame
   public Transform _selection=null;

   void Start()
   {
       //TODO: Reimplement this target better
       target = Random.Range(1001, 10000);
       targetDisplay.text = "Security\n" + target.ToString();
       
       
       
       canvasMap = new Dictionary<string, Canvas>();
       canvasMap["copyFiles"] = copyDataCanvas;
       canvasMap["cardSwipe"] = swipeCardCanvas;
       canvasMap["garbage"] = garbageCanvas;
       canvasMap["temperature"] = temperatureCanvas;
       canvasMap["launchsequence"] = launchSequenceCanvas;
       canvasMap["hackmainframe"] = hackMainframeCanvas;
       canvasMap["switches"] = switchesCanvas;
       canvasMap["medbayscan"] = medbayScanCanvas;
       canvasMap["shibamoon"] = shibaMoonCanvas;
        
       var color = ventImage.color;
       color.a = 0.125f; //higher than 0 otherwise it is invisible
       ventImage.color = color;
        
       color = useImage.color;
       color.a = 0.125f; //higher than 0 otherwise it is invisible
       useImage.color = color;
       color = sabotageImage.color;
       color.a = 0.125f; //higher than 0 otherwise it is invisible
       sabotageImage.color = color;
        
       color = reportImage.color;
       color.a = 0.125f; //higher than 0 otherwise it is invisible
       reportImage.color = color;

   }
    void Update()
    {
        if (isWorkingOnTasks != currentState)
        {
            if (currentState)
            {
                disableTaskUI();
            }
        }
        
        // if(Input.GetKeyDown(KeyCode.B)){
        //     outline.enabled=!outline.enabled;

            var color = ventImage.color;
            color.a = 0.125f; //higher than 0 otherwise it is invisible
            ventImage.color = color;
        
            color = useImage.color;
            color.a = 0.125f; //higher than 0 otherwise it is invisible
            useImage.color = color;
            _selection=null;
        
        
       
        
        
        Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, maxDistance:10)){
            var selection=hit.transform;
            
            //For Tak interaction
            if(selection.CompareTag(selectableTag)){
                 color = useImage.color;
                color.a = 1f; //higher than 0 otherwise it is invisible
                useImage.color = color;
                
                taskScreen = canvasMap[selection.GetComponent<Identification>().interactable];
                

                if(Input.GetKeyDown(KeyCode.C)){
                    isWorkingOnTasks=true;
                    currentState = isWorkingOnTasks;
                    taskScreen.enabled=isWorkingOnTasks;
                    defaultUICanvas.enabled = !isWorkingOnTasks;
                    Cursor.lockState=CursorLockMode.None;
                }


            }
            //Teleportation
            else if(selection.CompareTag(ventTag)){
                 color = ventImage.color;
                color.a = 1f; //higher than 0 otherwise it is invisible
                ventImage.color = color;
                _selection=selection;
                Transform ventDestination = selection.GetComponent<ventPairTarget>().VentPairTransform;
                Debug.Log(ventDestination.position) ;
                if(Input.GetKeyDown(KeyCode.V))
                {
                    player.GetComponent<CharacterController>().enabled = false;
                    player.transform.position = ventDestination.transform.position;
                    player.GetComponent<CharacterController>().enabled = true;
                }


            }
            
            
        }
        
    }
    

    public void disableTaskUI(){
        isWorkingOnTasks=false;
        currentState = false;
        taskScreen.enabled=isWorkingOnTasks;
        defaultUICanvas.enabled = !isWorkingOnTasks;
        Cursor.lockState=CursorLockMode.Locked;
    }
}
