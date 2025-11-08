using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float velocidade = 10f; 

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * velocidade);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(gameObject); 
        // Destroy(collision.gameObject);
    }
}