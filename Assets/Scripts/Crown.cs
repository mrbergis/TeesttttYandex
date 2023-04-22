using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (InApp.Instance.hasCrown)
        {
            GetComponent<Renderer>().enabled = true;
        }
    }
    
}
