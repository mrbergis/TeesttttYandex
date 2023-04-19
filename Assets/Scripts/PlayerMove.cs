using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    private float _oldMousePositionX;

    private float _eulerY;

    private Animator _animator;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _oldMousePositionX = Input.mousePosition.x;
            
            if (_animator)
            {
                _animator.SetBool("Run", true);
            }
        }
        
        if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = transform.position + transform.forward * speed  * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, -2.5f, 2.5f);//чтобы не ушел за определенный диапазон
            transform.position = newPosition;
            //speed в данном случае сколько метров пройдет за 1 секунду
            
            float deltaX = Input.mousePosition.x - _oldMousePositionX;
            _oldMousePositionX = Input.mousePosition.x;

            _eulerY += deltaX;
            _eulerY = Mathf.Clamp(_eulerY, -70, 70);//ограничили поворот
            transform.eulerAngles = new Vector3(0, _eulerY, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_animator)
            {
                _animator.SetBool("Run", false);
            }
        }
        
    }
}
