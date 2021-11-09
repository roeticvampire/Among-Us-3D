using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TemperatureTask : MonoBehaviour
{
    // Start is called before the first frame update
    private int value;
    [SerializeField] private Text valueBox;
    private int oldValue;
    void Start()
    {
        value = Random.Range(1, 21);
        value*=(Random.Range(0,2)==1)?1:-1;
        oldValue = value;
        displayValue();
    }

    void displayValue()
    {
        valueBox.text = (value > 0 ? "+ " : "- ") +Math.Abs(value) + " ° F" ;
    }

    public void incrementValue()
    {
        value++;
        displayValue();
        if (value == 0)
            taskSuccessful();
    }

    public void decrementValue()
    {
        value--;
        displayValue();
        if (value == 0)
            taskSuccessful();
    }

    void taskSuccessful()
    {
        value = oldValue;
        displayValue();
        SelectionManager.isWorkingOnTasks=false;
    }
}
