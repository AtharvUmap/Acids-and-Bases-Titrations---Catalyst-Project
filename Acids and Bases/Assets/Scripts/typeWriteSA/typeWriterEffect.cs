using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 
public class typeWriterEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text startExp; 
    [SerializeField] private TMP_Text insert; 
    private string p1 = "Since HCl is a strong acid, it 100% dissociates and is unable to reform back into HCl. The same goes with NaOH, therefore, we can ignore the Na+ and Cl- ions and have a reaction with H+ and OH- ions.";
    private string p2 = "The H+ and the OH- react completely and neutralize each other. Neutralize means that they completely balance each other out, and in this case, 50 mmol of OH- reacts 100% with the 50 mmol of H+ ions.";
    private string p3 = "Since the Kw of H2O is 1 * 10-14, a really small value, it is unlikely to dissociate back to H+ and OH- ions. This means that the H+ and OH- ions will remain neutral, and that is referred to as a pH of 7. At a pH of 7, H+ and OH- concentrations are the same.";
    private string p4 = "Look at the circled part of the graph to the left. This is where we are in the titration. We can see as the curve is going from 0 ml added to 50 ml NaOH added, it initially changes extremely slowly then near equivalence shoots up. This is because when not neutralized (balanced out) the H+ concentration is still relatively high therefore the pH stays low. As it reaches closer to equivalence, the H+ gets less and less and that means pH increases rapidly."; 
    // reiterate that the chloride ion is a neutral salt, so no conjugate base is being formed.
    private string p5 = "Some of you may be wondering why the Cl- ions don't react with the H+ to form some HCl, causing the [H+] to decrease and pH to increase. Since Cl- is a conjugate of a strong acid (HCl), it is a weak base. The conjugate of anything strong is weak. Since it is a weak base, it is unlikely to react.";
    private string p6 = "Now let's come back to the Bromothymol Blue we added at the start. Bromothymol Blue is an indicator. Indicators are used in order to signify the equivalence point of a titration. Different Indicators change colors at different pH and that is why we used Bromothymol Blue. If you saw while mixing, the solution turned into a greenish color at equivalence. This is the color of Bromothymol Blue at equivalence."; 
    private string p7 = "Bromothymol Blue changes color when the pH is between 6 and 8. The midpoint of the change is approximately 7 so it is ideal for us to visualize the change in pH. It will have a greenish color at equivalence, blue color when basic, and yellow color when acidic."; 
    public GameObject nextButton;
    public GameObject back; 
    public GameObject explanation;   
    public GameObject nextButtonintro; 
    public GameObject math; 
    public GameObject BromoEquivalence; 
    public GameObject Graph; 
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
    private bool phase3 = false; 
    private bool phase4 = false; 
    private bool phase5 = false;
    private string introexp1 = "For the Strong Acid Titration, we will use 50 ml of 1M HCl (our strong acid) and 1M NaOH. The OH- ions in NaOH will be used to neutralize the H+ ions in the HCl. "; 
    private string introexp2 = "The first step in the titration is, of course, the part where you haven't added any of the NaOH. In this case, only H+ ions are present in the system, and therefore to calculate the pH we simply take the -log[1], which is 0. "; 
    private string introexp3 = "Now let's move to the equivalence point. The equivalence point is where the OH- added completely balances out the H+ (where we add 50 ml of 1M NaOH). Two beakers will be provided with the HCl and NaOH. "; 
    private string introexp4 = "To proceed with the experiment click on the beakers to select them and then click on the red-taped section in order to place them there. Don't forget to give it a good mix!"; 
    private string introexp5 = "One more thing to note is that an indicator called Bromothymol Blue is added to the HCl, making it look yellow. What it does....I'll explain that later."; 


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


        if(explanation.activeSelf)
        {
            if(!done1)
            {
                BromoEquivalence.SetActive(false); 
                Graph.SetActive(false); 
                textWriterExplanation(p1,p2,p3); 
            }
            else if(!done2)
            {
                BromoEquivalence.SetActive(false); 
                math.SetActive(false); 
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
            math.SetActive(false); 
            Graph.SetActive(true); 


        }
        else if (!done1 && goneBack)
        {
            insert.text =  p4 + "\n" + "\n"+ p5;
            done1 = true; 
            i = 0; 
            math.SetActive(false); 
            Graph.SetActive(true); 
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
            Graph.SetActive(false); 
            BromoEquivalence.SetActive(true); 
            back.SetActive(false); 
        }
        else if (!done2 && goneBack2)
        {
            insert.text =  p6 + "\n" + "\n"+ p7;
            done2 = true; 
            i = 0; 
            Graph.SetActive(false); 
            BromoEquivalence.SetActive(true); 
        }
        else if(!done3)
        {
            i = 0; 
            done3 = true; 
            insert.text = ""; 
            nextButton.SetActive(false);
            explanation.SetActive(false); 
            SceneManager.LoadScene(3); 
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
            insert.text = p1 + "\n" + "\n"+ p2 + "\n" + "\n"+ p3;
            back.SetActive(false); 
            done1 = false; 
             Graph.SetActive(false);
             math.SetActive(true);  


        
        }
        else if(done2 && !done3)
        {
            goneBack2 = true; 
            insert.text = p4 + "\n" + "\n"+ p5;
            done2 = false;
            Graph.SetActive(true); 
            BromoEquivalence.SetActive(false); 

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
