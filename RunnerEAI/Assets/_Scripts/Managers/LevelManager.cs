using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        public static event System.Action OnNextLevel;

        [SerializeField] List<GameObject> levelList;
        public int currentLevel { get; set; }
        void Awake()
        {
            currentLevel = 0;
            StartSingleton(this);
        }
        void OnEnable()
        {
            OnNextLevel += NextLevel;
            MenuManager.OnResetGame += RefreshLevel;
        }
        void Start()
        {
            DisableLevels();
            levelList[currentLevel].SetActive(true);
        }
        void NextLevel()
        {
            DisableLevels();
            currentLevel++;
            levelList[currentLevel].SetActive(true);
        }
        void DisableLevels()
        {
            foreach (GameObject go in levelList)
            {
                go.SetActive(false);
            }
        }
        void RefreshLevel()
        {
            GameObject targetobject = levelList[currentLevel].transform.Find("Objects").transform.Find("Coins").gameObject;
            Debug.Log(targetobject);
            int count = targetobject.transform.childCount;
            for(int i=0;i<count; i++)
            {
                targetobject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        public void NextLevelButton()
        {   
            OnNextLevel?.Invoke();
        }
    }

}
