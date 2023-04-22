using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerModifier : MonoBehaviour
{
    private Progress _progress;
    
    const float MinOffsetSpine = 0.17f;
    private const float PlayerSize = 1.84f;
    
    [SerializeField] private float width, height;

    private float _widthMultiplier = 0.0005f;
    private float _heightMultiplier = 0.01f;

    private Renderer _renderer;

    [SerializeField] private Transform topSpine, bottomSpine;
    
    [SerializeField] private Transform colliderTransform;

    [SerializeField] private AudioSource audioSource;
    
    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);
    
    private void Start()
    {
        _progress = Progress.Instance;
        
        _renderer = GetComponentInChildren<Renderer>();
        
        Barrier.EventBarrier += InBarrier;

        SetWidth(_progress.playerInfo.width);
        SetHeight(_progress.playerInfo.height);
    }

    private void Update()
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

    private void UpdateWidth()
    {
        if(_renderer == null)
            return;
        
        _renderer.material.SetFloat("_PushValue", width * _widthMultiplier);
    }

    private void UpdateHeight()
    {
        float offSetY = height * _heightMultiplier + MinOffsetSpine;
        topSpine.position = bottomSpine.position + new Vector3(0, offSetY, 0);
        
        colliderTransform.localScale = new Vector3(1, PlayerSize + height * _heightMultiplier, 1);
    }
    
    private void Die()
    {
        GameManager.Instance.ShowFinishWindow();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Barrier.EventBarrier -= InBarrier;
    }
    
    public void AddWidth(int value)
    {
        width += value;
        UpdateWidth();

        if (value > 0)
        {
            audioSource.Play();
        }
    }

    public void AddHeight(int value)
    {
        height += value;
        UpdateHeight();
        if (value > 0)
        {
            audioSource.Play();
        }
    }

    public void SetWidth(int value)
    {
        width = value;
        _progress.playerInfo.width = value;
        UpdateWidth();
    }
    
    public void SetHeight(int value)
    {
        height = value;
        _progress.playerInfo.height = value;
        
#if UNITY_WEBGL
        SetToLeaderboard(value);
#endif
        
        
        UpdateHeight();
    }
    
}
