using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseImage : MonoBehaviour
{
    public GameObject LPlayer;
    
    public void SetImage(GameObject button)
    {
        Sprite image = button.GetComponent<Image>().sprite;
        LPlayer.GetComponent<LPlayerManager>().SetImage(image);
    }
}
