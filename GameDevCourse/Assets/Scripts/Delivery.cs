using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(61, 255, 0, 255);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    private SpriteRenderer _spriteRenderer;

    private bool hasPackage = false;

    [SerializeField] float delay = 1f;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Picked up!");
            hasPackage = true;
            Destroy(other.gameObject, delay);
            _spriteRenderer.color = hasPackageColor;
        }
        else if(other.tag == "Costumer" && hasPackage)
        {
            Debug.Log("Package Delivered!");
            hasPackage = false;
            _spriteRenderer.color = noPackageColor;
        }
    }
}
