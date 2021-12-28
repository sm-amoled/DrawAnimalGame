using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public static MainMenuScript instance;

    private void Awake() {
        instance = this;
    }

    public GameObject CatL;
    public GameObject CatR;
    public GameObject DuckL;
    public GameObject DuckR;
    public GameObject PenguinL;
    public GameObject PenguinR;
    public GameObject SheepL;
    public GameObject SheepR;

    // 버튼의 위치를 받아오기 위함임.
    public Button Cat;
    public Button Duck;
    public Button Penguin;
    public Button Sheep;

    public GameObject CheckImage;

    public int maxScore = 0;
    public Text scoreText;

    public GameObject mainMenuCanvas;

    // 캐릭터를 고르면 다음 중 하나의 값을 가진다.
    enum character {
        cat, duck, penguin, sheep
    }
    private character characterChooseSet = character.sheep;

    private void Start() {
        CatL.SetActive(false);
        CatR.SetActive(false);
        DuckL.SetActive(false);
        DuckR.SetActive(false);
        PenguinL.SetActive(false);
        PenguinR.SetActive(false);
        SheepL.SetActive(true);
        SheepR.SetActive(true);
    }

    // 캐릭터 선택 버튼
    // 버튼을 누르면 해당 캐릭터만 활성화 하고 나머지 동물은 비활성화 + 이미지에 선택되었다는 네모 박스를 표시
    public void ChooseCat () {
        Debug.Log("Choose Cat");
        characterChooseSet = character.cat;

        CatL.SetActive(true);
        CatR.SetActive(true);
        DuckL.SetActive(false);
        DuckR.SetActive(false);
        PenguinL.SetActive(false);
        PenguinR.SetActive(false);
        SheepL.SetActive(false);
        SheepR.SetActive(false);

        CheckImagePointing();
        SoundEffect.instance.ButtonSound();

    }

    public void ChooseDuck() {
        Debug.Log("Choose Duck");
        characterChooseSet = character.duck;

        CatL.SetActive(false);
        CatR.SetActive(false);
        DuckL.SetActive(true);
        DuckR.SetActive(true);
        PenguinL.SetActive(false);
        PenguinR.SetActive(false);
        SheepL.SetActive(false);
        SheepR.SetActive(false);

        CheckImagePointing();
        SoundEffect.instance.ButtonSound();


    }

    public void ChoosePenguin() {
        Debug.Log("Choose Penguin");
        characterChooseSet = character.penguin;

        CatL.SetActive(false);
        CatR.SetActive(false);
        DuckL.SetActive(false);
        DuckR.SetActive(false);
        PenguinL.SetActive(true);
        PenguinR.SetActive(true);
        SheepL.SetActive(false);
        SheepR.SetActive(false);

        CheckImagePointing();
        SoundEffect.instance.ButtonSound();


    }

    public void ChooseSheep() {
        Debug.Log("Choose Sheep");
        characterChooseSet = character.sheep;

        CatL.SetActive(false);
        CatR.SetActive(false);
        DuckL.SetActive(false);
        DuckR.SetActive(false);
        PenguinL.SetActive(false);
        PenguinR.SetActive(false);
        SheepL.SetActive(true);
        SheepR.SetActive(true);

        CheckImagePointing();
        SoundEffect.instance.ButtonSound();


    }

    // 동물이 선택되었음을 알리는 이미지를 띄운다.
    private void CheckImagePointing() {
                switch(characterChooseSet) {
            case character.cat :
                    CheckImage.GetComponent<RectTransform>().localPosition = Cat.GetComponent<RectTransform>().localPosition;
                break;

            case character.duck:
                    CheckImage.GetComponent<RectTransform>().localPosition = Duck.GetComponent<RectTransform>().localPosition;
                break;

            case character.penguin:
                    CheckImage.GetComponent<RectTransform>().localPosition = Penguin.GetComponent<RectTransform>().localPosition;;
                break;

            case character.sheep:
                    CheckImage.GetComponent<RectTransform>().localPosition = Sheep.GetComponent<RectTransform>().localPosition;
                break;
        }
    }

    public void StartButton() {
        mainMenuCanvas.SetActive(false);
        
        TimerManager.instance.Start();
        LeftTrackSpawnManager.instance.Start();
        RightTrackSpawnManager.instance.Start();
        ScoreManager.instance.ResetScore();
        StateManager.instance.KeepPlay();
    }

    public void PrintScore() {
        scoreText.text = ": " + maxScore.ToString();
    }

    public void updateScore(int value) {
        if(value > maxScore) {
            maxScore = value;
        }
    }
}
