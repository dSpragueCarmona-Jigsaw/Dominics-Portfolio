using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Audio;

public class MilkandCerealization : MonoBehaviour {

    public static ChillClass Datas;
    public static string dataPath;
    public static bool Loaded;

    // Use this for initialization
    void Start()
    {
        
        dataPath = Path.Combine(Application.persistentDataPath, "Datas.txt");
        DontDestroyOnLoad(gameObject);
        Datas = LoadCharacter(dataPath);
        if (!Loaded) {
            GM.blightTotal = Datas.Blights;
            //SettingsMenu.audioMixer = Datas.Volume;
            GM.FuelPurchased = Datas.Fuel;
            GM.BurstPurchased = Datas.Burst;
            GM.HolyLightPurchased = Datas.HolyLight;
            GM.PowerCorePurchased = Datas.PowerCore;
            GM.WrenchPurchased = Datas.Wrench;
            Loaded = true;
        }
        else
        {
            SetSave();
        }
    }


    public void SetSave()
    {
        Datas.Blights = GM.blightTotal;
        //Datas.Volume = SettingsMenu.audioMixer;
        Datas.Fuel = GM.FuelPurchased;
        Datas.Burst = GM.BurstPurchased;
        Datas.HolyLight = GM.HolyLightPurchased;
        Datas.PowerCore = GM.PowerCorePurchased;
        Datas.Wrench = GM.WrenchPurchased;
        SaveCharacter(Datas, dataPath);
    }

    public static void SaveCharacter(ChillClass data, string path)
    {
        
        string jsonString = JsonUtility.ToJson(data);

        using (StreamWriter streamWriter = File.CreateText(path))
        {
            streamWriter.Write(jsonString);
        }
    }

    public static ChillClass LoadCharacter(string path)
    {
        using (StreamReader streamReader = File.OpenText(path))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<ChillClass>(jsonString);
        }
        
    }
}

[System.Serializable]
public class ChillClass
{

    public int Blights;
    //public float Volume;
    public bool Fuel;
    public bool Burst;
    public bool HolyLight;
    public bool PowerCore;
    public bool Wrench;
}


