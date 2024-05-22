using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;


public class testes : MonoBehaviour
{

    public TextMeshProUGUI warning;
    public Transform objectToTrack; // O objeto cujas coordenadas você quer rastrear


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToTrack != null)
        {
            // Obtém as coordenadas x e y do objeto
            float x = objectToTrack.position.x;
            float y = objectToTrack.position.y;
            float z = objectToTrack.position.z;

            // Atualiza o texto do componente TextMeshPro com as coordenadas
            warning.text = "X: " + x.ToString("F2") + ", Y: " + y.ToString("F2") + ", Z: " + z.ToString();
        }
        else
            warning.text = "destruido";
    }

    public void sair ()
    {
        SceneManager.LoadSceneAsync("BoatScene");
    }
}
