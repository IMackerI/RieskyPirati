using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State { MENU, STAT, IDLE, LEFTATTACK, RIGHTATTACK, WIN, LOSE };
    State _state;

    public GameObject menuScreen;
    public GameObject statScreen;
    public GameObject gameScreen;
    public GameObject winScreen;
    public GameObject loseScreen;

    public GameObject lPlayerManager;
    public GameObject rPlayerManager;
    LPlayerManager lPlayer;
    RPlayerManager rPlayer;

    

    // Start is called before the first frame update
    void Start()
    {
        lPlayer = lPlayerManager.GetComponent<LPlayerManager>();
        rPlayer = rPlayerManager.GetComponent<RPlayerManager>();
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

    public void StatsPlay()
    {
        
    }

    public void MenuPlay()
    {
        
    }

}
