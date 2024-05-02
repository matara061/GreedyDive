using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BGspawner : MonoBehaviour
{
    public GameObject backgroundPrefab; // O prefab da imagem de fundo
    public Vector2 spawnPoint; // O ponto onde a imagem de fundo deve ser instanciada
    public float spawnInterval = 3f; // O intervalo em segundos entre cada instância
    public GameObject parentObject; // O objeto que será o pai dos backgrounds instanciados

    void Start()
    {
        // Inicia a corotina para instanciar a imagem de fundo a cada 'spawnInterval' segundos
        StartCoroutine(SpawnBackground());
    }

    IEnumerator SpawnBackground()
    {
        while (true)
        {
            // Instancia a imagem de fundo no ponto especificado
            GameObject background = Instantiate(backgroundPrefab, spawnPoint, Quaternion.identity);

            // Define o objeto pai do background
            background.transform.SetParent(parentObject.transform);

            // Aguarda 'spawnInterval' segundos antes de instanciar a próxima imagem de fundo
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
