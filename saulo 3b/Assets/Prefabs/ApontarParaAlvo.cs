using UnityEngine;

public class ApontarParaAlvo : MonoBehaviour
{
    // Defina o objeto alvo que esta nave deve olhar.
    // Você pode arrastar a outra nave para este campo no Inspector.
    public Transform alvo; 

    // Opcional: Se a sprite da sua nave estiver originalmente apontando para cima,
    // para baixo ou para outro lado, você pode precisar de um ajuste de ângulo.
    // Experimente com 0, 90, 180, -90 (ou 270)
    public float ajusteDeAngulo = 90f; // Exemplo: Se sua sprite aponta para a direita (0 graus), e o vetor "para cima" do sprite é o "nariz", 90 graus para girar para a direção do alvo.

    void Update()
    {
        // Certifique-se de que há um alvo definido
        if (alvo != null)
        {
            // 1. Calcula a direção do alvo em relação a esta nave
            Vector3 direcaoParaAlvo = alvo.position - transform.position;

            // 2. Calcula o ângulo em graus a partir da direção
            // Mathf.Atan2 retorna o ângulo em radianos entre o eixo X positivo e o vetor.
            // Multiplicamos por Mathf.Rad2Deg para converter para graus.
            // O -90f é um ajuste comum se sua sprite "para cima" for a frente da nave.
            float angulo = Mathf.Atan2(direcaoParaAlvo.y, direcaoParaAlvo.x) * Mathf.Rad2Deg + ajusteDeAngulo;

            // 3. Aplica a rotação ao Transform da nave
            // Quaternion.Euler cria uma rotação a partir de ângulos de Euler (X, Y, Z).
            // Em 2D, geralmente só precisamos ajustar o Z.
            transform.rotation = Quaternion.Euler(0f, 0f, angulo);
        }
    }
}