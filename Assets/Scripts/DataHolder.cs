
    using System.IO;
    using UnityEngine;

    public class DataHolder : MonoBehaviour
    {

        public static DataHolder Instance;

        public string playerName;
        public string lastName;
        public int bestScore;
        public bool verfiyModifier = false;


        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            ToLoadData();
        }

        [System.Serializable]
        class Save
        {

            public string playerName;
            public int bestScore;
        }


        public void ToSaveData()
        {

            Save save = new Save();
            save.bestScore = bestScore;
            save.playerName = playerName;

            string json = JsonUtility.ToJson(save);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
            Debug.Log("Persistent Data Path: " + Application.persistentDataPath);
        }

        public void ToLoadData()
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                Save save = JsonUtility.FromJson<Save>(json);
                Debug.Log("Persistent Data Path: " + Application.persistentDataPath);

                bestScore = save.bestScore;
                playerName = save.playerName;
            }
        }


    }
