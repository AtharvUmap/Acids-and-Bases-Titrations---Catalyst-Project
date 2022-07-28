using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class typeWriter2SA : MonoBehaviour
{
[SerializeField] private TMP_Text startExp; 
[SerializeField] private TMP_Text insert;     
private string p1 = "At this point of the titration, we have more OH- ions than H+ ions as the H+ ions were already exhausted as it reached the equivalence point. This means the added OH- mmol with not be affected. We can determine it is basic as Bromothymol Blue turns blue when basic.";
private string p2 = "You add 100 ml initial and 50 ml added to get a total volume of 150ml. With this, you can solve for [OH-]. 50 mmol / 150 ml = 0.333M OH-. -log[0.333] = pOH = 0.477.";
private string p3 = "pH = 14 - pOH = 14 - 0.477 = 13.523. As you add more and more OH-, the pH will reach closer and closer to 14.";
private string p4 = "Now, what if we start with a strong base and add a concentration of strong acid to it. Well, that would be the opposite of the Strong Acid curve, where you start with a high pH (high [OH-]) and then end with a low pH. "; 
    
private string p5 = "With 1M of OH- (NaOH) at the beginning, you will have a pOH of 0 or a pH of 14 (14-pOH = pH). At the equivalence point, the pH is 7 because the OH- is fully neutralized and the Kw of water is small. Finally, with more [H+] concentration, when we have added 100 ml of HCl or more, we will have a pH near and further approaching zero. ";

private string p6 = "Just to see where we are on the graph, the black dot corresponds to the point where we are past equivalence. As you can see, as the volume added increases past equivalence, the pH gets closer and closer to 14 until it levels out.";
private string p7 = " "; 

public GameObject nextButton;
public GameObject back; 
public GameObject explanation;   
public GameObject nextButtonintro; 
public GameObject textbubbles; 
public GameObject Beaker1; 
public GameObject Beaker2; 
public GameObject math; 
public GameObject Graph; 
public GameObject Graph2; 
private bool done1 = false; 
private bool done11 = false;
private bool done12 = false; 
private bool done13 = false; 
private bool done2 = false;
private bool done3 = false; 
private bool goneBack = false;
private bool goneBack2 = false; 

private bool phase1 = true; 
private bool phase2 = false; 


public GameObject forwardText; 
public GameObject forwardText2; 
private bool clicked = false;
private bool clicked2 = false;

private string introexp1 =  "Finally, the last step of the Strong Acid Titration is when you add more moles of base than that of acid. For this, we will add a further 50 ml of 1M NaOH with 100 ml of HCl + NaOH done previously."; 
private string introexp2 = "Do the same process as done when making the process reach its equivalence point: click the beakers and place them in the section."; 

    private int i = 0; 
    private double timer = 0; 


    // Start is called before the first frame update
    void Start()
    {
        Beaker1.SetActive(false);
        Beaker2.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(phase1)
        {
            textWriterIntro(introexp1); 
        }
        else if(phase2)
        {
            textWriterIntro(introexp2);
        }


        if(explanation.activeSelf)
        {
            if(!done1)
            {
                Graph2.SetActive(false); 
                Graph.SetActive(false); 
                textWriterExplanation(p1,p2,p3); 
            }
            else if(!done2)
            {
                Graph2.SetActive(false); 
                math.SetActive(false); 
                textWriterExplanation(p6,p7); 
            }
            else if(!done3)
            {
                textWriterExplanation(p4,p5); 
            }   


        }



    }

    public void nextStart()
    {
        if(phase1)
        {
            phase1 = false;
            phase2 = true; 
            i = 0; 
            startExp.text = "";  
            nextButtonintro.SetActive(false); 
        }
        else if (phase2)
        {
            phase2 = false; 
            i = 0; 
            startExp.text = "";  
            nextButtonintro.SetActive(false); 
            Beaker1.SetActive(true); 
            Beaker2.SetActive(true); 
            textbubbles.SetActive(false); 
        }

    }


    public void next()
    {
        if(!done1 && !goneBack)
        {
            insert.text = ""; 
            done1 = true; 
            done11 = false;
            done12 = false;
            done13 = false; 
            i= 0; 
            nextButton.SetActive(false);
            math.SetActive(false); 
            Graph.SetActive(true); 
        }
        else if(!done1 && goneBack)
        {
            insert.text =  p4 + "\n" + "\n"+ p5;
            done1 = true; 
            i = 0; 
            math.SetActive(false); 
            Graph.SetActive(true); 
        }
        else if(!done2 && !goneBack2)
        {
            i = 0; 
            done2 = true; 
            done11 = false;
            done12 = false;
            done13 = false; 
            insert.text = ""; 
            nextButton.SetActive(false);
            Graph.SetActive(false); 
            Graph2.SetActive(true); 
            back.SetActive(false); 
        }
        else if(!done2 && goneBack2)
        {
            insert.text =  p4 + "\n" + "\n"+ p5;
            done2 = true; 
            i = 0; 
            Graph.SetActive(false); 
            Graph2.SetActive(true); 
        }
        else if (!done3)
        {
            i = 0; 
            done2 = true; 
            done11 = false;
            done12 = false;
            done13 = false; 
            insert.text = ""; 
            nextButton.SetActive(false);
            explanation.SetActive(false); 
            SceneManager.LoadScene(4); 
        }
    }
    public void backSlide()
    {
        if(done1 && !done2)
        {
            done11 = true;
            done12 = true;
            done13 = true;
            goneBack = true; 
            insert.text = p1 + "\n" + "\n"+ p2 + "\n" + "\n"+ p3;
            back.SetActive(false); 
            done1 = false; 
            Graph.SetActive(false);
            math.SetActive(true);  
        }
        else if(done2 && !done3)
        {
            goneBack2 = true; 
            insert.text = p6;
            back.SetActive(false); 
            done12 = false;
            Graph.SetActive(true); 
            Graph2.SetActive(false); 
        }

    }


    public void forwardtext()
    {
        clicked = true; 
    }
    public void forwardtext2()
    {
        clicked2 = true; 
    }

    private void textWriterIntro(string toWrite)
    {
        if(clicked)
        {
            startExp.text = toWrite;
            clicked = false;
            forwardText.SetActive(false); 
            nextButtonintro.SetActive(true); 
            i = toWrite.Length;
        }
        else if(i < toWrite.Length)
        {
            forwardText.SetActive(true); 
            if (startExp != null)
            {
                timer -= Time.deltaTime; 
                if (timer <= 0.0)
                {
                    timer += 0.05; 
                    i++; 
                    startExp.text = toWrite.Substring(0, i);
                }
            }
        }
        else
        {
            nextButtonintro.SetActive(true); 
            forwardText.SetActive(false); 
        }
    }

    private void textWriterExplanation(string toWrite, string toWrite2, string toWrite3)
    {   
        if(clicked2)
        {
            insert.text = toWrite + "\n" + "\n"+ toWrite2 + "\n" + "\n"+ toWrite3;
            forwardText2.SetActive(false); 
            nextButton.SetActive(true); 
            done11 = true;
            done12 = true; 
            done13 = true; 
            clicked2 = false;
        }   
        else if(!done11)
        {
            forwardText2.SetActive(true); 
            if(i < toWrite.Length)
            {
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
                done11 = true;  
                i = 0; 
            }
        }
        else if(!done12)
        {
            if(i < toWrite2.Length)
            {
                if (insert != null)
                {
                    timer -= Time.deltaTime; 
                    if (timer <= 0.0)
                    {
                        timer += 0.05; 
                        i++; 
                        insert.text = toWrite + "\n" + "\n"+ toWrite2.Substring(0, i);
                    }
                }
            }
            else
            {
                done12= true; 
                i = 0; 
            }
        }
        else if(!done13)
        {
            if(i < toWrite3.Length)
            {
                if (insert != null)
                {
                    timer -= Time.deltaTime; 
                    if (timer <= 0.0)
                    {
                        timer += 0.05; 
                        i++; 
                        insert.text = toWrite + "\n" + "\n"+ toWrite2 + "\n" + "\n"+ toWrite3.Substring(0, i);
                    }
                }
            }
            else
            {
                done13= true; 
            }
        }
        else
        {
            nextButton.SetActive(true); 
            forwardText2.SetActive(false); 
        }

    }

    private void textWriterExplanation(string toWrite, string toWrite2)
    {   
        if(clicked2)
        {
            insert.text = toWrite + "\n" + "\n"+ toWrite2;
            forwardText2.SetActive(false); 
            nextButton.SetActive(true); 
            done11 = true;
            done12 = true; 
            clicked2 = false;
        }   
        else if(!done11)
        {
            forwardText2.SetActive(true); 
            if(i < toWrite.Length)
            {
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
                done11 = true;  
                i = 0; 
            }
        }
        else if(!done12)
        {
            if(i < toWrite2.Length)
            {
                if (insert != null)
                {
                    timer -= Time.deltaTime; 
                    if (timer <= 0.0)
                    {
                        timer += 0.05; 
                        i++; 
                        insert.text = toWrite + "\n" + "\n"+ toWrite2.Substring(0, i);
                    }
                }
            }
            else
            {
                done12= true; 
                i = 0; 
            }
        }
        else
        {
            nextButton.SetActive(true); 
            forwardText2.SetActive(false); 
            back.SetActive(true); 
        }

    }


}
