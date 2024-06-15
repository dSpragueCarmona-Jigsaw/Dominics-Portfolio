using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Lethal")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

    }
}
