using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadScenes : MonoBehaviour
{

   

    // Use this for initialization
    void Start()
    {

    }
    
    public void Update()
    {
    
    }
    // Update is called once per frame
    public void LoadLevel(string Level)
    {

        SceneManager.LoadScene(Level);

    }
    public void Quit()
    {

        Application.Quit();


    }
}