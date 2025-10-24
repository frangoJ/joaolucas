using System;
using UnityEngine;

public class Jogador : Personagem
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-getVelocidade() * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(getVelocidade() * Time.deltaTime, 0, 0);
        }

        
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, getVelocidade() * Time.deltaTime, 0);
        }

        
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -getVelocidade() * Time.deltaTime, 0);
        }
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