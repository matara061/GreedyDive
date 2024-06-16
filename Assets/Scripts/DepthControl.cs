using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthControl : MonoBehaviour
{

    [SerializeField] private DivingSceneManager _divingScene;

    [SerializeField] private float _depth;
    [SerializeField] private bool _fase1, _fase2, _fase3 = false;

    [Header("Predadores Spawners")]
    [SerializeField] private GameObject[] _predadorBox;

    [Header("Peixes Spawners")]
    [SerializeField] private GameObject[] _peixesBox;

    [Header("Obstaculos Spawners")]
    [SerializeField] private GameObject[] _obstaculosBox;

    void Start()
    {
        _divingScene = FindAnyObjectByType<DivingSceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_divingScene != null)
        {
            ControlSpawner();
        }
        else
        {
            _divingScene = FindAnyObjectByType<DivingSceneManager>();
            ControlSpawner();
        }

        _depth = _divingScene.depth;
    }

    private void ControlSpawner()
    {
        if(_depth >= 1000 &&  _depth < 2000)
        {
            Fase1();
        }
        else if(_depth >= 2000 && _depth < 3000)
        {
            Fase2();
        }
        else if (_depth >= 3000 && _depth < 4000)
        {
            Fase3();
        }
        
    }

    private void Fase1()
    {
        if(!_fase1)
        {
            _fase1 = true;
            _predadorBox[0].SetActive(false);
            _peixesBox[0].SetActive(false);
            _obstaculosBox[0].SetActive(false);
            _predadorBox[1].SetActive(true);
            _peixesBox[1].SetActive(true);
            _obstaculosBox[1].SetActive(true);

        }
    }

    private void Fase2()
    {
        if (!_fase2)
        {
            _fase1 = false;
            _fase2 = true;
            _predadorBox[1].SetActive(false);
            _peixesBox[1].SetActive(false);
            _obstaculosBox[1].SetActive(false);
            _predadorBox[2].SetActive(true);
            _peixesBox[2].SetActive(true);
            _obstaculosBox[2].SetActive(true);

        }
    }

    private void Fase3()
    {
        if (!_fase3)
        {
            _fase1 = false;
            _fase2 = false;
            _fase3 = true;
            _predadorBox[2].SetActive(false);
            _peixesBox[2].SetActive(false);
            _obstaculosBox[2].SetActive(false);
            _predadorBox[3].SetActive(true);
            _peixesBox[3].SetActive(true);
            _obstaculosBox[3].SetActive(true);

        }
    }
}
