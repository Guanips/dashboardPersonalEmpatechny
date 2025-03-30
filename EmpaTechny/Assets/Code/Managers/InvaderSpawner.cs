using UnityEngine;
using System.Collections.Generic;

public class InvaderSpawner : MonoBehaviour
{
    public GameObject[] invaderPrefabs; // Array con 3 modelos de enemigos
    public Transform[] spawnPoints; // Array con los 5 puntos de spawn
    public float spawnInterval = 2f; // Tiempo entre spawns

    void Start()
    {
        InvokeRepeating(nameof(SpawnInvader), 0f, spawnInterval); // Spawnear repetidamente
    }

    private void SpawnInvader()
    {
        if (spawnPoints.Length == 0 || invaderPrefabs.Length == 0)
        {
            Debug.LogError("Spawn points or invader prefabs not assigned!");
            return;
        }

        // Selecciona un punto de spawn aleatorio
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Selecciona un modelo de enemigo aleatorio
        GameObject randomPrefab = invaderPrefabs[Random.Range(0, invaderPrefabs.Length)];

        // Crea el invader en ese punto
        GameObject invader = Instantiate(randomPrefab, randomSpawnPoint.position, Quaternion.identity, randomSpawnPoint.parent);

        // Ajusta la posición para asegurarse de que se alinea correctamente con el UI
        invader.GetComponent<RectTransform>().anchoredPosition = randomSpawnPoint.GetComponent<RectTransform>().anchoredPosition;
    }
}
