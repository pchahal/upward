using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Sail : MonoBehaviour
{

    bool canOpenClose;
    bool sailOpen;

    // Use this for initialization
    void Start()
    {
        sailOpen = false;
        canOpenClose = true;
        EventManager.Instance.AddListener(EVENT_TYPE.SAIL, OnEvent);

    }


    public void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null)
    {
        //Detect event type
        switch (Event_Type)
        {
            case EVENT_TYPE.SAIL:
                OnSail();
                break;

        }
    }
    //-------------------------------------------------------
    //Function called when health changes
    void OnSail()
    {

        if (canOpenClose)
            if (sailOpen)
            {
                canOpenClose = false;
                sailOpen = false;
                transform.DOScaleX(0f, 1f).OnComplete(() => canOpenClose = true);


            }
            else
            {
                canOpenClose = false;
                sailOpen = true;
                transform.DOScaleX(1f, 1f).OnComplete(() => canOpenClose = true);
            }
        AudioManager.Instance.PlayWindFlap();


        Debug.Log("sail=" + sailOpen);
    }




}
