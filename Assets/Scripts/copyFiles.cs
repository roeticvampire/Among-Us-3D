using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class copyFiles : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Button button;
    private bool isloading = false;
    [SerializeField] private float speed;

    private void Start()
    {
        slider.value = 0f;
    }

    public void startCopying()
    {
        //function for the button to start copying
        isloading = true;
        slider.value = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (isloading==false) return;
        slider.value += Time.deltaTime / speed;
        if (slider.value >= 1f)
        {
            isloading = false;
            slider.value = 0f;
            SelectionManager.isWorkingOnTasks = false;
        }

    }
}
