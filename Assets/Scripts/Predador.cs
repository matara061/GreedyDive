using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predador : MonoBehaviour
{
    public State currentState = State.Idle;

    void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                Debug.Log("Waiting...");
                break;

            case State.Attack:
                Debug.Log("Attacking!");
                break;

            case State.Retreat:
                Debug.Log("Run Away!");
                break;
        }
    }
}

[System.Serializable]
public enum State { Idle, Attack, Retreat }