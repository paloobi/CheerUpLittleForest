using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    public CircleCollider2D interactionRing;
    public ContactFilter2D interactable;

    float horizontal;
    float vertical;

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<Collider2D> interactionTargets = new();
            interactionRing.OverlapCollider(interactable, interactionTargets);
            foreach (Collider2D target in interactionTargets)
            {
                CritterScript critter = target.GetComponent<CritterScript>();
                if (critter != null)
                {
                    critter.IsHappy = true;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(horizontal, vertical).normalized;
        body.velocity = direction * speed;
    }
}
