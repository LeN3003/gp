using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
       // SceneManager.LoadScene("Main");//1st way
       // SceneManager.LoadScene(1);//2nd way
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);//3rd way
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
