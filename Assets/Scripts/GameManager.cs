using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {  get; private set; }
    private enum State
    {
        WaitingToStart,
            CountdownToStart,
        GamePlaying,
        GameOver,
    }

   private State state;
    private float watigToStartTimmer = 1f;
    private float countdownToStartTimmer = 3f;
    private float gameplayingTimmer = 10f;

    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }

    private void Update()
    {
        switch (state) { 
        
        case State.WaitingToStart:
                watigToStartTimmer -= Time.deltaTime;
                if(watigToStartTimmer < 0f)
                {
                    state = State.CountdownToStart;
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimmer -= Time.deltaTime;
                if (countdownToStartTimmer < 0f)
                {
                    state = State.GamePlaying;
                }
                break;
            case State.GamePlaying:
                gameplayingTimmer -= Time.deltaTime;
                if (gameplayingTimmer < 0f)
                {
                    state = State.GameOver;
                }
                break;
                case State.GameOver:
                break;
        }
        Debug.Log(state);
    }

public bool IsGamePlaying()
    {

    return state == State.GamePlaying;
    }


}


