using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModifier : MonoBehaviour
{
    const float MinOffsetSpine = 0.17f;
    private const float PlayerSize = 1.84f;
    
    [SerializeField] private float width, height;

    private float _widthMultiplier = 0.0005f;
    private float _heightMultiplier = 0.01f;

    private Renderer _renderer;

    [SerializeField] private Transform topSpine, bottomSpine;
    
    [SerializeField] private Transform colliderTransform;
    
    private void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        
        Barrier.EventBarrier += InBarrier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AddWidth(20);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            AddHeight(20);
        }
    }

    public void AddWidth(int value)
    {
        width += value;
        UpdateWidth();
    }

    public void AddHeight(int value)
    {
        height += value;
        
        float offSetY = height * _heightMultiplier + MinOffsetSpine;
        topSpine.position = bottomSpine.position + new Vector3(0, offSetY, 0);
        
        colliderTransform.localScale = new Vector3(1, PlayerSize + height * _heightMultiplier, 1);
    }

    private void InBarrier()
    {
        if (height > 0)
        {
            AddHeight(-50);
        }
        else if (width > 0)
        {
            AddWidth(-50);
        }
        else
        {
            Die();
        }
    }

    void UpdateWidth()
    {
        if(_renderer == null)
            return;
        
        _renderer.material.SetFloat("_PushValue", width * _widthMultiplier);
    }

    void Die()
    {
        GameManager.Instance.ShowFinishWindow();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Barrier.EventBarrier -= InBarrier;
    }
}
