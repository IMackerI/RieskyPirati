using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public enum State { ATTACK_1, ATTACK_2, WIN_1, WIN_2 };

    public Entity Player1;
    public Entity Player2;

    State _state;

    public void Start()
    {
        instance = this;
        Switchstate(State.ATTACK_1);
    }

    public void Switchstate(State newState, float delay = 0)
    {
        StartCoroutine(SwitchDelay(newState, delay));
    }

    IEnumerator SwitchDelay(State newState, float delay)
    {
        //Debug.Log("Switching state");
        EndState();
        yield return new WaitForSeconds(delay);
        _state = newState;
        BeginState(newState);
        //Debug.Log("Switched state");
    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.ATTACK_1:
                Player1.Attack();
                break;
            case State.ATTACK_2:
                Player2.Attack();
                break;
            case State.WIN_1:
                break;
            case State.WIN_2:
                break;
            default:
                break;
        }
    }

    void EndState()
    {
        switch (_state)
        {
            case State.ATTACK_1:
                if (Player2.Alive())
                {
                    Switchstate(State.ATTACK_2);
                }
                else
                {
                    Switchstate(State.WIN_1);
                }
                break;
            case State.ATTACK_2:
                if (Player1.Alive())
                {
                    Switchstate(State.ATTACK_1);
                }
                else
                {
                    Switchstate(State.WIN_2);
                }
                break;
            case State.WIN_1:
                break;
            case State.WIN_2:
                break;
            default:
                break;
        }
    }
}