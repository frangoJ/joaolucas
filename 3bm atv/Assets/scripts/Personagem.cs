using UnityEngine;

public class Personagem : MonoBehaviour
{
    
    [SerializeField] public int Vida;
    [SerializeField] private int Energia;
    [SerializeField] private float Velocidade;
    
    public void setVida(int vida)
    {
        this.Vida = vida;
    }

    public int getVida()
    {
        return this.Vida;
    }
    
    public void setEnergia(int energia)
    {
        this.Energia = energia;
    }

    public int getEnergia()
    {
        return this.Energia;
    }
    
    public void setVelocidade(float velocidade)
    {
        this.Velocidade = velocidade;
    }
    
    public float getVelocidade()
    {
        return this.Velocidade;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
  
