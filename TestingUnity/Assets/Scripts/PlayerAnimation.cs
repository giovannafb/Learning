using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static Action EnableAnim;

    private Pessoa controller;
    void Start()
    {
        controller = GetComponent<Pessoa>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            EnableAnim?.Invoke();
        }
    }
}
