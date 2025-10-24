using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using  UnityEngine.Rendering;
using UnityEngine.UI;

public class ControleDeAudio : MonoBehaviour
{

    public int Volume;
    public int VolumeSFX;
    public bool Musica;
    
    public Slider volumeSlider; 
    public Slider volumeSFXSlider;
    public Toggle ToggleMusica;
    public TMP_Text TextoMusica;
    
    void Start()
    {
        Musica = ToggleMusica.isOn;
        Volume = (int)volumeSlider.value;
        VolumeSFX = (int)volumeSFXSlider.value;
    }

    
    void Update()
    {
        Musica = ToggleMusica.isOn;
        Volume = (int)volumeSlider.value;
        VolumeSFX = (int)volumeSFXSlider.value;

        if (Musica == true)
        {
            TextoMusica.text = "ligado";
            TextoMusica.color = Color.green;
            
        }
        else
        {
            TextoMusica.text = "Desligado";
            TextoMusica.color = Color.red;
            
        }
    }
}