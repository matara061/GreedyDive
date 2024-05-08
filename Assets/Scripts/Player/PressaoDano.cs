using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressaoDano : MonoBehaviour
{

    public Player player;
    public DivingSceneManager diveManager;

    public float depth;
    public float Dano;
    public bool IsInvoke = false;


    IEnumerator ChamaDanoCoroutine;

    void Update()
    {
        depth = diveManager.depth;

        if (depth > 100 && depth < 500 && ChamaDanoCoroutine == null)
        {
            Dano = 0.5f;
            ChamaDanoCoroutine = ChamaDano();
            StartCoroutine(ChamaDanoCoroutine);
        }
        else if (depth > 500 && depth < 1000 && Dano != 1.5f)
        {
            StopCoroutine(ChamaDanoCoroutine);
            ChamaDanoCoroutine = null;
            Dano = 1.5f;
            ChamaDanoCoroutine = ChamaDano();
            StartCoroutine(ChamaDanoCoroutine);
        }
        else if (depth > 1000 && depth < 1500 && Dano != 2)
        {
            StopCoroutine(ChamaDanoCoroutine);
            ChamaDanoCoroutine = null;
            Dano = 2;
            ChamaDanoCoroutine = ChamaDano();
            StartCoroutine(ChamaDanoCoroutine);
        }
        else if (depth > 1500 && depth < 2000 && Dano != 2.5f)
        {
            StopCoroutine(ChamaDanoCoroutine);
            ChamaDanoCoroutine = null;
            Dano = 2.5f;
            ChamaDanoCoroutine = ChamaDano();
            StartCoroutine(ChamaDanoCoroutine);
        }
        else if (depth > 2000 && depth < 2500 && Dano != 3)
        {
            StopCoroutine(ChamaDanoCoroutine);
            ChamaDanoCoroutine = null;
            Dano = 3;
            ChamaDanoCoroutine = ChamaDano();
            StartCoroutine(ChamaDanoCoroutine);
        }
        else if (depth > 2500 && depth < 3000 && Dano != 3.5f)
        {
            StopCoroutine(ChamaDanoCoroutine);
            ChamaDanoCoroutine = null;
            Dano = 3.5f;
            ChamaDanoCoroutine = ChamaDano();
            StartCoroutine(ChamaDanoCoroutine);
        }
    }

    IEnumerator ChamaDano()
    {
        while (true)
        {
            player.ContinuosDamage(Dano);
            yield return new WaitForSeconds(1f);
        }
    }

}
