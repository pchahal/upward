using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Hint : MonoBehaviour
{

    public float endvalue;
    public float startTime;
    public float duration;
    // Use this for initialization
    void Start()
    {
        GetComponent<Text>().enabled = false;
        Invoke("ShowHint", startTime);
        Destroy(gameObject, startTime + duration);
    }


    void ShowHint()
    {
        GetComponent<Text>().enabled = true;
        transform.GetComponent<RectTransform>().DOLocalMoveX(endvalue, duration);
    }

}
