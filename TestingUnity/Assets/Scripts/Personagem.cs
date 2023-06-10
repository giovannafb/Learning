using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem
{
    //Atributos
    protected string _nome;
    protected float velocidade;
    public float jumpForce;

    protected Rigidbody2D rb;

    //Contrutores
    public Personagem() { }

    //Metodos
    public string GetNome()
    {
        return _nome;
    }
    public void SetNome(string nome)
    {
        _nome = nome;
    }


    public void SetVelocidade(float vel)
    {
        velocidade = vel;
    }

    public void Move(float input)
    {
        rb.velocity = new Vector2(input * velocidade, rb.velocity.y);
    }
    
    //Pegar Componente MonoBehavior
    public void SetRigidbody(Rigidbody2D component)
    {
        rb = component;
    }

    public Rigidbody2D GetRigibody()
    {
        return rb;
    }
}
