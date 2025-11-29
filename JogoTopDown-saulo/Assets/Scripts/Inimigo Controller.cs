using System;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    public float speed = 3.5f;
    private Vector2 direction;
    private Rigidbody2D rb;

    public DetectionController detection; // detecta o player
    private SpriteRenderer sprite;
    private Animator animator;

    public float attackDistance = 1f;
    public int danoDoInimigo = 10; // configurável

    private float attackCooldown = 1f; // 1s entre ataques
    private float lastAttackTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (detection.detectedObjs.Count > 0)
        {
            Transform target = detection.detectedObjs[0].transform;
            float dist = Vector2.Distance(transform.position, target.position);

            if (direction.x > 0)
                sprite.flipX = false;
            else if (direction.x < 0)
                sprite.flipX = true;

            if (dist <= attackDistance)
            {
                animator.SetInteger("Movimento", 0);

                if (Time.time - lastAttackTime >= attackCooldown)
                {
                    Vida playerVida = target.GetComponent<Vida>();
                    if (playerVida != null)
                        playerVida.TomarDano(danoDoInimigo);

                    lastAttackTime = Time.time;
                }
                return;
            }

            animator.SetInteger("Movimento", 1);
            direction = (target.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
        else
        {
            animator.SetInteger("Movimento", 0);
        }
    }
}