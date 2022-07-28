using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class typeWriterWA1 : MonoBehaviour
{
    [SerializeField] private TMP_Text startExp; 
    [SerializeField] private TMP_Text insert; 
    private string p1 = "When we add 25 ml of NaOH, the first thing we have to do is completely use the OH- (a strong base) as it is likely to react. We convert to millimoles and find the final millimoles. Then, we divide by the total volume (75ml) to get concentrations.";
    private string p2 = "Now that we have the final molarities, we need to re-establish equilibrium. Use another ICE chart with x as the change in concentration. Solve for x ([H+]) and take the -log(x) to get the pH. Notice that the x value is the same as the Ka value of acetic acid. This means the pKa (-log(Ka)) = pH at the halfway point, so you can also just solve for pKa to find pH.";
    private string p3 = "Just a side note, at 25 ml phenolphthalein doesn’t change color because it changes color from pH of 8-10.";
    private string p4 = "A buffer is a solution that resists the change in pH when OH- and H+ ions are added. They ALWAYS CONSIST of weak acids and their conjugate bases. The halfway point is the point where the solution is the best buffer as the best buffer occurs when the concentration of the conjugate base and the acid is the same. As you can see in the math to the left, we have 0.333 M of HAc and 0.333 M of Ac-."; 
    // reiterate that the chloride ion is a neutral salt, so no conjugate base is being formed.
    private string p5 = "At this point, if OH- is added, the HAc will react with it and form a little bit of the conjugate base. If H+ is added, the Ac- will react and form a bit of the acid. While there is a change, the change that occurs is much less than that if you just add H+ to water as there is already an amount of what is formed in the solution. Due to this, a buffer causes resistance to change in pH.";
    private string p6 = "Just to see how it looks on the graph, the black dot corresponds to the current position in the titration. As you can see, since it is an ideal buffer at this point, the slope of the line is small because the pH barely changes.";
    private string p7 = ""; 
    public GameObject nextButton;
    public GameObject back; 
    public GameObject explanation;   
    public GameObject nextButtonintro;
    public GameObject math; 
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
    private bool goneBack2; 

    private bool phase1 = true; 
    private bool phase2 = false; 
    private bool phase3 = false; 
    private bool phase4 = false; 
    private bool phase5 = false;
    private bool phase6 = false; 
    private string introexp1 = "Now that we have covered Strong Acids, we will move on to a Weak Acid Titration with 1M acetic acid. Since its Ka is low, acetic acid doesn't fully dissociate. Acetic acid is written as C2H3O2-, but we will use Ac- for simplicity."; 
    private string introexp2 = "Since it doesn’t fully dissociate, we use x as a value that represents the change in the concentration of the acetic acid."; 
    private string introexp3 = "Since the dissociation of the acid is modeled by the equation HAc → H+ + Ac-, when acetic acid reduces by a concentration of x, H+ and Ac- increase by a concentration of x. "; 
    private string introexp4 = "This means that the equilibrium concentrations of H+ and Ac- are x, and the value of acetic acid is the initial concentration HAc - change (1-x). "; 
    private string introexp5 = "Since the Equilibrium expression is Ka = [Products]/[Reactants], we know that Ka = (x*x)/1-x. We then use the Ka value of acetic acid to solve for x to get the final H+ concentration. x = 4.23*10^-3. pH = -log[H+] = -log[4.23*10^-3] = 2.37."; //Indicator added 

    private string introexp6 =  "Now that we have covered the starting point let's move on to adding 25 ml of NaOH. Note that the indicator for this set of titrations is different. Phenolphthalein has been added to the acetic acid."; 


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
        else if(phase3)
        {
            textWriterIntro(introexp3);
        }
        else if(phase4)
        {
            textWriterIntro(introexp4);
        }
        else if(phase5)
        {
            textWriterIntro(introexp5);
        }
        else if(phase6)
        {
            textWriterIntro(introexp6);
        }


        if(explanation.activeSelf)
        {
            if(!done1)
            {
                graph.SetActive(false);
                textWriterExplanation(p1,p2,p3); 
            }
            else if(!done2)
            {
                graph.SetActive(false);
                textWriterExplanation(p4,p5); 
            }
            else if(!done3)
            {
                textWriterExplanation(p6,p7); 
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
            phase3 = true; 
            i = 0; 
            startExp.text = "";  
            nextButtonintro.SetActive(false); 
        }
        else if (phase3)
        {
            phase3 = false;
            phase4 = true; 
            i = 0; 
            startExp.text = ""; 
            nextButtonintro.SetActive(false);
        }
        else if(phase4)
        {
            phase4 = false;
            phase5 = true; 
            i = 0; 
            startExp.text = ""; 
            nextButtonintro.SetActive(false); 
        }
        else if(phase5)
        {
            phase5 = false;
            phase6 = true;  
            i = 0; 
            startExp.text = ""; 
            nextButtonintro.SetActive(false);
        }
        else if(phase6)
        {
            phase6 = false; 
            i = 0;
            startExp.text = ""; 
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
            back.SetActive(false); 
        }
        else if (!done1 && goneBack)
        {
            insert.text =  p4 + "\n" + "\n"+ p5;
            done1 = true; 
            i = 0; 
        }
        else if (!done2 && !goneBack2)
        {
            i = 0; 
            done2 = true; 
            done11 = false;
            done12 = false;
            done13 = false; 
            insert.text = ""; 
            nextButton.SetActive(false);
            back.SetActive(false); 
            math.SetActive(false); 
            graph.SetActive(true); 
        }
        else if(!done2 && goneBack2)
        {
            insert.text =  p6 + "\n" + "\n"+ p7;
            done2 = true; 
            i = 0; 
            math.SetActive(false); 
            graph.SetActive(true); 
            
        }
        else if(!done3)
        {
            i = 0; 
            done3 = true; 
            insert.text = "";
            nextButton.SetActive(false);
            back.SetActive(false); 
            explanation.SetActive(false); 
            SceneManager.LoadScene(5); 

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
        }
        else if(done2 && !done3)
        {
            done11 = true;
            done12 = true;
            done13 = true;
            goneBack2 = true; 
            insert.text = p4 + "\n" + "\n"+ p5; 
            done2 = false; 
            math.SetActive(true);
            graph.SetActive(false); 
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
