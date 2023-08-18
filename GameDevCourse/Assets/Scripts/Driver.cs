using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 100f;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float slowSpeed = 5f;
    [SerializeField] private float boostSpeed = 15f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, -steerAmount);
        transform.Translate(0f, moveAmount, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Nitro")
        {
            moveSpeed = boostSpeed;
            Debug.Log("Acelera ae");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Obstacle")
        {
            Debug.Log("Pa");
            moveSpeed = slowSpeed;
        }
    }
}
