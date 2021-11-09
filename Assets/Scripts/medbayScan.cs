using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class medbayScan : MonoBehaviour
{
    private bool IsScanning = false;
    [SerializeField] private float scanDuration = 15f;
    [SerializeField] private Slider progressBar;


    public void startScanning()
    {
        IsScanning = true;
        progressBar.value = 0f;
    }
    void initialise()
    {
        IsScanning = false;
    }
    void Start()
    {
     initialise();   
    }

    void Update()
    {
        if (!IsScanning) return;
        if (progressBar.value >= 1f)
        {
            IsScanning = false;
            progressBar.value = 0f;
            SelectionManager.isWorkingOnTasks = false;
            return;
        }

        progressBar.value += Time.deltaTime / scanDuration;

    }
}
