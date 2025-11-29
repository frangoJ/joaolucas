using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Vida vida;
    public Slider slider;

    void Start()
    {
        if (vida != null && slider != null)
        {
            slider.maxValue = vida.vidaMaxima;
            slider.value = vida.vidaAtual;
        }
    }

    void Update()
    {
        if (vida != null && slider != null)
        {
            slider.value = vida.vidaAtual;
        }
    }
}