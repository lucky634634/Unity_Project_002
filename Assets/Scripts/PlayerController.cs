using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float upwardForce = 1f;
    public KeyCode jumpKey = KeyCode.Space;
    public bool isDead;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
    }

    private void Update()
    {
        if (((Input.GetKeyDown(jumpKey) || Input.GetKeyDown(KeyCode.Mouse0)) && !isDead) && !EventSystem.current.IsPointerOverGameObject())
        {
            rb.velocity = Vector2.up * upwardForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("DEAD");
        isDead = true;
    }
}
