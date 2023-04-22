using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Language : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLang();
    
    public string currentLanguage; // ru en
    [SerializeField] private TMP_Text laguageText;
    
    public static Language Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

#if UNITY_WEBGL
            currentLanguage = GetLang();
            laguageText.text = currentLanguage;
#endif
            
        }
        else
        {
            Destroy(this);
        }
    }

}
