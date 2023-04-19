using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    void Start()
    {
        Debug.Log(gameObject.name);
        Debug.Log(gameObject.tag);

        gameObject.name = "My Super Cube";
        
        Debug.Log(gameObject.name);
        
        //gameObject.SetActive(false);

        transform.position = new Vector3(0,2,0);
        transform.eulerAngles = new Vector3(0, 45, 30);//rotation
        transform.localScale = new Vector3(1, 2, 4);//scale
    }
    
    void Update()
    {
       

        if (Input.GetKey(KeyCode.W))
        {
            //GetKey когда удерживаем
            transform.position += new Vector3(0, 0.03f, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //GetKeyDown - когда нажимаем на кнопку первый раз
            transform.position += new Vector3(0, 0.03f, 0);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            //GetKeyDown - когда отпускаем
            transform.position += new Vector3(0, 0.03f, 0);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -0.03f, 0);
        }

        if (Input.GetMouseButtonDown(0))//левая кнопка мыши
        {
            transform.localScale *= 1.2f;
        }
        if (Input.GetMouseButtonDown(1))//правая кнопка мыши
        {
            transform.localScale *= 0.8f;
        }

        transform.localEulerAngles = new Vector3(0,Input.mousePosition.x, 0);
        //Input.mousePosition.x - координата мыши на экране
        //transform.localEulerAngles - поворот
    }
}
