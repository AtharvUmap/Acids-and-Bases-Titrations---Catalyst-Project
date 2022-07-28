using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    [SerializeField] Camera MainCamera;
    [SerializeField] Camera MainCamera2;  
    [SerializeField] Camera MainCamera3; 
    [SerializeField] Camera MainCamera4; 
    private float time = 0.0f; 
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main; 
        MainCamera.enabled = true;  
        MainCamera2.enabled = false; 
        MainCamera3.enabled = false; 
        MainCamera4.enabled = false; 

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; 

        if (time >= 3)
        {
            ChangeBackground(); 
            time = 0; 
        }

    }
    private void ChangeBackground()
    {
        if (MainCamera.enabled)
        {
            MainCamera2.enabled = true; 
            MainCamera.enabled = false; 
        }
        else if (MainCamera2.enabled)
        {
            MainCamera3.enabled = true; 
            MainCamera2.enabled = false;  
        }
        else if(MainCamera3.enabled)
        {
            MainCamera4.enabled = true; 
            MainCamera3.enabled = false; 
        }
        else if(MainCamera4.enabled)
        {
            MainCamera.enabled = true; 
            MainCamera4.enabled = false; 
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1); 
    }
    public void Play2()
    {
        SceneManager.LoadScene(2); 
    }
        public void Play3()
    {
        SceneManager.LoadScene(4); 
    }
}
