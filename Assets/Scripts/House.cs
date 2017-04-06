using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour, IHittable
{

    public GameObject balloonPrefab;
    private int numBalloons = 100;
    [HideInInspector]
    public List<GameObject> balloonList;
    Transform balloonsGO;
    bool sailsOn;
    [HideInInspector]
    public ConstantForce2D upwordForce;
    [HideInInspector]
    public Vector2 windForce;

    void Start()
    {
        EventManager.Instance.AddListener(EVENT_TYPE.SAIL, OnEvent);
        EventManager.Instance.AddListener(EVENT_TYPE.WINDZONE, OnEvent);
        EventManager.Instance.AddListener(EVENT_TYPE.ADD_BALLLOONS, OnEvent);

        balloonsGO = GameObject.Find("Balloons").transform;
        balloonList = new List<GameObject>();
        upwordForce = GameObject.Find("Up").GetComponent<ConstantForce2D>();

        StartCoroutine("AddBalloon", numBalloons);
    }


    public void AddOneBalloon()
    {
        StartCoroutine("AddBalloon", 1);
    }

    IEnumerator AddBalloon(int numBalloons)
    {
        int i = 0;

        while (i < numBalloons)
        {

            Vector2 position = transform.localPosition;
            GameObject newballoon = GameObject.Instantiate(balloonPrefab, position, Quaternion.identity);
            newballoon.transform.parent = balloonsGO;
            balloonList.Add(newballoon);
            i++;
            yield return new WaitForSeconds(.1f);
        }
    }

    public void PopBalloon()
    {
        if (balloonList.Count > 0)
        {
            balloonList[balloonList.Count - 1].GetComponent<Balloon>().OnHit();
            balloonList.RemoveAt(balloonList.Count - 1);


        }
    }

    public void OnHit()
    {
        Debug.Log("hit house");
        EventManager.Instance.PostNotification(EVENT_TYPE.SAIL, this, null);
        CalculateUpwardForce();
    }

    public void OnWindZone(Vector2 wind)
    {
        windForce = wind;
        CalculateUpwardForce();

    }

    private void CalculateUpwardForce()
    {
        upwordForce.force = windForce;

        if (sailsOn)
            upwordForce.force *= 2;
    }


    public void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null)
    {
        //Detect event type
        switch (Event_Type)
        {
            case EVENT_TYPE.WINDZONE:
                OnWindZone((Vector2)Param);
                break;
            case EVENT_TYPE.ADD_BALLLOONS:
                StartCoroutine(AddBalloon(10));
                break;

        }
    }

}
