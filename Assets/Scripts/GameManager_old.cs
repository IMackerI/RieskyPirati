using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldGameManager : MonoBehaviour
{
    //public static GameManager instance { get; private set; }
    public enum State { MENU, PLAY, ATTACK, WIN, LOSE };

    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    public GameObject menuScreen;
    public GameObject playerHealth;
    public GameObject enemyHealth;
    public GameObject playerDamage;
    public GameObject enemyDamage;
    public GameObject playerCoins;
    public GameObject enemyCoins;
    
    State _state;
    GameObject _player;
    GameObject _enemy;

    bool _enemyTurn = false;
    bool _attacking = false;

    /*
    public void Start()
    {
        instance = this;
        Switchstate(State.PLAY);
    }
    */

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

    IEnumerator DamageDelay(SliderScript damage, float delay, bool playerA)
    {
        yield return new WaitForSeconds(delay);
        if (playerA)
        {
            damage.SetValue(_enemy.GetComponent<Enemy>().health);
        }
        else
        {
            damage.SetValue(_player.GetComponent<Clovek>().health);
        }
        
    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                menuScreen.SetActive(true);
                break;
        }

    }

    void EndState()
    {
        switch (_state)
        {
            case State.MENU:
                menuScreen.SetActive(false);
                CreatePlayer(100, 40, 1000);
                CreateEnemy(100, 10, 1000);
                playerHealth.GetComponent<SliderScript>().SetMaxValue(100);
                enemyHealth.GetComponent<SliderScript>().SetMaxValue(100);
                break;
            case State.ATTACK:
                _attacking = false;
                break;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case State.MENU:
                break;
            case State.PLAY:
                if (_player.GetComponent<Clovek>().health <= 0)
                {
                    Debug.Log("You lose");
                    Switchstate(State.LOSE);
                }
                else if(_enemy.GetComponent<Enemy>().health <= 0)
                {
                    Debug.Log("You win");
                    Switchstate(State.WIN);
                }
                else if (!_attacking)
                {
                    Debug.Log(_state);
                    if (_enemyTurn)
                    {
                        _enemyTurn = false;
                        _attacking = true;
                        PlayerAttack();
                        int damage = (int)(Random.Range(0.8f, 1.2f) * _player.GetComponent<Clovek>().damage);
                        _enemy.GetComponent<Enemy>().health -= damage;
                        StartCoroutine(DamageDelay(enemyHealth.GetComponent<SliderScript>(), 1.5f, true));
                    }
                    else
                    {
                        _enemyTurn = true;
                        _attacking = true;
                        EnemyAttack();
                        int damage = (int)(Random.Range(0.8f, 1.2f) * _enemy.GetComponent<Enemy>().damage);
                        _player.GetComponent<Clovek>().health -= damage;
                        StartCoroutine(DamageDelay(playerHealth.GetComponent<SliderScript>(), 1.5f, false));
                    }
                    Switchstate(State.ATTACK, 4);
                }
                break;
            case State.ATTACK:
                Switchstate(State.PLAY);
                break;
            case State.WIN:
                break;
            case State.LOSE:
                break;

        }
    }

    void CreatePlayer(int health, int damage, int coins)
    {
        _player = Instantiate(PlayerPrefab);
        _player.GetComponent<Clovek>().health = health;
        _player.GetComponent<Clovek>().damage = damage;
        _player.GetComponent<Clovek>().coins = coins;
    }
    void CreateEnemy(int health, int damage, int coins)
    {
        _enemy = Instantiate(EnemyPrefab);
        _enemy.GetComponent<Enemy>().health = health;
        _enemy.GetComponent<Enemy>().damage = damage;
        _enemy.GetComponent<Enemy>().coins = coins;
    }

    void PlayerAttack()
    {
        _player.GetComponent<Clovek>().Attack();
    }
    void EnemyAttack()
    {
        _enemy.GetComponent<Enemy>().Attack();
    }

}
