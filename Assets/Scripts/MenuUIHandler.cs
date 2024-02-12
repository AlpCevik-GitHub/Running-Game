
    using TMPro;
    using UnityEngine;
    using UnityEngine.SceneManagement;


    [DefaultExecutionOrder(1000)]
    public class MenuUIHandler : MonoBehaviour
    {


        public TextMeshProUGUI inputField;
        public static string playerName;
        // Start is called before the first frame update
        public void StartNew()
        {
            playerName = inputField.text;
            SceneManager.LoadScene(1);
        }

       public void Exit()
        {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
    #else
        UnityEngine.Application.Quit();
    #endif

            DataHolder.Instance.ToSaveData();
        }

        public void SaveName(string name)
        {
            DataHolder.Instance.playerName = name;
        }
    }
