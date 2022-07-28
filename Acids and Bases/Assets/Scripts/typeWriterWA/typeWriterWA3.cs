using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class typeWriterWA3 : MonoBehaviour
{
    [SerializeField] private TMP_Text startExp; 
    [SerializeField] private TMP_Text insert; 
    private string p1 = "After an equivalence point, the acetic acid is exhausted, leaving an excess of OH- ions. This excess of OH- ions lead to an increase in pH (decrease in pOH) that will eventually level off.";
    private string p2 = "In this case, OH- is a much stronger base than Ac-, making Ac- negligible. Due to this, we calculate pOH and pH using the OH- concentration. We will get a pH of 13.523 when calculated. The reason it is not 14 is because of the final volume. Since there is more volume in the final solution, the molarity of the OH- is less. This means pOH is higher and the pH is slightly lower. As we add more OH-, the pH approaches 14.";
    private string p3 = "If you look at the graph, you will see that the past equivalence point of the weak acid and strong acid are quite similar. In both cases, you can calculate the pH by the unreacted OH-.";
    private string p4 = "At this point, the solution is pink because when basic, phenolphthalein is pink. If you have phenolphthalein in a solution and it is pink, you know the mixture is basic. If it is transparent, the mixture is acidic."; 
    // reiterate that the chloride ion is a neutral salt, so no conjugate base is being formed.
    private string p5 = "What about a weak base? Similar to weak acid titrations, it has an ideal buffer at the halfway point. Due to this, the slope is small at the halfway point. As mentioned before, the pH at equivalence is less than 7. Finally, when you go past equivalence, you use the concentration of H+ ions instead of OH- ions to find the pH, which is approaching zero. ";
    private string p6 = ""; 
    public GameObject nextButton;
    public GameObject back; 
    public GameObject explanation;   
    public GameObject nextButtonintro;
    public GameObject math; 
    public GameObject graph1; 
    public GameObject textbubbles; 
    public GameObject Beaker1; 
    public GameObject Beaker2; 
    public GameObject forwardText; 
    public GameObject forwardText2; 
    private bool done1 = false; 
    private bool done11 = false;
    private bool done12 = false; 
    private bool done13 = false; 
    private bool done2 = false;
    private bool done3 = false; 
    private bool clicked = false; 
    private bool clicked2 = false; 
    private bool goneBack = false;
    private bool goneBack2 = false;

    private bool phase1 = true; 

    private bool phase2 = false; 
    private string introexp1 = "Now that we have covered 50 ml, we will move onto the final step of the titration: adding 100 ml of NaOH."; 
    private string outexp = "Thank you for playing my Acids And Bases game! I hope you were able to understand the concepts and learn something new!"; 
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

        if(explanation.activeSelf)
        {
            if(!done1)
            {
                graph1.SetActive(false); 
                textWriterExplanation(p1,p2); 
            }
            else if(!done2)
            {
                textWriterExplanation(p3,p4); 
            }
            else if(!done3)
            {
                textWriterExplanation(p5,p6); 
            }

        }
        else if(phase2)
        {
            textWriterIntro(outexp); 
        }
    }

    public void nextStart()
    {
        if(phase1)
        {
            phase1 = false;
            i = 0; 
            startExp.text = "";  
            Beaker1.SetActive(true); 
            Beaker2.SetActive(true); 
            textbubbles.SetActive(false); 
            nextButtonintro.SetActive(false);
        }
        else if(phase2)
        {
            SceneManager.LoadScene(0); 
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
            back.SetActive(false); 
            math.SetActive(false); 
            graph1.SetActive(true); 
        }
        else if (!done1 && goneBack)
        {
            insert.text =  p3 + "\n" + "\n"+ p4;
            done1 = true; 
            i = 0; 
            math.SetActive(false); 
            graph1.SetActive(true);
        }
        else if (!done2  && !goneBack2)
        {
            i = 0; 
            done2 = true; 
            done11 = false;
            done12 = false;
            done13 = false; 
            insert.text = ""; 
            nextButton.SetActive(false);
            back.SetActive(false); 
        }
        else if (!done2 && goneBack2)
        {
            insert.text =  p5 + "\n" + "\n"+ p6;
            done2 = true; 
            i = 0; 
        }
        else if(!done3)
        {
            i = 0; 
            done3 = true; 
            phase2 = true; 
            insert.text = ""; 
            nextButton.SetActive(false);
            explanation.SetActive(false); 
            textbubbles.SetActive(true); 
            nextButtonintro.SetActive(true);
            back.SetActive(false); 
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
            insert.text = p1 + "\n" + "\n"+ p2;
            back.SetActive(false); 
            done1 = false; 
            math.SetActive(true); 
            graph1.SetActive(false); 

        }
        else if(done2 && !done3)
        {
            goneBack2 = true; 
            insert.text = p3 + "\n" + "\n"+ p4;
            done2 = false;

        }

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
