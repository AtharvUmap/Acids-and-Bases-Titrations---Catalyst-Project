using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Rotating : MonoBehaviour
{
    [SerializeField] Camera mainCamera; 
    [SerializeField] private float rotateSpeed = 50f; 
    public int turnValue = 0; 
    private double mainCamerarotationy = -90; 
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCamerarotationy < -150 && turnValue < 0)
        {
            turnValue = 0; 
        }

        if (mainCamerarotationy > -30 && turnValue > 0)
        {
            turnValue = 0; 
        }
        mainCamerarotationy += turnValue*rotateSpeed*Time.deltaTime; 
        mainCamera.transform.Rotate(0f, turnValue*rotateSpeed*Time.deltaTime ,0f); 
      
    }

    public void RotateLeftRight(int value)
    {
        turnValue = value; 
    }
}
