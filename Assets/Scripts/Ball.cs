using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 30.0f;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = Vector2.right * _moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        string name = col.gameObject.name;
        if (name == "RacketLeft" || name == "RacketRight")
        {
            float xDirection = 0;

            if (col.gameObject.name == "RacketLeft")
            {
                xDirection = 1;
            }
            else if (col.gameObject.name == "RacketRight")
            {
                xDirection = -1;
            }

            float yDirection = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 direction = new Vector2(xDirection, yDirection).normalized;

            _rb.velocity = direction * _moveSpeed;
        }
    }

    private float hitFactor(Vector2 ballPosition, Vector2 racketPosition, float racketHeight)
    {
        return (ballPosition.y - racketPosition.y) / racketHeight;
    }
}
