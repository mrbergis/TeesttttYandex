using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private int value;

    [SerializeField] private DeformationType deformationType;

    [SerializeField] private GateApperaence gateApperaence;

    private void OnValidate()
    {
        gateApperaence.UpdateVisual(deformationType, value);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();
        if (playerModifier)
        {
            if (deformationType == DeformationType.Width)
            {
                playerModifier.AddWidth(value);
            }
            else if (deformationType == DeformationType.Height)
            {
                playerModifier.AddHeight(value);
            }
            
        }
    }
}
