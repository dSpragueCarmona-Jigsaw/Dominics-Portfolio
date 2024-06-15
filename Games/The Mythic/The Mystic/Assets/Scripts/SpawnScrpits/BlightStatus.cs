using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BlightStatus : MonoBehaviour {

    private void Start()
    {
        GetComponent<TextMeshPro>().text = "Blights : " + GM.blightTotal;
    }
}
