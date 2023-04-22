using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InternationalText : MonoBehaviour
{
    [SerializeField] private string en;
    [SerializeField] private string ru;
    
    void Start()
    {
        if (Language.Instance.currentLanguage == "en")
        {
            GetComponent<TMP_Text>().text = en;
        } else if (Language.Instance.currentLanguage == "ru")
        {
            GetComponent<TMP_Text>().text = ru;
        }
        else
        {
            GetComponent<TMP_Text>().text = en;
        }
    }
    
}
