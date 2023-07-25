using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool hasPackage;

    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 hasNoPackageColor = new Color32(1, 1, 1, 1);

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Boom we hit something!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Picked package");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.GameObject(), destroyDelay);
        }
        if (other.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered package");
            spriteRenderer.color = hasNoPackageColor;
            hasPackage = false;
        }
    }
}
