using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPosition : MonoBehaviour
{
    public Text characterPos;
    
    void Update()
    {
        characterPos.text = "Pos : " + this.transform.position;
    }
}
