using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switches : MonoBehaviour
{

    private int turnedOff = 0;
    [SerializeField]private List<bool> switchStates;
    
    [SerializeField] private List<Image> switchesList;
    
    [SerializeField] private Sprite switchGreen;
    [SerializeField] private Sprite switchRed;


    void initialise()
    {
        // switchStates = new List<bool>(8);
        for (int i = 0; i < 8; i++)
        {
            switchStates[i] = Random.Range(0, 2)==1;
            if (switchStates[i])
                switchesList[i].sprite = switchGreen;
            else
            {
                switchesList[i].sprite = switchRed;
                turnedOff++;
            }
        
        }
        //to prevent random snippet from generating pre-solved configuration
        if (turnedOff != 0) return;
        turnedOff = 2;
        switchesList[2].sprite = switchRed;
        switchStates[2] = false;
            
        switchesList[5].sprite = switchRed;
        switchStates[5] = false;


    }


    public void toggle(int index)
    {
        if (switchStates[index]) turnedOff++;
        else turnedOff--;
        switchStates[index] = !switchStates[index];
        switchesList[index].sprite = switchStates[index] ? switchGreen : switchRed;
        
        if (turnedOff == 0)
        {
            //TODO: implement task Successful
            SelectionManager.isWorkingOnTasks = false;
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        initialise();

    }

}
