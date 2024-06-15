using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadScenes : MonoBehaviour
{
    //variable for locked buttons
    public int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    //allows you to go through scenes
    public void LoadLevel(string Level)
    {
        SceneManager.LoadScene(Level);

    }

    //quit button
    public void Quit()
    {

        Application.Quit();


    }

    //controls locked buttons
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //moves to next level
            SceneManager.LoadScene(nextSceneLoad);

            //setting Int for indes
            if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }    
        }
    }
}