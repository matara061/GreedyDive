using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public void Resume()
    {
        SceneManager.UnloadSceneAsync("Pause");
    }

    public void Desistir()
    {

    }
}
