using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class launchSequence : MonoBehaviour
{
    private int currentlevel = 10;
    
    void initiate()
    {
        currentlevel = 10;
    }

    // Start is called before the first frame update
    public void decrementLevel(int value )
    {
        if(value!=currentlevel) return;
        GameObject.Find("/LaunchSequence/buttons/" + value).GetComponent<Button>().interactable = false;
        currentlevel--;
        if (currentlevel == 0)
        {

            //TODO: notify tasks successful
            SelectionManager.isWorkingOnTasks = false;
        }
    }
    
}
