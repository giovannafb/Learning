using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pessoa : MonoBehaviour, IMovement
{
    Player1 pessoa = new Player1();

    public Action Flip;

    private SpriteRenderer _sprite;

    private bool isFacingRight = true;

    private float input;
    private Animator _animator;

    private bool isJumping = false;

    void Start()
    {
        pessoa.SetRigidbody(GetComponent<Rigidbody2D>());
        Debug.Log(pessoa.GetNome());

        _animator = GetComponent<Animator>();

        _sprite = GetComponent<SpriteRenderer>();
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

        if(Input.GetKeyDown(KeyCode.M))
        {
            TurnPlayer();
        }
    }

    void FixedUpdate()
    {
        pessoa.Move(input);
    }

    void  OnEnable()
    {
        PlayerAnimation.EnableAnim += EnableJump;
        PlayerAnimation.DisableAnim += DisableJump;
    }

    void OnDisable()
    {
        PlayerAnimation.EnableAnim -= EnableJump;
        PlayerAnimation.DisableAnim -= DisableJump;
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

    public void DisableJump()
    {
        _animator.SetBool("isJumping", false);
    }


    public void TurnPlayer()
    {
        _sprite.flipY.Equals(true);
    }

}
