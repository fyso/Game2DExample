using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 1;

    private Rigidbody2D m_Rigidbody2D;
    private Vector2 m_MoveDirection;

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        m_MoveDirection = new Vector2(directionX, directionY).normalized;
    }

    void FixedUpdate()
    {
        m_Rigidbody2D.velocity = m_MoveDirection * MoveSpeed;
    }
}
