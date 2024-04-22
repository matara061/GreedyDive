using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressaoDano : MonoBehaviour
{

    public Player player;
    public DivingSceneManager diveManager;

    public float depth;
    public int Dano;
    public bool IsInvoke = false;


    IEnumerator ChamaDanoCoroutine;

    void Update()
    {
        depth = diveManager.depth;

        if (depth > 50 && depth < 80 && ChamaDanoCoroutine == null)
        {
            Dano = 1;
            ChamaDanoCoroutine = ChamaDano();
            StartCoroutine(ChamaDanoCoroutine);
        }
        else if (depth > 80 && depth < 130 && Dano != 2)
        {
            StopCoroutine(ChamaDanoCoroutine);
            ChamaDanoCoroutine = null;
            Dano = 2;
            ChamaDanoCoroutine = ChamaDano();
            StartCoroutine(ChamaDanoCoroutine);
        }
        else if (depth > 130 && depth < 180 && Dano != 3)
        {
            StopCoroutine(ChamaDanoCoroutine);
            ChamaDanoCoroutine = null;
            Dano = 3;
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
