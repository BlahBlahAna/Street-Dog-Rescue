using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public float f;

    void Start()
    {
        f = 1;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    /* public void PlayGame()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     } */
}
