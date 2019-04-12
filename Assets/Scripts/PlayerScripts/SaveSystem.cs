using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem  {

	public static bool NoSaveFile = true;
	public static bool NoSaveFileForDeaths = true;

	public static void SavePlayer (playerLevelInfo player)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/player_info";
		FileStream stream = new FileStream(path, FileMode.Create);

		PlayerData data = new PlayerData(player);
		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static PlayerData LoadPlayer()
	{
		string path = Application.persistentDataPath + "/player_info";
		if (File.Exists(path))
		{
			NoSaveFile = false;
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);
			Debug.Log("There exists a path");
			PlayerData data = formatter.Deserialize(stream) as PlayerData;
			stream.Close();

			return data;
		} 
		else{
			NoSaveFile = true;
			Debug.Log("Save file not found in " + path);
			return null;
		}
	}

	public static void SaveDeaths (DeathCount death)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/death_info";
		FileStream stream = new FileStream(path, FileMode.Create);

		DeathData data = new DeathData(death);
		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static DeathData LoadDeaths()
	{
		string path = Application.persistentDataPath + "/death_info";
		if (File.Exists(path))
		{
			NoSaveFileForDeaths = false;
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);
			Debug.Log("There exists a path");
			DeathData data = formatter.Deserialize(stream) as DeathData;
			stream.Close();

			return data;
		} 
		else{
			NoSaveFileForDeaths = true;
			Debug.Log("Save file not found in " + path);
			return null;
		}
	}

	


}
