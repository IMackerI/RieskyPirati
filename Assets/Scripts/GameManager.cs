using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State { /*MENU,*/ STAT, IDLE, LEFTATTACK, RIGHTATTACK, WIN, LOSE };
    State _state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Switchstate(State newState, float delay = 0)
    {
        StartCoroutine(SwitchDelay(newState, delay));
    }
    IEnumerator SwitchDelay(State newState, float delay)
    {
        yield return new WaitForSeconds(delay);
        EndState();
        _state = newState;
        BeginState(newState);
    }

    void BeginState(State newState)
    {

    }

    void EndState()
    {
        
    }

        // Update is called once per frame
    void Update()
    {
        
    }
}
