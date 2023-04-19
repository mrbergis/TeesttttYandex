using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    [SerializeField] private float height;
    [SerializeField] private int numberOfCoins;
    [SerializeField] private string name;
    [SerializeField] private Color bodyColor;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private bool isAlive;

    [SerializeField] private Light sun;

    [SerializeField]
    private Camera camera;

    [SerializeField] 
    private Transform ball;
    
    void Start()
    {
        transform.localScale = new Vector3(1, height, 1);
        gameObject.name = name;
        gameObject.GetComponent<Renderer>().material.color = bodyColor;
        transform.position = startPosition;
        gameObject.SetActive(isAlive);

        sun.intensity = 2;
        sun.color = Color.red;

        camera.fieldOfView = 120;

    }

    // Update is called once per frame
    void Update()
    {
        ball.position = transform.position + new Vector3(0, 3, 0);
    }
}
