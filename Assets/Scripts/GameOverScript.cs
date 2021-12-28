using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject MenuCanvas;

    public Text ScoreText; 

    public static GameOverScript instance;
    private void Awake() {
        instance = this;
    }

    // 게임 오버가 되면 실행되는 메서드 
    public void GameOver() {
        GameOverPanel.SetActive(true);
        StateManager.instance.Pause();
        TimerManager.instance.ResetTimer();
        MusicManager.instance.PitchDown();

        ScoreText.text = "" + ((int) ScoreManager.instance.score).ToString();

        // 점수 출력
        MainMenuScript.instance.updateScore(ScoreManager.instance.score);
        MainMenuScript.instance.PrintScore();
    }

    // 게임 오버 화면에서 메뉴 버튼
    public void MenuButton() {
        GameOverPanel.SetActive(false);
        MenuCanvas.SetActive(true);
        ScoreManager.instance.ResetScore();
    }

    // 게임 오버 화면에서 리트라이 버튼
    public void RetryButton() {
        GameOverPanel.SetActive(false);

        TimerManager.instance.Start();
        LeftTrackSpawnManager.instance.Start();
        RightTrackSpawnManager.instance.Start();
        ScoreManager.instance.ResetScore();
        StateManager.instance.KeepPlay();
    }
}
