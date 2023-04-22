using System;
using System.IO;
using UnityEngine;

namespace CR.Data
{
	[Serializable]
	public class PlayerData
	{
        public int LastScore;
        public int BestScore;


        public PlayerData()
        {
            LastScore = 0;
            BestScore = 30;
        }
    }

	public class SaveSystem
	{
        public const string SAVE_NAME = "data.json";
        public PlayerData PlayerData { get; set; }

		public void LoadData()
		{
            var savePath = Path.Combine(Application.persistentDataPath, SAVE_NAME);

            if(File.Exists(savePath))
            {
                var rawFile = File.ReadAllText(savePath);
                PlayerData = JsonUtility.FromJson<PlayerData>(rawFile);
            }
            else
            {
                PlayerData = new PlayerData();
                SaveData();
            }
		}

        public void SaveData()
        {
            var savaPath = Path.Combine(Application.persistentDataPath, SAVE_NAME);
            var rawFile = JsonUtility.ToJson(PlayerData, true);
            File.WriteAllText(savaPath, rawFile);
        }
    } 
}
