using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class hackMainframe : MonoBehaviour
{
    private int currentValue = 0;
    private int remainingDigits=4;
    [SerializeField] private Text valueText;
    public void addValue(int value)
    {
        if (remainingDigits == 0) return;
        remainingDigits--;
        currentValue = currentValue * 10 + value;
        displayValue();
    }

    void displayValue()
    {
        string outputToShow = "";
        if(currentValue!=0)
        outputToShow += currentValue;
        for (int i = 0; i < remainingDigits; i++)
            outputToShow += 'X';

        valueText.text = outputToShow;
    }

    public void executeHack()
    {
        
        if (currentValue == SelectionManager.target)
        {
            SelectionManager.isWorkingOnTasks = false;
        }
        else
        {
            remainingDigits = 4;
            currentValue = 0;
            displayValue();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        displayValue();
    }
    
}
