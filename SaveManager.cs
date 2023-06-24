using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static void SaveCoins(int coins)
    {
        SaveData saveData = new SaveData();
        saveData.coins = coins;

        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/save.dat";
        FileStream fileStream = new FileStream(savePath, FileMode.Create);
        formatter.Serialize(fileStream, saveData);
        fileStream.Close();
    }

    public static int LoadCoins()
    {
        string savePath = Application.persistentDataPath + "/save.dat";

        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(savePath, FileMode.Open);
            SaveData saveData = formatter.Deserialize(fileStream) as SaveData;
            fileStream.Close();

            return saveData.coins;
        }
        else
        {
            return 0;
        }
    }
}