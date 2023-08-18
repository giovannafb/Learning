using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMove : MonoBehaviour
{
    private InputSystem _input;
    private Rigidbody2D _rb;
    private float velocity = 15f;
   void Awake()
   {
        _input = new InputSystem();
        _rb = GetComponent<Rigidbody2D>();
   }

   void OnEnable()
   {
        _input.Enable();
        //_input.Player.Move.started += Moving;
        _input.Player.Move.performed += Moving;
        _input.Player.Move.canceled += Moving;
   }

    void OnDisable()
    {
        _input.Disable();
        //_input.Player.Move.started -= Moving;
        _input.Player.Move.performed -= Moving;
        _input.Player.Move.canceled -= Moving;
    }
   void Update()
   {
        //Move(_input.Player.Move.ReadValue<Vector2>());
   }

   void Move(Vector2 _vector)
   {
        //_rb.velocity = new Vector3(_vector.x, _vector.y) * velocity;
   }

   void Moving(InputAction.CallbackContext ctx)
   {
        _rb.velocity = new Vector3(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y) * velocity;
   }
}
