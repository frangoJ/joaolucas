using UnityEngine;

public class Inimigo : Personagem
{
    [SerializeField] private int dano = 1;
    public float raioDeVisao = 5;
    public CircleCollider2D _visaoCollider2D;
    [SerializeField] private Transform posicaoDoPlayer;

    private SpriteRenderer spriteRenderer;

    public void setDano(int dano)
    {
        this.dano = dano;
    }

    public int getDano()
    {
        return this.dano;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (posicaoDoPlayer == null)
        {
            posicaoDoPlayer = GameObject.Find("Player").transform;
        }

        raioDeVisao = _visaoCollider2D.radius;
    }

    void Update()
    {
        if (getVida() > 0 && posicaoDoPlayer != null)
        {
            if (Vector3.Distance(posicaoDoPlayer.position, transform.position) <= raioDeVisao)
            {
                Vector3 direcao = new Vector3(posicaoDoPlayer.position.x - transform.position.x, 0, 0).normalized;

                transform.position += direcao * getVelocidade() * Time.deltaTime;

                spriteRenderer.flipX = (direcao.x < 0);
            }
        }
    }

    public void desativa()
    {
        Destroy(gameObject);
        Debug.Log("Inimigo destruído.");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && getVida() > 0)
        {
            int novaVida = collision.gameObject.GetComponent<Personagem>().getVida() - getDano();
            collision.gameObject.GetComponent<Personagem>().setVida(novaVida);
            setVida(0);
        }
    }
}