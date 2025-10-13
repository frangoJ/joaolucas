using UnityEngine;
using UnityEngine.UI;

public class PainelDeVida : MonoBehaviour
{
    public Personagem Personagem;
    
    public Slider SliderVida;
    public Slider SliderEnergia;
    
    void Start()
    {
        SliderVida.minValue = 0;
        SliderVida.maxValue = Personagem.getVida();

        
        SliderEnergia.minValue = 0;
        SliderEnergia.maxValue = Personagem.getEnergia();
        
    }

    void Update()
    {
        SliderVida.value = Personagem.getVida();
        SliderEnergia.value = Personagem.getEnergia();
    }
}
