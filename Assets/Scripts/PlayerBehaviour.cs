using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    
    private PlayerMove _playerMove;
    private PreFinishBehaviour _preFinishBehaviour;
    private Animator _animator;
    
    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
        _preFinishBehaviour = GetComponent<PreFinishBehaviour>();
        _animator = GetComponentInChildren<Animator>();
    }
    
    void Start()
    {
        if (_playerMove)
        {
            _playerMove.enabled = false;

            GameManager.GoToPlay += () => Play();
        }

        if (_preFinishBehaviour)
        {
            _preFinishBehaviour.enabled = false;
            PreFinishTrigger.EventPreFinishTrigger += StartPreFinishBehaviour;

            FinishTrigger.EventFinishTrigger += StartFinishBehaviour;
        }
    }
    
    void Update()
    {
        
    }

    private void Play()
    {
        _playerMove.enabled = true;
    }

    private void StartPreFinishBehaviour()
    {
        _playerMove.enabled = false;
        _preFinishBehaviour.enabled = true;
    }
    
    private void StartFinishBehaviour()
    {
        _preFinishBehaviour.enabled = false;

        if (_animator)
        {
            _animator.SetTrigger("Dance");
        }

    }
}
