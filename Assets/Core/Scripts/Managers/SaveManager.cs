using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{
	/* Creates a file named playerInfo.dat and saves the information in binary format
	 * Directory: Users/ Username/Appdata/LocalLow/Default Company (or the company name in here)/name of this game/playerInfo.dat */

	public static SaveManager instance { get; private set; }

	public int totalKillCount;


	private void Awake()
	{
		SingletonThisObject();
		Load();
	}

	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

			totalKillCount = data.monsterKillCount;


			file.Close();
		}


	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
		PlayerData_Storage data = new PlayerData_Storage();

		data.monsterKillCount = totalKillCount;

		bf.Serialize(file, data);
		file.Close();
	}



	private void SingletonThisObject()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}


[Serializable]
class PlayerData_Storage
{
	public int monsterKillCount;
	//public int goldInWallet;

}
