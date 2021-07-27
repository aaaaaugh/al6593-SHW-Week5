using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    private bool trigger = false; //default trigger is false
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) //if something enters the trigger
    {
        if (!trigger) //if not triggered all this stuff happens 
        {
            GameManager.instance.GetComponent<ASCIILevelLoader>().CurrentLevel++;
            trigger = true; 
        }
        //Increase the Score Property in the ASCIILevelLoader
        //that we reference through the GameManager Singleton
        //GameManager.instance.GetComponent<ASCIILevelLoader>().CurrentLevel++;
        //Debug.Log("i did th ething");
    }
    
}
