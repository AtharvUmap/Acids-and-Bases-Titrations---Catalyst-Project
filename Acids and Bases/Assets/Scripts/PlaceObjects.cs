using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlaceObjects : MonoBehaviour
{
    public GameObject heldObj; 
    public GameObject heldObj2; 
    public GameObject finalSolution; 
    public Camera mainCamera; 
    public GameObject section; 
    public GameObject periodicTable; 
    public GameObject acidStrength; 
    public GameObject rotationHandler; 
    public GameObject greyBackground; 
    public GameObject button; 
    public GameObject button2; 
    public GameObject explanation;

    private double finalSolutionrotationy; 
    private bool Selected1 = false; 
    private bool Selected2 = false; 
    private bool placed1 = false;
    private bool placed2 = false;

    // Start is called before the first frame update
    void Start()
    {
        explanation.SetActive(false); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(placed1 && placed2)
        {
            double midValue = (heldObj.transform.position.z + heldObj2.transform.position.z)/2; 
            // Debug.Log(midValue);
            if(heldObj.transform.position.z <= midValue &&  heldObj2.transform.position.z >= midValue)
            {
                heldObj.transform.Translate(0f,0f,0.01f);
                heldObj2.transform.Translate(0f,0f,-0.01f);
            }
            else
            {
                heldObj.SetActive(false);
                heldObj2.SetActive(false); 
                finalSolution.SetActive(true); 
                finalSolution.transform.Rotate(0f,0f,0.5f); 
                if(finalSolutionrotationy <= 1800)
                {
                    finalSolution.transform.Rotate(0f,10f,0f);
                    finalSolutionrotationy += 10f; 
                }
                else
                {
                    finalSolution.transform.Rotate(0f,0f,-0.5f);
                    explanation.SetActive(true); 
                    placed1  =false;
                    placed2 = false; 
                }
            }
        }

        if(!Touchscreen.current.primaryTouch.press.isPressed)
        {
            return; 
        }

        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

        Vector3 clickPositionFar =  new Vector3(touchPosition.x, touchPosition.y, mainCamera.farClipPlane); 
        Vector3 clickPositionNear = new Vector3(touchPosition.x,touchPosition.y, mainCamera.nearClipPlane); 
        Vector3 clickPosF = mainCamera.ScreenToWorldPoint(clickPositionFar); 
        Vector3 clickPosN = mainCamera.ScreenToWorldPoint(clickPositionNear); 
        Vector3 vectorBetween = clickPosF-clickPosN; 
        Vector3 direction =  vectorBetween.normalized; 

        // mainCamera.GetComponent<Transform>()


        Debug.DrawRay(clickPosN,vectorBetween,Color.green);
        RaycastHit hit; 

        Ray ray = mainCamera.ScreenPointToRay(vectorBetween); 
        //  ray is origin and direction. 
        if(Physics.Raycast(transform.position, direction, out hit, vectorBetween.magnitude))
        {
            if(hit.collider.tag == "moveable")
            {
                if(hit.transform == heldObj.transform)
                {
                    Selected1 = true; 
                }
                else if(hit.transform == heldObj2.transform)
                {
                    Selected2 = true; 
                }
                // Debug.Log(hit.collider.name);
            }            
            else if(Selected1 && hit.collider.tag == "sections")
            {
                if(heldObj.transform != hit.transform)
                {
                    heldObj.transform.Translate(-19f,0f,8f);
                    placed1 = true; 
                }
                Selected1 = false; 
                // Debug.Log(hit.collider.name);
            }
            else if(Selected2 && hit.collider.tag == "sections")
            {
                if(heldObj2.transform != hit.transform)
                {
                    heldObj2.transform.Translate(-19f,0f,-8f);
                    placed2 = true; 
                }
                Selected2 = false; 
                // Debug.Log(hit.collider.name);
            }
            else if (hit.collider.tag == "periodictable")
            {
                Selected2 = false; 
                Selected1 = false;  
                if(rotationHandler.GetComponent<Rotating>().turnValue == 0) 
                {
                    periodicTable.SetActive(true); 
                    button.SetActive(true);
                    greyBackground.SetActive(true); 

                }
            }
            else if (hit.collider.tag == "acidStrength")
            {
                Selected2 = false; 
                Selected1 = false;  
                if(rotationHandler.GetComponent<Rotating>().turnValue == 0) 
                {
                    acidStrength.SetActive(true); 
                    button2.SetActive(true);
                    greyBackground.SetActive(true); 

                }
            }
            else
            {
                Selected2 = false; 
                Selected1 = false; 
            }
        }
        
    }



    public void backToGame()
    {
        periodicTable.SetActive(false);
        acidStrength.SetActive(false); 
        button.SetActive(false);
        button2.SetActive(false);
        greyBackground.SetActive(false); 
    }


}
