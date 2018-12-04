﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CollideScript : MonoBehaviour
{


    public Text collideText;

    public ParticleSystem smoke;
    
    public int crashCount = 0;
    // Use this for initialization
    void Start()
    {
        collideText.text = "";
        if (smoke.isPlaying)
        {
            collideText.text = "smoke playing";
            smoke.Stop();
        }
        crashCount = 0;
    }



    void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Obstacle")
        {
            if (!smoke.isPlaying)
            {
                //Show Smoke
                smoke.Play();
            }
            
            crashCount++;

            if (crashCount == 2)
            {
                //Show on dashboard
                SetCollideText();

                //reload scene
                Invoke("Reload", 5.0f);
                crashCount = 0;
            }

        }
        
        if (collision.gameObject.tag == "Sensor")
        {
            collideText.text = "Red light passed";
        }

    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void SetCollideText()
    {
        collideText.text = "You crashed, start again!";
    }
}
