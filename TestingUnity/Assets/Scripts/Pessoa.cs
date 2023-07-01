using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pessoa : MonoBehaviour, IMovement
{
    Player1 pessoa = new Player1();

    void  OnEnable()
    {
        PlayerAnimation.EnableAnim += EnableJump;
    }

    void OnDisable()
    {
        PlayerAnimation.EnableAnim -= EnableJump;
    }

    private float input;
    private Animator _animator;

    private bool isJumping = false;

    void Start()
    {
        pessoa.SetRigidbody(GetComponent<Rigidbody2D>());
        Debug.Log(pessoa.GetNome());

        _animator = GetComponent<Animator>();

    }

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");


        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            Jump();
        }

        if(isJumping == true)
        {
            isJumping = false;
        }
    }

    void FixedUpdate()
    {
        pessoa.Move(input);
    }

    public void Jump()
    {
        pessoa.GetRigibody().AddForce(Vector2.up * pessoa.jumpForce, ForceMode2D.Impulse);
    }

    //Método com a mesma assinatura de EnableAnim
    public void EnableJump()
    {
        _animator.SetBool("isJumping", true);
    }
}
