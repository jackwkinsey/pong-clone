using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 30.0f;

    [SerializeField]
    private string _axis = "Vertical";

    private float _yAxisInput;
    private Vector2 _moveDirection;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _yAxisInput = Input.GetAxisRaw(_axis);
        _moveDirection = new Vector2(0, _yAxisInput);
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveDirection * _moveSpeed;
    }
}
