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
}
