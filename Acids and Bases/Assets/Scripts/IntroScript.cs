using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class IntroScript : MonoBehaviour
{

    [SerializeField] private TMP_Text insert; 
    private string IntroText = "Hello! You must be here to learn about Acids and Bases (Titrations and Buffers). We will do the titration labs of Strong and Weak Acids and Bases.";
    private string IntroText2 = "To start, let's take a quick tour of the room and the resources available in them. "; 
    private string periodicLook = "The first of your materials is the periodic table. The first column is known as the Group I metals or Alkali Metals, Group II is referred to as Alkali Earth Metals, Group 17 is known as Halogens, and Group 18 is known as the noble gases.  ";
    private string periodicLook2= "The metals in the middle are known as transition metals. One thing at the top of the table is the list of polyatomic ions. While this is on this table, it won't be on the AP periodic table, so make sure to be familiar with them.";
    private string board = "Moving on, this board will have the key terms and equations you should know when solving titrations. Some concepts like buffers and equivalence point will be gone over later, so don't worry too much if you are unfamiliar with them."; 
    private string acidStrengthLook = "Finally, this is the Acid Strength Chart. This gives you the Ka value of different acids and tells you how likely an acid is to dissociate (break apart). Click on this chart or the periodic table to zoom in on them.";

    private string transition = "Now that the tour is over, let's move on to the simplest of the titrations: the Strong Acid Titration."; 
    public GameObject nextButton; 
    public GameObject forwardText;
    private bool clicked = false; 
    public Camera mainCamera; 
    public Camera mainCamera2; 
    public Camera mainCamera3;
    public Camera mainCamera4; 
    private double stopPointBoard = 30; 
    private double stopPointBoard2; 

    private int i = 0; 
    private double timer = 0; 
    private bool phase1 = true; 
    private bool phase2 = false; 
    private bool phase3 = false; 
    private bool phase31 = false; 
    private bool phase311 = false; 
    private bool phase32 = false;
    private bool phase33 = false; 
    private bool phase34 = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.enabled = true;
        mainCamera2.enabled = false;
        mainCamera3.enabled = false;
        mainCamera4.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(phase1)
        {
            textWriter(IntroText);
        }
        else if(phase2)
        {
            textWriter(IntroText2); 
        }
        else if (phase3)
        {
            if(phase31)
            {
                textWriter(periodicLook); 
            }
            else if (phase311)
            {
                textWriter(periodicLook2); 
            }
            else if(phase32)
            {
                if(stopPointBoard > -25)
                {
                    mainCamera3.transform.Translate(-0.5f,0,0); 
                    stopPointBoard -= 0.5; 
                    stopPointBoard2 = stopPointBoard; 
                }
                else if(stopPointBoard2 < 0)
                {
                    mainCamera3.transform.Translate(0.4f,0,-0.3f); 
                    stopPointBoard2 += 0.4; 
                }
                textWriter(board);
            }
            else if(phase33)
            {
                textWriter(acidStrengthLook); 
            }
            else if (phase34)
            {
                textWriter(transition); 
            }
        }

    }

    public void forwardtext()
    {
        clicked = true; 
    }
    public void next()
    {
        if(phase1)
        {
            phase1 = false;
            phase2 = true; 
            i = 0; 
            insert.text = "";  
            nextButton.SetActive(false); 
        }
        else if (phase2)
        {
            phase2 = false;
            phase3 = true; 
            phase31 = true; 
            i = 0; 
            insert.text = "";  
            nextButton.SetActive(false); 
            mainCamera.enabled = false;
            mainCamera2.enabled = true;
            
        }
        else if (phase3)
        {
            if(phase31)
            {
                phase31 = false;
                phase311 = true; 
                i = 0; 
                nextButton.SetActive(false); 
                insert.text = "";  
            }
            else if(phase311)
            {
                phase311 = false;
                phase32 = true; 
                i = 0; 
                mainCamera2.enabled = false;
                mainCamera3.enabled = true;
                nextButton.SetActive(false);
                insert.text = "";   
            }
            else if(phase32)
            {
                phase32 = false;
                phase33 = true; 
                i = 0; 
                mainCamera3.enabled = false;
                mainCamera4.enabled = true;
                nextButton.SetActive(false);
                insert.text = "";   
            }
            else if(phase33)
            {
                phase33 = false;
                phase34 = true; 
                i = 0; 
                nextButton.SetActive(false); 
                insert.text = "";  
            }
            else if(phase34)
            {
                i = 0; 
                phase34 = false; 
                phase3 = false; 
                SceneManager.LoadScene(2); 
            }


        }
    }

    private void textWriter(string toWrite)
    {
        if(clicked)
        {
            insert.text = toWrite;
            clicked = false;
            forwardText.SetActive(false); 
            nextButton.SetActive(true); 
            i = toWrite.Length;
        }
        else if(i < toWrite.Length)
        {
            forwardText.SetActive(true); 
            if (insert != null)
            {
                timer -= Time.deltaTime; 
                if (timer <= 0.0)
                {
                    timer += 0.05; 
                    i++; 
                    insert.text = toWrite.Substring(0, i);
                }
            }
        }
        else
        {
            nextButton.SetActive(true); 
            forwardText.SetActive(false); 
        }
    }


}
