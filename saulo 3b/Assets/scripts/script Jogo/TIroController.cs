using UnityEngine;

public class TiroController : MonoBehaviour
{
    public GameObject tiro;
    public Transform SaidaTiro;
    void Update()
    {
        tiroController();
    }

    void tiroController()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(tiro, SaidaTiro.position, transform.rotation);
        }
    }
}