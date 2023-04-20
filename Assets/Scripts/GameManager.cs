using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public static event Action GoToPlay;
    
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
        levelText.text = SceneManager.GetActiveScene().name;
    }

    public void Play()
    {
        startMenu.SetActive(false);
        GoToPlay?.Invoke();
    }

    public void ShowFinishWindow()
    {
        finishWindow.SetActive(true);
    }
    
    public void NextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (index < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index);
        }
    }
}
