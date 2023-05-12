using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] float crashTime;
    [SerializeField] AudioClip crashSFX;
    bool hasCrash = false;

    
    void OnTriggerEnter2D(Collider2D collision)
    {  
        if(collision.tag == "Ground" && hasCrash == false)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            hasCrash = true;
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScence", crashTime);
        }
    }

    void ReloadScence()
    {
        SceneManager.LoadScene(0);
    }




}
