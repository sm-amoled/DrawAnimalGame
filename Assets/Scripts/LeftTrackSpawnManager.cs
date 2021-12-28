using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftTrackSpawnManager : MonoBehaviour
{
    public static LeftTrackSpawnManager instance;
   
    private void Awake() {
        instance = this;
    }

    public GameObject[] trackArray = new GameObject[5];
    public Sprite[] trackPreviewImage = new Sprite[5];
    public GameObject character;
    public GameObject LeftTrack;
    public Image preview;

    public int num = 9999;

    public void Start() {
        // 만약 LEftTrack이 있으면 없애고 
        if(LeftTrack != null) {
            Destroy(LeftTrack);
        }
        if(num == 9999)
            num = Random.Range(0, trackArray.Length * 2 - 1) / 2;

        // 랜덤 숫자를 하나 정해서
        SpawnTrack();

    }

    // Track을 Spawn하는 메서드
    public void SpawnTrack() {
        // 결정된 스폰할 트랙을 만들기 
        LeftTrack = Instantiate(trackArray[num], Vector3.zero, trackArray[num].transform.rotation);

        // Character에 Spawn될 위치를 넣어놓음
        character.GetComponent<CharacterMove>().spawnPosition = LeftTrack.transform.GetChild(0).position;
        character.transform.position = LeftTrack.transform.GetChild(0).position;

        // 다음 나올 Track의 Preview를 띄움
        num = Random.Range(0,trackArray.Length * 2 - 1 ) / 2;
        setPreview(num);
    }

    // 있던 Track을 없애고, 다시 Spawn
    public void DestroyTrack() {
        Destroy(LeftTrack);
        SpawnTrack();
    }

    // 이미지를 띄우는 메서드. 
    private void setPreview(int numb) {
        preview.sprite = trackPreviewImage[numb];
    }


}
