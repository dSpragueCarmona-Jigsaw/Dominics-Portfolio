using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Moveplayer : MonoBehaviour
{

    private int countBlights;

    public KeyCode moveL;
    public KeyCode moveR;
    public KeyCode moveUP;
    public KeyCode moveDOWN;

    public KeyCode shoot;

    public KeyCode moveL2;
    public KeyCode moveR2;
    public KeyCode moveUP2;
    public KeyCode moveDOWN2;

    public float waittoload = 0;
    public float horizVel = 0;
    public int laneNum = 2;
    public string controlLocked = "n";


    public Transform boomObj;
    public Transform taserObj;
    public Transform nofuelObj;
    public Transform burstObj;
    public Transform astrodeadObj;
    public Transform tasObj;
    public Transform holylightObj;
    public Transform addfuelObj;
    public Transform addblightObj;
    public Transform ammoObj;
    public Transform healthObj;
   

    public float CurrentFuel = 10;
    public float MaxFuel = 10;
    public float MaxAmmo = 3;
    public float CurrentAmmo = 3;
    public float MaxHealth = 3;
    public float CurrentHealth = 1;

    public Text countBlightsText;
    public Text FuelText;
    public Image FuelImage;

    public GameObject FuelSound;
    public GameObject BurstSound;
    public GameObject HolyLightSound;
    public GameObject AsteroidSound;
    public GameObject LaserSound;
    public GameObject BlightSound;
    public GameObject NoFuelSound;
    public GameObject PowercoreSound;
    public GameObject WrenchSound;
    public GameObject shootLaserSound;


    public GameObject imgLife1;
    public GameObject imgLife2;
    public GameObject imgLife3;

    public GameObject ammo1;
    public GameObject ammo2;
    public GameObject ammo3;

    public GameObject part1;
    public GameObject part2;
    public GameObject part3;


    public GameObject ShootLaser;


    // Use this for initialization
    void Start()
    {

        countBlights = 0;
        SetcountBlightsText();

    } 
    // Update is called once per frame
    void Update()
    {

      

        UpdateUI();

        //keeps camera locked with ship
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GM.vertVel, 4 * GM.zVelAdj);

        if ((Input.GetKeyDown(shoot)) && PauseMenu.GameisPaused == false && CurrentAmmo > 0)
        {
            CurrentAmmo -= 1;
            Instantiate(shootLaserSound);
             

            var Laser = Instantiate(ShootLaser, transform.position, ShootLaser.transform.rotation);

            Laser.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * -35);
        }


        if ((Input.GetKeyDown(moveL)) && (laneNum > 1) && PauseMenu.GameisPaused == false && this.gameObject.transform.position.x > -.01f)
        {
            for (int i = 0; i < 10; i++)
            {
                float distancetomove = Mathf.Lerp(0, 1, .1f);
                this.gameObject.transform.Translate(new Vector3(distancetomove, 0));
            }
        }
        if ((Input.GetKeyDown(moveR)) && (laneNum < 3) && PauseMenu.GameisPaused == false && this.gameObject.transform.position.x < 2.9)
        {
            for (int i = 0; i < 10; i++)
            {
                float distancetomove = Mathf.Lerp(0, 1, .1f);
                this.gameObject.transform.Translate(new Vector3(-distancetomove, 0));
            }
        }
        if ((Input.GetKeyDown(moveUP)) && (laneNum < 3) && PauseMenu.GameisPaused == false && this.gameObject.transform.position.y < 4.9)
        {
            for (int i = 0; i < 10; i++)
            {
                float distancetomove = Mathf.Lerp(0, 1, .1f);
                this.gameObject.transform.Translate(new Vector3(0, distancetomove));
             
            }
        }
        if ((Input.GetKeyDown(moveDOWN)) && (laneNum < 3) && PauseMenu.GameisPaused == false && this.gameObject.transform.position.y > 1.2)
        {
            for (int i = 0; i < 10; i++)
            {
                float distancetomove = Mathf.Lerp(0, 1, .1f);
                this.gameObject.transform.Translate(new Vector3(0, -distancetomove));
            }

        }
        if ((Input.GetKeyDown(moveL2)) && (laneNum > 1) && PauseMenu.GameisPaused == false && this.gameObject.transform.position.x > -.01f)
        {
            for (int i = 0; i < 10; i++)
            {
                float distancetomove = Mathf.Lerp(0, 1, .1f);
                this.gameObject.transform.Translate(new Vector3(distancetomove, 0));
            }
        }
        if ((Input.GetKeyDown(moveR2)) && (laneNum < 3) && PauseMenu.GameisPaused == false && this.gameObject.transform.position.x < 2.9)
        {
            for (int i = 0; i < 10; i++)
            {
                float distancetomove = Mathf.Lerp(0, 1, .1f);
                this.gameObject.transform.Translate(new Vector3(-distancetomove, 0));
            }
        }
        if ((Input.GetKeyDown(moveUP2)) && (laneNum < 3) && PauseMenu.GameisPaused == false && this.gameObject.transform.position.y < 4.9)
        {
            for (int i = 0; i < 10; i++)
            {
                float distancetomove = Mathf.Lerp(0, 1, .1f);
                this.gameObject.transform.Translate(new Vector3(0, distancetomove));
            }
        }
        if ((Input.GetKeyDown(moveDOWN2)) && (laneNum < 3) && PauseMenu.GameisPaused == false && this.gameObject.transform.position.y > 1.2)
        {
            for (int i = 0; i < 10; i++)
            {
                float distancetomove = Mathf.Lerp(0, 1, .1f);
                this.gameObject.transform.Translate(new Vector3(0, -distancetomove));
            }
        }
        if (CurrentFuel < 1)
        {
            Instantiate(NoFuelSound);
        }
        if (CurrentFuel <= 0)
        {
            
            GM.lvlCompStatus = "Fail Fuel";
            Instantiate(nofuelObj, transform.position, nofuelObj.rotation);
          
        }
        if (CurrentFuel > 10)
        {
            CurrentFuel = 10;
        }
        if (CurrentFuel < 0)
        {
            CurrentFuel = 0;
        }

        if (CurrentAmmo > 3)
        {
            CurrentAmmo = 3;
        }
        if (CurrentAmmo < 0)
        {
            CurrentAmmo = 0;
        }

        if (CurrentHealth > 3)
        {
            CurrentHealth = 3;
        }
        
        imgLife1.SetActive(CurrentHealth == 1);
        part1.SetActive(CurrentHealth == 1);
        imgLife2.SetActive(CurrentHealth == 2);
        part2.SetActive(CurrentHealth == 2);
        imgLife3.SetActive(CurrentHealth == 3);
        part3.SetActive(CurrentHealth == 3);

        ammo1.SetActive(CurrentAmmo == 1);
        ammo2.SetActive(CurrentAmmo == 2);
        ammo3.SetActive(CurrentAmmo == 3);

        print(imgLife3);

        print(CurrentHealth);

        if (CurrentHealth == 0)
        {
            GM.lvlCompStatus = "Fail Asteroid";
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.tag == "Laser")
        {

            Destroy(gameObject);

            Instantiate(taserObj, transform.position, taserObj.rotation);
            GM.lvlCompStatus = "Fail Laser";
            Instantiate(tasObj, transform.position, tasObj.rotation);
            Instantiate(LaserSound);
            CurrentHealth -= 3;
        }


    }

    void OnTriggerEnter(Collider other)
    {

        if (gameObject.name == "Destroyer")
            Destroy(other.gameObject);


        if (other.gameObject.tag == "Lethal")
        {

           
            Instantiate(boomObj, transform.position, boomObj.rotation);
            Destroy(other.gameObject);
            Instantiate(astrodeadObj, transform.position, astrodeadObj.rotation);
            Instantiate(AsteroidSound);
            CurrentHealth -= 1;

        }
        if (other.gameObject.name == "Blight(Clone)")
        {
           
            Destroy(other.gameObject);
            GM.blightTotal += 1;
            countBlights = countBlights + 1;
            SetcountBlightsText();
            CurrentFuel -= .1f;
            Instantiate(addblightObj, transform.position, addblightObj.rotation);
            Instantiate(BlightSound);

        }
        if (other.gameObject.name == "Fuel(Clone)")
        {
            Destroy(other.gameObject);
            CurrentFuel += 10;
            Instantiate(addfuelObj, transform.position, addfuelObj.rotation);
            Instantiate(FuelSound);

        }
        if (other.gameObject.name == "Burst(Clone)")
        {
            Destroy(other.gameObject);
            Instantiate(burstObj, transform.position, burstObj.rotation);
            GM.blightTotal += 5;
            countBlights = countBlights + 5;
            CurrentFuel -= .3f;
            SetcountBlightsText();
            Instantiate(BurstSound);

        }
        if (other.gameObject.name == "Holy Light(Clone)")
        {
            Destroy(other.gameObject);
            Instantiate(holylightObj, transform.position, holylightObj.rotation);
            countBlights = countBlights - 10;
            CurrentFuel += 1;
            Instantiate(HolyLightSound);
        }
        if (other.gameObject.name == "Power Core(Clone)")
        {
            Destroy(other.gameObject);
            Instantiate(ammoObj, transform.position, ammoObj.rotation);
            CurrentAmmo += 1;
            Instantiate(PowercoreSound);
            
            

        }
        if (other.gameObject.name == "Wrench(Clone)")
        {
            Destroy(other.gameObject);
            CurrentHealth += 1;
            Instantiate(healthObj, transform.position, healthObj.rotation);
            Instantiate(WrenchSound);

        }
    }
    public void UpdateUI()
    {
        FuelImage.fillAmount = CurrentFuel / MaxFuel;
        FuelText.text = "Fuel " + ((int)(CurrentFuel / MaxFuel * 100)).ToString() + "%";
        {
            if (GM.zVelAdj > 0)
            {
                waittoload += Time.deltaTime;

            }
            if (waittoload > 3 && PauseMenu.GameisPaused == false)
            {
                CurrentFuel -= .003f;
            }

        }
    }

    void SetcountBlightsText ()
    {
        countBlightsText.text = "Blights:" + countBlights.ToString ();
        
    }
}