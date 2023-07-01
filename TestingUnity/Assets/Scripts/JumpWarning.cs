using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWarning : MonoBehaviour
{
    void OnEnable()
    {
        PlayerAnimation.EnableAnim += DidHeJump;
    }

    void OnDisable()
    {
        PlayerAnimation.EnableAnim -= DidHeJump;
    }

    void DidHeJump()
    {
        Debug.Log("He jumped!");
    }
}
