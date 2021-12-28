using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPosition : MonoBehaviour
{
    public Text text1;
    public Text text2;

    public Vector3 touchl;
    public Vector3 touchr;

    public Vector3 worldl;
    public Vector3 worldr;

    public GameObject targetL;
    public GameObject targetR;

    public static TouchPosition instance;

    void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
            LeftTrackSpawnManager.instance.DestroyTrack();
        if(Input.GetKeyDown(KeyCode.V))
            RightTrackSpawnManager.instance.DestroyTrack();

        // Touch가 2개 들어왔을 때
        if(Input.touchCount == 2) {  
            // 좌, 우 터치 구분하기
            if(Input.GetTouch(0).position.x < Screen.width * .5f) {
                touchl = Input.GetTouch(0).position;
                touchr = Input.GetTouch(1).position;
            }

            else {
                touchr = Input.GetTouch(0).position;
                touchl = Input.GetTouch(1).position;
            }
                    
            worldl = StoW(touchl);
            worldr = StoW(touchr);
            targetL.transform.position = worldl;
            targetR.transform.position = worldr;
        }

        // Touch가 하나이면
        else if (Input.touchCount == 1) {
            //좌
            if(Input.GetTouch(0).position.x < Screen.width * .5f) {

                touchl = Input.GetTouch(0).position;

              worldl = StoW(touchl);
                targetL.transform.position = worldl;

            }
            //우
            else {
                touchr = Input.GetTouch(0).position;

                worldr = StoW(touchr);
                 targetR.transform.position = worldr;

            }
        }   
        //터치가 없을 때는 Zero로 Set
        else if (Input.touchCount == 0) {
            touchl = Vector3.zero;
            touchr = Vector3.zero;
        }

        text1.text = "Position1 : " + touchl.ToString() + "\n" + worldl.ToString() + "\n" + targetL.transform.position.ToString() + "\n" + LeftTrackSpawnManager.instance.trackArray[LeftTrackSpawnManager.instance.num].name;
        text2.text = "Position2 : " + touchr.ToString() + "\n" + worldr.ToString() + "\n" + targetR.transform.position.ToString() + "\n" + RightTrackSpawnManager.instance.trackArray[RightTrackSpawnManager.instance.num].name;


    }

    // 화면 비에 맞게 TouchPosition 재설정
    private Vector3 StoW(Vector2 pos) {
        return new Vector3((pos.x / Screen.width * 23.15f - 11.52f), -5f, (pos.y / Screen.height * 13.11f - 29.5f));
    }


}
