using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchSyncSetting : MonoBehaviour
{
    public GameObject GM;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    private Vector2 button1Pos;
    private Vector2 button2Pos;
    private Vector2 button3Pos;
    private Vector2 button4Pos;

    public  Text test;
    
    public int width;
    public int height;

    private int count = 1;
    private Touch touch;
    private Transform touchPos = null;

    private void Update() {
        if(Input.touchCount > 0)
            touchPos.position = Input.GetTouch(0).position;
    }

    public void button1Pushed() {
        Debug.Log("Hello");
                        touchPos.position = Input.GetTouch(0).position;
                                                string st = "" + "hello";
                        test.text = st;

                        button1Pos = this.touchPos.position;
                                                 st = "" + "hello2";
                        test.text = st;

                        button1.gameObject.SetActive(false);
                                                 st = "" + "hello3";
                        test.text = st;

                        button2.gameObject.SetActive(true);
                         st = "" + "hello4";
                        test.text = st;
    }

    public void button2Pushed() {
                    button2Pos = touchPos.position;
                    button2.gameObject.SetActive(false);
                    button3.gameObject.SetActive(true);
                    count++;
    }

    public void button3Pushed() {
                    button3Pos = touchPos.position;
                    button3.gameObject.SetActive(false);
                    button4.gameObject.SetActive(true);
                    count++;
    }
    
    public void button4Pushed() {
                    button4Pos = touchPos.position;
                    button4.gameObject.SetActive(false);
                    count++;

                     width = ((int)(button2Pos.x - button1Pos.x) / 1320 * 1920 + (int) (button4Pos.x - button3Pos.x) / 1320 * 1920 ) / 2;
                    height = ((int) (button1Pos.y - button3Pos.y) / 480 * 1080 + (int) (button2Pos.y - button4Pos.y) / 480 * 1080 ) / 2;

                    GM.gameObject.SetActive(true);
                    this.gameObject.SetActive(false);
    }
}
