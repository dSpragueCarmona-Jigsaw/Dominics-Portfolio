using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
   

    public GameObject burstimage;
    public GameObject holylightimage;
    public GameObject fuelimage;
    public GameObject wrenchimage;
    public GameObject powercoreimage;
    
    public GameObject fuelLight;
    public GameObject burstLight;
    public GameObject holylightLight;
    public GameObject powercoreLight;
    public GameObject wrenchLight;

    public Button fuelbutton;
    public Button burstbutton;
    public Button holylightbutton;
    public Button powercorebutton;
    public Button wrenchbutton;

    public TextMeshProUGUI fueltxt;
    public TextMeshProUGUI bursttxt;
    public TextMeshProUGUI holylighttxt;
    public TextMeshProUGUI powercoretxt;
    public TextMeshProUGUI wrenchtxt;
    public TextMeshPro blighttxt;

    void Start()
    {

       
        


        blighttxt.text = "Blights:" + GM.blightTotal.ToString();

        if (GM.BurstPurchased == true)
        {
            bursttxt.text = "Purchased";
            burstLight.SetActive(true);
            burstimage.SetActive(true);
        }

        if (GM.FuelPurchased == true)
        {
            fueltxt.text = "Purchased";
            fuelLight.SetActive(true);
            fuelimage.SetActive(true);
        }

        if (GM.HolyLightPurchased == true)
        {
            holylighttxt.text = "Purchased";
            holylightLight.SetActive(true);
            holylightimage.SetActive(true);
        }

        if (GM.WrenchPurchased == true)
        {
            wrenchtxt.text = "Purchased";
            wrenchLight.SetActive(true);
            wrenchimage.SetActive(true);
        }

        if (GM.PowerCorePurchased == true)
        {
            powercoretxt.text = "Purchased";
            powercoreLight.SetActive(true);
            powercoreimage.SetActive(true);
        }

    }


    void Update()
    {

        if (GM.blightTotal >= 50 && GM.FuelPurchased == false)
            fuelbutton.interactable = true;

        else
            fuelbutton.interactable = false;

        if (GM.blightTotal >= 200 && GM.BurstPurchased == false)
            burstbutton.interactable = true;
        else
            burstbutton.interactable = false;

        if (GM.blightTotal >= 250 && GM.HolyLightPurchased == false)
            holylightbutton.interactable = true;
        else
            holylightbutton.interactable = false;

        if (GM.blightTotal >= 500 && GM.PowerCorePurchased == false)
            powercorebutton.interactable = true;
        else
            powercorebutton.interactable = false;

        if (GM.blightTotal >= 1000 && GM.WrenchPurchased == false)
            wrenchbutton.interactable = true;
        else
            wrenchbutton.interactable = false;
    }

    public void buyFuel()
    {

        GM.blightTotal -= 50;
        fuelbutton.interactable = false;
        GM.FuelPurchased = true;
        fueltxt.text = "Purchased";
        fuelLight.SetActive(true);
        blighttxt.text = "Blights:" + GM.blightTotal.ToString();
        fuelimage.SetActive(true);
        
    }

    public void buyburst()
    {

        GM.blightTotal -= 200;
        burstbutton.interactable = false;
        GM.BurstPurchased = true;
        bursttxt.text = "Purchased";
        burstLight.SetActive(true);
        blighttxt.text = "Blights:" + GM.blightTotal.ToString();
        burstimage.SetActive(true);
    }

    public void buyholylight()
    {

        GM.blightTotal -= 250;
        holylightbutton.interactable = false;
        GM.HolyLightPurchased = true;
        holylighttxt.text = "Purchased";
        holylightLight.SetActive(true);
        blighttxt.text = "Blights:" + GM.blightTotal.ToString();
        holylightimage.SetActive(true);
    }

    public void buypowercore()
    {

        GM.blightTotal -= 500;
        powercorebutton.interactable = false;
        GM.PowerCorePurchased = true;
        powercoretxt.text = "Purchased";
        powercoreLight.SetActive(true);
        blighttxt.text = "Blights:" + GM.blightTotal.ToString();
        powercoreimage.SetActive(true);
    }

    public void buywrench()
    {

        GM.blightTotal -= 1000;
        wrenchbutton.interactable = false;
        GM.WrenchPurchased = true;
        wrenchtxt.text = "Purchased";
        wrenchLight.SetActive(true);
        blighttxt.text = "Blights:" + GM.blightTotal.ToString();
        wrenchimage.SetActive(true);
    }
}
