using UnityEngine;
using System.Collections.Generic;

public class GeradorInimigo : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject inimigoPrefab;
    [SerializeField] private int maxInimigos = 5; // limite de inimigos simultâneos

    private List<GameObject> inimigosAtivos = new List<GameObject>();

    void Start()
    {
        InvokeRepeating(nameof(SpawnInimigo), 1f, 2f);
    }

    void SpawnInimigo()
    {
        
        inimigosAtivos.RemoveAll(inimigo => inimigo == null);

        
        if (inimigosAtivos.Count < maxInimigos)
        {
            int index = Random.Range(0, spawnPoints.Length);
            GameObject novo = Instantiate(inimigoPrefab, spawnPoints[index].position, Quaternion.identity);
            inimigosAtivos.Add(novo);
        }
    }
}