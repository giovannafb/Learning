using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pessoa : MonoBehaviour, IMovement
{
    Player1 pessoa = new Player1();

    private float input;

    void Start()
    {
        pessoa.SetRigidbody(GetComponent<Rigidbody2D>());
        Debug.Log(pessoa.GetNome());
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
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
}
