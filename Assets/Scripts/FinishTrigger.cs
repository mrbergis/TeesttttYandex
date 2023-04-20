using System;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public static event Action EventFinishTrigger;
   
    private void OnTriggerEnter(Collider other)
    {
        EventFinishTrigger?.Invoke();
        Destroy(gameObject);
        GameManager.Instance.ShowFinishWindow();
    }
}
