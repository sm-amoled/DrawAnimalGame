using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    // 메뉴 보드를 찾아 저장함.
    private GameObject menu; 
    private GameObject countDownImage;

    public GameObject StartMenu;
    public GameObject Blur;

    private void Start() {
        menu = this.gameObject.transform.GetChild(1).gameObject;
        countDownImage = this.gameObject.transform.GetChild(2).gameObject;
    }

    private float duration = 2f;
    private float slideSpeed = 6f;
    private Vector3 SetPos = new Vector3(Screen.width * .5f, Screen.height * .5f, 0);
    private Vector3 DissetPos = new Vector3(Screen.width * .5f, Screen.width * -0.5f, 0);

    public Sprite[] countDownImageSource = new Sprite[3];

    // 메뉴판 띄우기
    public void EnablePanel() {
        Blur.SetActive(true);
        StartCoroutine(MenuSliderUp(menu, SetPos));
    }

    // 메뉴판 접어내리기
    public void KeepPlaying() {
        StartCoroutine(MenuSliderDown(menu, DissetPos));
        Blur.SetActive(false);
    }

    // 게임 새로시작하기
    public void RestartGame() {
        StartCoroutine (restartSlideDown(menu, DissetPos));
        Blur.SetActive(false);
        
    }

    // 메인 화면으로 이동
    public void GotoStartPage() {
        MusicManager.instance.PitchDown();
        StateManager.instance.Pause();
        TimerManager.instance.ResetTimer();
        Blur.SetActive(false);
        StartMenu.SetActive(true);
        menu.SetActive(false);
    }

    // 일시정지 패널을 끌어올리는 역할을 함
    IEnumerator MenuSliderUp(GameObject rt, Vector3 targetPos) {

        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        StateManager.instance.currentState = StateManager.State.pause;

        rt.SetActive(true);

        float elapsed = 0.0f;

        while(true) {
            elapsed += Time.deltaTime;
            rt.GetComponent<RectTransform>().position = Vector2.Lerp(rt.GetComponent<RectTransform>().position, targetPos, elapsed / duration * slideSpeed);

            yield return wait;

            if(rt.GetComponent<RectTransform>().position.y >= Screen.height * -0.5f)
                break;
        }
        rt.GetComponent<RectTransform>().position = targetPos;
        yield return null;
    }

    // 일시정지 패널을 다시 내리는 역할을 함 ( 계속하기 )
    IEnumerator MenuSliderDown(GameObject rt, Vector2 targetPos) {
        
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        float elapsed = 3.0f;
        countDownImage.SetActive(true);

        while(true) {
            elapsed -= 0.07f;
            rt.GetComponent<RectTransform>().Translate(new Vector2(0, -20));
            yield return wait;

            if(rt.GetComponent<RectTransform>().position.y <= Screen.height * -0.5f)
                break;
            Debug.Log(elapsed);

            if(elapsed > 0 && elapsed < 3)
                countDownImage.GetComponent<Image>().sprite = countDownImageSource[(int)elapsed];
        }

        rt.GetComponent<RectTransform>().position = targetPos;
        rt.SetActive(false);
        countDownImage.GetComponent<Image>().sprite = null;
        countDownImage.SetActive(false);
        StateManager.instance.KeepPlay();

        yield return null;
    }

    IEnumerator restartSlideDown(GameObject rt, Vector2 targetPos) {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        resetGame();

        while(rt.GetComponent<RectTransform>().position.y > Screen.height * -0.5f) {

            rt.GetComponent<RectTransform>().Translate(new Vector2(0, -60));
            yield return wait;
        }
        rt.GetComponent<RectTransform>().position = targetPos;
        rt.SetActive(false);
        StateManager.instance.KeepPlay();

        yield return null;
    }

    // 게임을 새로 시작하기 위해 초기화해줌 
    private void resetGame() {
        TimerManager.instance.Start();
        LeftTrackSpawnManager.instance.Start();
        RightTrackSpawnManager.instance.Start();
        ScoreManager.instance.ResetScore();
    }
}
