using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//LeftTrackSpawnManager와 같은 작동.
public class RightTrackSpawnManager : MonoBehaviour
{
    public static RightTrackSpawnManager instance;
   
    private void Awake() {
        instance = this;
    }

    public GameObject[] trackArray = new GameObject[5];
    public Sprite[] trackPreviewImage = new Sprite[5];

    public Image preview;
    public GameObject character;
    public GameObject RightTrack;

    public int num = 9999;

    public void Start() {
        if(RightTrack != null) {
            Destroy(RightTrack);
        }
        if (num == 9999)
            num = Random.Range(0,trackArray.Length * 2 - 1) / 2;

        SpawnTrack();
    }

    public void SpawnTrack() {
        RightTrack = Instantiate(trackArray[num], Vector3.zero, trackArray[num].transform.rotation);

        character.GetComponent<CharacterMove>().spawnPosition = RightTrack.transform.GetChild(0).position;
        character.transform.position = RightTrack.transform.GetChild(0).position;

        num = Random.Range(0,trackArray.Length * 2 - 1) / 2;
        setPreview(num);
    }

    public void DestroyTrack() {
        Destroy(RightTrack);
        SpawnTrack();
    }

    private void setPreview(int numb) {
        preview.sprite = trackPreviewImage[numb];
    }



    public void DestroyTrackonly() {
        Destroy(RightTrack);
    }
}
