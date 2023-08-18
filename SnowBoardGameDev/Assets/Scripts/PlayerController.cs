using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.AddTorque(torqueAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            _rb.AddTorque(-torqueAmount);
        }
    }
}
