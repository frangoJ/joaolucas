using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float speed;
    private Vector2 movement;
    private Animator animator;
    private float IntitialSpeed;
    public float RunSpeed;

    private bool atack = false;
    public int danoDoPlayer = 20;

    public float attackRange = 1f; // alcance do ataque
    public string inimigoTag = "Inimigo"; // definir a tag do inimigo no Inspector

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
        IntitialSpeed = speed;
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement.sqrMagnitude > 0)
            animator.SetInteger("Movimento", 1);
        else
            animator.SetInteger("Movimento", 0);

        Flip();
        playerRun();
        onatack();

        if (atack)
            animator.SetInteger("Movimento", 2);
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        if (movement.x > 0)
            transform.eulerAngles = new Vector2(0f, 0f);
        else if (movement.x < 0)
            transform.eulerAngles = new Vector2(0f, 180f);
    }

    void playerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed = RunSpeed;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = IntitialSpeed;
    }

    void onatack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            atack = true;
            speed = 0;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
            foreach (Collider2D col in colliders)
            {
                if (col.CompareTag(inimigoTag))
                {
                    Vida inimigoVida = col.GetComponent<Vida>();
                    if (inimigoVida != null)
                        inimigoVida.TomarDano(danoDoPlayer);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            atack = false;
            speed = IntitialSpeed;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
