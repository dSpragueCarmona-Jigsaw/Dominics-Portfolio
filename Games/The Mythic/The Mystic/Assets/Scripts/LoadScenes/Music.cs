using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Music : MonoBehaviour
{


   
    void Start()
    {
        
    }

    
    void Update()
    {

        DontDestroyOnLoad(gameObject);
        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Mystic"))
        {
            Destroy(gameObject);
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Story"))
        {
            Destroy(gameObject);
        } 
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu") && this.gameObject.name != "Menu Music(Clone)")
        {
            Destroy(gameObject);
        }
    }

}