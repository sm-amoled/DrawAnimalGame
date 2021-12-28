using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager instance;
    private void Awake() {
        instance = this;
    }

    public State currentState;

    private void Start() {
        currentState = State.pause;
    }

    public void KeepPlay() {
        currentState = State.play;
    }
    public void Pause() {
        currentState = State.pause;
    }
    
    public enum State {
        play, pause
    };
    
}
