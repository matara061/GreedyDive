using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diario : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameManager gameManager;

    public GameObject[] _contentBox;
    public GameObject[] _aviso;


    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        DisplayDiario();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayDiario()
    {
        if(gameManager != null)
        {
            if(gameManager.Profundidade >= 4000)
            {
                for(int i = 0;  i < _contentBox.Length; i++)
                {
                    _contentBox[i].gameObject.SetActive(true);
                    _aviso[i].gameObject.SetActive(false);
                }
            }else
                if(gameManager.Profundidade >= 3500 && gameManager.Profundidade < 4000)
            {
                for (int i = 0; i < _contentBox.Length - 1; i++)
                {
                    _contentBox[i].gameObject.SetActive(true);
                    _aviso[i].gameObject.SetActive(false);
                }
            }
            else if(gameManager.Profundidade >= 3000 && gameManager.Profundidade < 3500)
            {
                for (int i = 0; i < _contentBox.Length - 2; i++)
                {
                    _contentBox[i].gameObject.SetActive(true);
                    _aviso[i].gameObject.SetActive(false);
                }
            }
            else if (gameManager.Profundidade >= 2500 && gameManager.Profundidade < 3000)
            {
                for (int i = 0; i < _contentBox.Length - 3; i++)
                {
                    _contentBox[i].gameObject.SetActive(true);
                    _aviso[i].gameObject.SetActive(false);
                }
            }
            else if (gameManager.Profundidade >= 2000 && gameManager.Profundidade < 2500)
            {
                for (int i = 0; i < _contentBox.Length - 4; i++)
                {
                    _contentBox[i].gameObject.SetActive(true);
                    _aviso[i].gameObject.SetActive(false);
                }
            }
            else if (gameManager.Profundidade >= 1500 && gameManager.Profundidade < 2000)
            {
                for (int i = 0; i < _contentBox.Length - 5; i++)
                {
                    _contentBox[i].gameObject.SetActive(true);
                    _aviso[i].gameObject.SetActive(false);
                }
            }
            else if (gameManager.Profundidade >= 1000 && gameManager.Profundidade < 1500)
            {
                for (int i = 0; i < _contentBox.Length - 6; i++)
                {
                    _contentBox[i].gameObject.SetActive(true);
                    _aviso[i].gameObject.SetActive(false);
                }
            }
            else if (gameManager.Profundidade >= 500 && gameManager.Profundidade < 1000)
            {
                for (int i = 0; i < _contentBox.Length - 7; i++)
                {
                    _contentBox[i].gameObject.SetActive(true);
                    _aviso[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
