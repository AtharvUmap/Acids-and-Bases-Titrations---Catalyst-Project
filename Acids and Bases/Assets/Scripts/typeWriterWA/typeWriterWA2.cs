using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class typeWriterWA2 : MonoBehaviour
{
    [SerializeField] private TMP_Text startExp; 
    [SerializeField] private TMP_Text insert; 
    private string p1 = "We do similar steps for the 25 ml where we first start with reacting the added NaOH with the HAc. Use the total volume and the millimoles to solve for the concentrations. We see that only Ac- is left, therefore, we know the reverse reaction will occur rather than the forward reaction. To find the Kb of the reverse reaction we take Kw/Ka.";
    private string p2 = "Then, re-establish equilibrium using x as the change. Note that this time x refers to the final concentration of OH-, so -log(x) will give you pOH and you need to subtract that from 14 to get pH. Notice that the pH at equivalence is greater than 7, go to the next slide and we will cover why this is so.";
    private string p3 = "If you look at the graph, you will also see that the pH at equivalence is greater than 7. Now, why is this the case? This is because at the equivalence point all the HAc has been turned into Ac-. The Kb of Ac- is 5.56*10^-10 as we calculated in the math. This is an extremely small value, therefore even though we establish equilibrium, more of the base will be present at equilibrium, meaning the pH will be higher.";
    private string p4 = "For a strong base, the graph is flipped like it was for strong acids and strong bases. This means that at the equivalence point for weak base titrations, the pH is less than 7. It makes sense as you have more of the acid present, and the acid is weak, therefore more of the acid will be present, reducing the pH."; 
    // reiterate that the chloride ion is a neutral salt, so no conjugate base is being formed.
    private string p5 = "The pH at equivalence being different is the reason why we changed indicators. Phenolphthalein starts changing color at about a pH of 8 and is at the midpoint of its color at a pH of 9. The pH of equivalence is 9.22 so it is quite close. The color is a more diluted pink as it hasn’t fully changed from transparent to pink.";
    private string p6 = "Note that normally indicators are used in a way that the starting point of the change is where the equivalence point is, however, we are using indicators that have the midpoint of change as the equivalence point because it helps visualize the change in pH in our experiment."; 

    public GameObject nextButton;
    public GameObject back; 
    public GameObject explanation;   
    public GameObject nextButtonintro;
    public GameObject math; 
    public GameObject PhenolEquivalence; 
    public GameObject graph; 
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

    private string introexp1 = "Now that we have covered 25 ml, we will move on to adding 50 ml. Note that this time we will reset the titration so the math is more simple to see (0 ml NaOH added before we add the 50 ml). "; 
    private string introexp2 = "Repeat the same process of mixing the two beakers to get the final solution and we will go over the math."; 


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
                PhenolEquivalence.SetActive(false); 
                graph.SetActive(false); 
                textWriterExplanation(p1,p2); 
            }
            else if(!done2)
            {
                PhenolEquivalence.SetActive(false); 
                textWriterExplanation(p3,p4); 
            }
            else if(!done3)
            {
                textWriterExplanation(p5,p6); 
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
            nextButtonintro.SetActive(false);
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
            math.SetActive(false); 
            graph.SetActive(true); 
            back.SetActive(false); 
        }
        else if (!done1 && goneBack)
        {
            insert.text =  p3 + "\n" + "\n"+ p4;
            done1 = true; 
            i = 0;
            math.SetActive(false); 
            graph.SetActive(true); 
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
            graph.SetActive(false); 
            PhenolEquivalence.SetActive(true); 
            back.SetActive(false); 
        }
        else if (!done2 && goneBack2)
        {
            insert.text =  p5 + "\n" + "\n"+ p6;
            done2 = true; 
            i = 0; 
            graph.SetActive(false); 
            PhenolEquivalence.SetActive(true); 
        }
        else if(!done3)
        {
            i = 0; 
            done3 = true; 
            insert.text = ""; 
            nextButton.SetActive(false);
            explanation.SetActive(false); 
            SceneManager.LoadScene(6); 
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
            graph.SetActive(false); 
            math.SetActive(true); 

        
        }
        else if(done2 && !done3)
        {
            goneBack2 = true; 
            insert.text = p3 + "\n" + "\n"+ p4;
            done2 = false;
            graph.SetActive(true); 
            PhenolEquivalence.SetActive(false); 

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
