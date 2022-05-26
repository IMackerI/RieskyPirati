using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    bool lAttack = true;
    public float attackDelay = 2f;
    public float endDelay = 1f;
    public float resetDelay = 10f;

    void Start()
    {
        lPlayer = lPlayerManager.GetComponent<LPlayerManager>();
        rPlayer = rPlayerManager.GetComponent<RPlayerManager>();
        _state = State.MENU;
        menuScreen.SetActive(true);
        statScreen.SetActive(false);
        gameScreen.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
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
        switch(newState)
        {
            case State.MENU:
                menuScreen.SetActive(true);
                break;
            case State.STAT:
                statScreen.SetActive(true);
                break;
            case State.IDLE:
                if (lPlayer.isDead) { Switchstate(State.LOSE, endDelay); }
                else if (rPlayer.isDead) { Switchstate(State.WIN, endDelay); }
                else if (lAttack) { Switchstate(State.LEFTATTACK, attackDelay); lAttack = false; }
                else { Switchstate(State.RIGHTATTACK, attackDelay); lAttack = true; }
                break;
            case State.LEFTATTACK:
                lPlayer.Attack();
                Switchstate(State.IDLE);
                break;
            case State.RIGHTATTACK:
                rPlayer.Attack();
                Switchstate(State.IDLE);
                break;
            case State.WIN:
                gameScreen.SetActive(false);
                winScreen.SetActive(true);
                lPlayer.WinCoins();
                Switchstate(State.MENU, resetDelay);
                break;
            case State.LOSE:
                gameScreen.SetActive(false);
                loseScreen.SetActive(true);
                lPlayer.LoseCoins();
                Switchstate(State.MENU, resetDelay);
                break;
        }
    }

    void EndState()
    {
        switch(_state)
        {
            case State.MENU:
                menuScreen.SetActive(false);
                break;
            case State.STAT:
                statScreen.SetActive(false);
                gameScreen.SetActive(true);
                lPlayer.Summon();
                rPlayer.Summon();
                break;
            case State.WIN:
                winScreen.SetActive(false);
                break;
            case State.LOSE:
                loseScreen.SetActive(false);
                break;
        }
    }

    public void MenuPlay(Button button)
    {
        int health;
        int attack;
        int coins;
        int i_clicked = int.Parse(button.name);
        health = int.Parse(GameObject.Find("Health" + i_clicked).GetComponent<Text>().text);
        attack = int.Parse(GameObject.Find("Attack" + i_clicked).GetComponent<Text>().text);
        coins = int.Parse(GameObject.Find("Coins" + i_clicked).GetComponent<Text>().text);;

        rPlayer.SetHealth(health);
        rPlayer.SetMaxHealth(health);
        rPlayer.SetAttack(attack);
        rPlayer.SetCoins(coins);

        Switchstate(State.STAT);
    }

    public void StatsPlay()
    {
        int health;
        int attack;
        int coins;
        health = int.Parse(GameObject.Find("InputHealth").GetComponent<InputField>().text);
        attack = int.Parse(GameObject.Find("InputAttack").GetComponent<InputField>().text);
        coins = int.Parse(GameObject.Find("InputCoins").GetComponent<InputField>().text);

        lPlayer.SetHealth(health);
        lPlayer.SetMaxHealth(health);
        lPlayer.SetAttack(attack);
        lPlayer.SetCoins(coins);

        Switchstate(State.IDLE);
    }

    public void PlayAgain()
    {
        Switchstate(State.MENU);
    }
}
