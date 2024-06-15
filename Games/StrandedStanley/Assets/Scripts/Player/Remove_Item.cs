using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove_Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        string tag = col.gameObject.tag;
        Debug.Log("hit");

        if(tag == "Player")
        {
            Destroy(gameObject);
        }

        
    }
}
