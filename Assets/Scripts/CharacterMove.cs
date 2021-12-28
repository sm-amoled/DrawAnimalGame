using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    public bool TtoLFtoR;
    Vector3 point;
    public Text pointPrint;
    private bool isStayOnGround;

    public Vector3 spawnPosition;

    public GameObject target;

    void Start() {
    }


    // Update is called once per frame
    void Update()
    {          
        switch(StateManager.instance.currentState) {
            case StateManager.State.play :
                // 땅에 닿아있을때
                if (isStayOnGround == false) {
                    this.GetComponent<Rigidbody>().AddForce(0, -300f, 0);

                // 땅에서 일정 거리 이상 떨어지면 리스폰
                if(this.transform.position.y < -30f) {
                    SoundEffect.instance.DieSound();
                    Respawn();

                }

                // 땅에서 조금 내려가면 (길 밖으로 나가면) 떨어뜨리기
                else if (this.transform.position.y < -5.5f) 
                    this.GetComponent<Rigidbody>().AddForce(0, -300f, 0);
                    return ;
                }

                if(TtoLFtoR) { // Left Right구분
                    point = TouchPosition.instance.worldl;

                    // 터치한 위치 따라가도록 설정
                    if(TouchPosition.instance.touchl != Vector3.zero && Vector3.Distance(this.transform.position, point) < 1f && isStayOnGround){
                        target.transform.position = new Vector3(point.x, this.transform.position.y, point.z);
                        this.transform.LookAt(target.transform);
                        this.transform.position = new Vector3(point.x, this.transform.position.y, point.z);
                    }
                }

                else {
                    point = TouchPosition.instance.worldr;

                    if(TouchPosition.instance.touchr != Vector3.zero && Vector3.Distance(this.transform.position, point) < 1f && isStayOnGround){
                        target.transform.position = new Vector3(point.x, this.transform.position.y, point.z);
                        this.transform.LookAt(target.transform);
                        this.transform.position = new Vector3(point.x, this.transform.position.y, point.z);
                    }
                }

                break;

            case StateManager.State.pause :
                // 일시정지일 때 멈추기
                this.gameObject.transform.position = this.gameObject.transform.position; // 낙하방지
                break;
        }
    }

    // Respawn될 때
    private void Respawn() {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        // Spawn 위치로 가기
        this.transform.position = spawnPosition;
    }

    // 땅에서 떨어질 때
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "track")
            isStayOnGround = false;
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "track") 
            isStayOnGround = true;
    }

    // 땅에 닿을 때 / trackEnd로 다음 Track을 소환할 때
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "track") {
            isStayOnGround = true;
            ;}

        if(other.gameObject.tag == "trackEnd" && this.gameObject.name == "CharacterL") {
            TimerManager.instance.Goal('l');
            ScoreManager.instance.GetScoreTrack();
            LeftTrackSpawnManager.instance.DestroyTrack();
            SoundEffect.instance.ClearSound();
        }
        else if(other.gameObject.tag == "trackEnd" && this.gameObject.name == "CharacterR") {
            TimerManager.instance.Goal('r');
            ScoreManager.instance.GetScoreTrack();
            RightTrackSpawnManager.instance.DestroyTrack();
            SoundEffect.instance.ClearSound();
        }
    }

}