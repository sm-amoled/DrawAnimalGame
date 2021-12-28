using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    //SingleTon
    public static TimerManager instance;
    private void Awake() {
        instance = this;
    }

    private float LTIMER , RTIMER;
    // Timer의 기본 값은 100
    private float lTimer{
        get {
            return LTIMER;
        }
        set {
            if(value >= 100) 
                LTIMER = 100;
            else if(value <= 0) {
                LTIMER = 0;
                // Timer가 0보다 작으면 GameOver를 실행
                Gameover();
            }
            else
                LTIMER = value;
        }
    }
    private float rTimer{
        get {
            return RTIMER;
        }
        set {
            if(value >= 100) 
                RTIMER = 100;
            else if(value <= 0) {
                RTIMER = 0; 
                 Gameover();
            }
            else
                RTIMER = value;
        }
    }

    private float timerSpeed = 0.3f;

    public GameObject lTimerObject;
    public GameObject rTimerObject;


    public void Start() {
        lTimer = 100;
        rTimer = 100;
        SetTimer();
    }

    void Update() {
        // 타이머를 감소시킴
        switch(StateManager.instance.currentState) {
            case StateManager.State.play :
                SetTimer();
                lTimer -= timerSpeed;
                rTimer -= timerSpeed;

                if(lTimer < 50f || rTimer < 50f)
                    MusicManager.instance.PitchUp();
                else
                    MusicManager.instance.PitchDown();
            
                break;


            case StateManager.State.pause :
                // do nothing
                break;

        }

        timerSpeed = ScoreManager.instance.score / 100 + 0.3f;

        if(timerSpeed > 0.5f)
            timerSpeed = 0.5f;
    }

    // 타이머의 수치와 화면에 보이는 빨간 바를 일치시킴
    private void SetLTimer() {
        lTimerObject.transform.localScale = new Vector3(1f, lTimer/100f, 1f);
    }

    private void SetRTimer() {
        rTimerObject.transform.localScale = new Vector3(1f, rTimer/100f, 1f);
    }

    public void SetTimer() {
        SetLTimer();
        SetRTimer();
    }

    // Track의 끝까지 이동하면 타이머수치 +30
    public void Goal(char c) {
        switch(c) {
            case 'l':
                lTimer += 30;
                SetLTimer();
                break;

            case 'r':
                rTimer += 30;
                SetRTimer();
                break;
        }
    }

    // 타이머 값 초기화 
    public void ResetTimer() {
        lTimer = 100;
        rTimer = 100;
        SetTimer();
    }

    // 게임오버 띄우기
    public void Gameover() {
        GameOverScript.instance.GameOver();
    }
}
