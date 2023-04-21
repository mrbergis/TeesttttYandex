using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinishBehaviour : MonoBehaviour
{
    //private float _speed = 3.0f;
    
    void Update()
    {
        //Позиция Х постепенно менятся от текущего значения до 0    
        float x = Mathf.MoveTowards(transform.position.x, 0, Time.deltaTime * 2f);
        float z = transform.position.z + 3f * Time.deltaTime;
        transform.position = new Vector3(x, 0, z);
        
        //Поворот по У постепенно меняется от текущего значения до 0
        float rot = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0, Time.deltaTime * 100f);
        transform.localEulerAngles = new Vector3(0, rot, 0);
    }
}
