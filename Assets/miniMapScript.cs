using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMapScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y; 
        transform.position = newPosition;
       transform.rotation=Quaternion.Euler(90f,player.eulerAngles.y,0f); 

    }
}
