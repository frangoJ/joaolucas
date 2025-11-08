using System;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    [SerializeField] float velocidade;
    void Start()
    {
        Destroy(gameObject, 4f); 
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * velocidade);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Destroy((other.gameObject)); 
            Destroy(gameObject);
        }
    }
}
