using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {  get; private set; }

    public event EventHandler OnstateChanged;
    public event EventHandler GamePaused;
    public event EventHandler UnGamePaused;

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
    private float gameplayingTimmer;
    private float gameplayingTimmerMax = 100f;
    private bool isGamePaused = false;

    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }

    private void Start()
    {
        PlayerInputs.Instance.OnPauseAction += PlayerInputs_OnPauseAction;
    }

    private void PlayerInputs_OnPauseAction(object sender, EventArgs e)
    {
        PauseGame();
    }

    private void Update()
    {
        switch (state) { 
        
        case State.WaitingToStart:
                watigToStartTimmer -= Time.deltaTime;
                if(watigToStartTimmer < 0f)
                {
                    state = State.CountdownToStart;
                    OnstateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimmer -= Time.deltaTime;
                if (countdownToStartTimmer < 0f)
                {
                    state = State.GamePlaying;
                    gameplayingTimmer = gameplayingTimmerMax;
                    OnstateChanged?.Invoke(this, EventArgs.Empty);

                }
                break;
            case State.GamePlaying:
                gameplayingTimmer -= Time.deltaTime;
                if (gameplayingTimmer < 0f)
                {
                    state = State.GameOver;
                    OnstateChanged?.Invoke(this, EventArgs.Empty);

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

    public bool IsCountDownToStartActive() { return state == State.CountdownToStart; }

    public float GetCountDownToStartTimer()
    {
        return countdownToStartTimmer;
    }

    public bool IsGameOver()
    {

    return state == State.GameOver; }

    public float GetPlayerTimmerNormalize()
    {
        return 1 - (gameplayingTimmer / gameplayingTimmerMax);
    }

    public void PauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f;
            GamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1f;
            UnGamePaused?.Invoke(this, EventArgs.Empty);

        }
    }


}


