using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            vidaAtual = 0;
            Destroy(gameObject); // destrói quando morre
        }
    }
}