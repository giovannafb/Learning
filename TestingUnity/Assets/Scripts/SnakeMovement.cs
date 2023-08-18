using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnakeMovement : MonoBehaviour
{
    private SnakeMap snakecontrols;
    private Rigidbody2D rb;
    [SerializeField] private float velocity = 10f;
    
    [SerializeField] private Transform detectionPoint;
    [SerializeField] private float detectionRadius = 0.5f;

    void Awake()
    {
        snakecontrols = new SnakeMap();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        snakecontrols.Enable();
        snakecontrols.Player.Move.started += Move;
        snakecontrols.Player.Move.performed += Move;
        snakecontrols.Player.Move.canceled += Move;

        snakecontrols.Player.Eat.performed += Eat;
        snakecontrols.Player.Eat.canceled += Eat;
    }

    void OnDisable()
    {
        snakecontrols.Disable();
        snakecontrols.Player.Move.started -= Move;
        snakecontrols.Player.Move.performed -= Move;
        snakecontrols.Player.Move.canceled -= Move;
        
        snakecontrols.Player.Eat.performed -= Eat;
        snakecontrols.Player.Eat.canceled -= Eat;
    }

    void Move(InputAction.CallbackContext ctx)
    {
        rb.velocity = new Vector3(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y) * velocity;
    }

    void Eat(InputAction.CallbackContext ctx)
    {
        Debug.Log("Oh eu quero mimir");

        if(detectApple())
        {
            Destroy(Physics2D.OverlapCircle(detectionPoint.position, detectionRadius).gameObject);
        }
    }

    bool detectApple()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius);
    }
}
