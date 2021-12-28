using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private void Awake() {
        instance = this;
    }

    public Text printScore;

    public int score = 0;
    private int trackScore = 5;

    // 점수 표시하기 
    public void GetScoreTrack() {
        score += trackScore;
        printScore.text = "" + score;
    }

    // 점수 초기화 
    public void ResetScore() {
        score = 0;
        printScore.text = "" + score;
    }
}
