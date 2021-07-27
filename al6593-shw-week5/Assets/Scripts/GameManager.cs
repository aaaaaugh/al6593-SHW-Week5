/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameTime = 10; //sets timer to 10 secs before the game ends
    
    public Text timerText;

    float timer = 0; //var set to 0

    //static variable means the value is the same for all the objects of this class type and the class itself
    public static GameManager instance; //this static var will hold the Singleton

    private int score = 0; //remember: private means that it'll stay in the script, so this can only be seen in the game manager 

    int currentLevel = 0;

    public int Score //HANDLES THE PROPERTY
    {
        get { return score;  } //what you've done is that you can't see score anywhere OUTSIDE of this script, but you can see Score 
        set
        {
            score = value;

        }  
    }
    
    bool isGame = true; //use a boolean to make a Property for the timer as well

    int targetScore = 3;
    
    public TextMesh text;  //TextMesh Component to tell you the time and the score


    void Awake() //hey look it's the Singleton INSTANCE 
    {
        if (instance == null) //instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject);  //Dont Destroy this object when you load a new scene
            instance = this;  //set instance to this object
        }
        else  //if the instance is already set to an object
        {
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0; //if you have to reset

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //fragment of the time passed since last frame
        
        timerText.text = "time: " + (int) (gameTime - timer); //will show how much time goes by
        if (gameTime < timer && isGame) //time is up but only do this if we're in the game scene
        {   isGame = false;
            SceneManager.LoadScene("GameOverScene");
            GameObject.Find("Player"); //destroy the player obj
            GameObject.Destroy(GameObject.Find("Player"));
            //gameTime = 10; //RESETS back to 10 secs
        }
    }
    }

