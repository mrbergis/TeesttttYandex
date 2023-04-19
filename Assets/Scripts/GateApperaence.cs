using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum DeformationType
{
    Width,
    Height
}

public class GateApperaence : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private Image topImage, glassImage;

    [SerializeField] private Color colorPositive, colorNegative;
    
    [SerializeField] private GameObject expandLable, shrinkLable, upLable, donwLable;
    
    public void UpdateVisual(DeformationType deformationType, int value)
    {
        string prefix = "";
        
        text.text = value.ToString();
        
        if (value > 0)
        {
            prefix = "+";
            SetColor(colorPositive);
        }
        else if (value == 0)
        {
            SetColor(Color.grey);
        }
        else
        {
            SetColor(colorNegative);
            
        }

        text.text = prefix + value.ToString();

        expandLable.SetActive(false);
        shrinkLable.SetActive(false); 
        upLable.SetActive(false); 
        donwLable.SetActive(false);
        
        if (deformationType == DeformationType.Width)
        {
            if (value > 0)
            {
                expandLable.SetActive(true);
            }
            else
            {
                shrinkLable.SetActive(true); 
            }
        }
        else if (deformationType == DeformationType.Height)
        {
            if (value > 0)
            {
                upLable.SetActive(true); 
            }
            else
            {
                donwLable.SetActive(true);
            }
        }
    }

    private void SetColor(Color color)
    {
        topImage.color = color;
        glassImage.color = new Color(color.r, color.g, color.b, 0.5f);//RGB A
    }
}
