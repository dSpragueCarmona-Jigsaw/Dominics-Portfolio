using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GM : MonoBehaviour
{
    public static bool FuelPurchased;
    public static bool BurstPurchased;
    public static bool HolyLightPurchased;
    public static bool PowerCorePurchased;
    public static bool WrenchPurchased;
    public static float vertVel = 0;
    public static int blightTotal = 0;
    public static float timeTotal = 0;
    public float waittoload = 0;
    public float waittoloadDeath = 0;
    public int SceneTotal = 0;

    public static float zVelAdj = 3f;

    public float zScenePos = 45;

    public static string lvlCompStatus = "Restart";

    public Transform WormholeObj;
    public Transform blightObj;
    public Transform asteroidObj;
    public Transform laserObj;
    public Transform fuelObj;
    public Transform burstObj;
    public Transform holylightObj;
    public Transform powercoreObj;
    public Transform wrenchObj;
    public List<Vector3> SpotsToGo = new List<Vector3>();


    public int randNum;
    public int asteroidpercentagebase = 60;
    public int laserprecentagebase = 10;
    public int blightspercentagebase = 22;
    public int fuelpercentagebase = 2;
    public int burstpercentagebase = 2;
    public int holypercentagebase = 1;
    public int powercorepercentagebase = 2;
    public int wrenchpercetagebase = 1;

    // Use this for initialization
    void Start()
    {

        SpotsToGo.Add(new Vector3(3, 5f, 0));
        SpotsToGo.Add(new Vector3(2, 5f, 0));
        SpotsToGo.Add(new Vector3(1, 5f, 0));
        SpotsToGo.Add(new Vector3(0, 5f, 0));
        SpotsToGo.Add(new Vector3(-1, 5f, 0));
        SpotsToGo.Add(new Vector3(3, 4f, 0));
        SpotsToGo.Add(new Vector3(2, 4f, 0));
        SpotsToGo.Add(new Vector3(1, 4f, 0));
        SpotsToGo.Add(new Vector3(0, 4f, 0));
        SpotsToGo.Add(new Vector3(-1, 4f, 0));
        SpotsToGo.Add(new Vector3(3, 3f, 0));
        SpotsToGo.Add(new Vector3(2, 3f, 0));
        SpotsToGo.Add(new Vector3(1, 3f, 0));
        SpotsToGo.Add(new Vector3(0, 3f, 0));
        SpotsToGo.Add(new Vector3(-1, 3f, 0));
        SpotsToGo.Add(new Vector3(3, 2f, 0));
        SpotsToGo.Add(new Vector3(2, 2f, 0));
        SpotsToGo.Add(new Vector3(1, 2f, 0));
        SpotsToGo.Add(new Vector3(0, 2f, 0));
        SpotsToGo.Add(new Vector3(-1, 2f, 0));
        SpotsToGo.Add(new Vector3(3, 1f, 0));
        SpotsToGo.Add(new Vector3(2, 1f, 0));
        SpotsToGo.Add(new Vector3(1, 1f, 0));
        SpotsToGo.Add(new Vector3(0, 1f, 0));
        SpotsToGo.Add(new Vector3(-1, 1f, 0));
        
      
        if (timeTotal > 0)
        {
            timeTotal = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {


        waittoload += Time.deltaTime;



        if (waittoload > 2 / 3f)
        {
            zScenePos += 12;

            waittoload = 0;




            if (zScenePos > 45)
            {
                Quaternion quat = Quaternion.identity;
                quat.z = Random.rotation.z;

                Instantiate(WormholeObj, new Vector3 (1f, 1.5f, 20f + zScenePos), quat);

                int asteroidpercentage = asteroidpercentagebase;
                //int laserpercentage = laserprecentagebase;
                int blightspercentage = blightspercentagebase;
                int fuelpercentage = fuelpercentagebase;
                int burstpercentage = burstpercentagebase;
                int holypercentage = holypercentagebase;
                int powercorepercentage = powercorepercentagebase;
                int wrenchpercetage = wrenchpercetagebase;
                int countasteroids = 0;

                List<Vector3> shuffledList = SpotsToGo.OrderBy(x => Random.value).ToList();

                float ranNum = Random.Range(1, 10);

                if (ranNum <= 2)
                    Instantiate(laserObj, new Vector3(1, 1, zScenePos), laserObj.rotation);
                else
                {
                    foreach (Vector3 SpotToPlace in shuffledList)
                    {

                        randNum = Random.Range(1, 100);
                        if (randNum <= asteroidpercentage && countasteroids < 24)
                        {
                            countasteroids += 1;
                            Instantiate(asteroidObj, new Vector3(SpotToPlace.x, SpotToPlace.y, zScenePos), asteroidObj.rotation);
                        }
                        else if ((blightspercentage + asteroidpercentage) >= randNum && randNum > asteroidpercentage)
                        {
                            Instantiate(blightObj, new Vector3(SpotToPlace.x, SpotToPlace.y, zScenePos), blightObj.rotation);
                        }
                        else if ((fuelpercentage + blightspercentage + asteroidpercentage) >= randNum && randNum > (blightspercentage + asteroidpercentage) & FuelPurchased)
                        {
                            Instantiate(fuelObj, new Vector3(SpotToPlace.x, SpotToPlace.y, zScenePos), fuelObj.rotation);
                        }
                        else if ((burstpercentage + fuelpercentage + blightspercentage + asteroidpercentage) >= randNum && randNum > (fuelpercentage + blightspercentage + asteroidpercentage) & BurstPurchased)
                        {
                            Instantiate(burstObj, new Vector3(SpotToPlace.x, SpotToPlace.y, zScenePos), fuelObj.rotation);
                        }
                        else if ((holypercentage + burstpercentage + fuelpercentage + blightspercentage + asteroidpercentage) >= randNum && randNum > (burstpercentage + fuelpercentage + blightspercentage + asteroidpercentage) & HolyLightPurchased)
                        {
                            Instantiate(holylightObj, new Vector3(SpotToPlace.x, SpotToPlace.y, zScenePos), fuelObj.rotation);
                        }
                        else if ((powercorepercentage + holypercentage + burstpercentage + fuelpercentage + blightspercentage + asteroidpercentage) >= randNum && randNum > (holypercentage + burstpercentage + fuelpercentage + blightspercentage + asteroidpercentage) & PowerCorePurchased)
                        {
                            Instantiate(powercoreObj, new Vector3(SpotToPlace.x, SpotToPlace.y, zScenePos), powercoreObj.rotation);
                        }
                        else if ((wrenchpercetage + powercorepercentage + holypercentage + burstpercentage + fuelpercentage + blightspercentage + asteroidpercentage) >= randNum && randNum > (powercorepercentage + holypercentage + burstpercentage + fuelpercentage + blightspercentage + asteroidpercentage) & WrenchPurchased)
                        {
                            Instantiate(wrenchObj, new Vector3(SpotToPlace.x, SpotToPlace.y, zScenePos), wrenchObj.rotation);
                        }
                    }
                }
                SceneTotal += 1;

            }

        }
        timeTotal += Time.deltaTime;

        if (lvlCompStatus == "Fail Asteroid")
        {
            waittoloadDeath += Time.deltaTime;

            if (waittoloadDeath > 1.3)
            {
                SceneManager.LoadScene("Ending 1");
               

            }
        }

        if (lvlCompStatus == "Fail Laser")
        {
            waittoloadDeath += Time.deltaTime;
            if (waittoloadDeath > 1.3)
            {
                SceneManager.LoadScene("Ending 2");
               

            }
        }
 

       if (lvlCompStatus == "Fail Fuel")
        {
            waittoloadDeath += Time.deltaTime;

            if (waittoloadDeath > 1.3)
            {
                SceneManager.LoadScene("Ending 3");
                

            }
        }
       
    }
}
