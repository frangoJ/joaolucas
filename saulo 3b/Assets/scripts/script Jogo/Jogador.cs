using System;
using UnityEngine;

public class Jogador : Personagem
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody22D>();
    }

    void Update()
    {
        // pegar entrada
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.A))
            moveX = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveX = 1f;

        if (Input.GetKey(KeyCode.W))
            moveY = 1f;
        else if (Input.GetKey(KeyCode.S))
            moveY = -1f;

        Vector2 movimento = new Vector2(moveX, moveY).normalized * getVelocidade();
        rb.velocity = movimento;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Inimigo")
        {
            int Vida = getVida() - 1;
            setVida(Vida);
        }
    }
}