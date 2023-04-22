using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    
    public static GameManager Instance = null;
    public static event Action GoToPlay;
    public static event Action GoToExit;
    
    [SerializeField] private GameObject startMenu;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private  GameObject finishWindow;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        ShowAdv();
        
        levelText.text = SceneManager.GetActiveScene().name;
    }

    public void Play()
    {
        #if UNITY_EDITOR
                Debug.Log("Игра сохранена");
        #endif
        
        startMenu.SetActive(false);
        GoToPlay?.Invoke();
        
#if UNITY_WEBGL
        Progress.Instance.Save();
#endif
    }

    public void ShowFinishWindow()
    {
        GoToExit?.Invoke();
        finishWindow.SetActive(true);
    }
    
    public void NextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (index < SceneManager.sceneCountInBuildSettings)
        {
            Progress.Instance.playerInfo.level = index;
            Progress.Instance.Save();
            
            SceneManager.LoadScene(index);
        }
    }
}
