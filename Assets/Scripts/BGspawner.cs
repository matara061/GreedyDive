using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGspawner : MonoBehaviour
{
    public GameObject[] backgroundPrefabs; // O array de prefabs das imagens de fundo
    public Vector2 spawnPoint; // O ponto onde a imagem de fundo deve ser instanciada
    public float spawnInterval = 3f; // O intervalo em segundos entre cada inst�ncia
    public GameObject parentObject; // O objeto que ser� o pai dos backgrounds instanciados

    void Start()
    {
        // Inicia a corotina para instanciar a imagem de fundo a cada 'spawnInterval' segundos
        StartCoroutine(SpawnBackground());
    }

    IEnumerator SpawnBackground()
    {
        while (true)
        {
            // Seleciona um prefab de background aleat�rio
            GameObject backgroundPrefab = backgroundPrefabs[Random.Range(0, backgroundPrefabs.Length)];

            // Instancia a imagem de fundo no ponto especificado
            GameObject background = Instantiate(backgroundPrefab, spawnPoint, Quaternion.identity);

            // Define o objeto pai do background
            background.transform.SetParent(parentObject.transform);

            // Aguarda 'spawnInterval' segundos antes de instanciar a pr�xima imagem de fundo
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
