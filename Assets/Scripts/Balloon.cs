using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface IHittable
{
    void OnHit();

}

public class Balloon : MonoBehaviour, IHittable
{


    Transform house;
    LineRenderer lineRenderer;
    public Sprite burstSprite;

    SpriteRenderer spriteRenderer;
    static int numStrings = 100;

    // Use this for initialization
    void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();
        house = GameObject.Find("House").transform;
        GetComponent<SpriteRenderer>().color = Random.ColorHSV();

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (numStrings > 0)
        {
            numStrings--;
            lineRenderer.enabled = true;
        }
    }



    void Update()
    {
        lineRenderer.SetPosition(1, transform.position);
        lineRenderer.SetPosition(0, house.position);
    }


    public void OnHit()
    {

        spriteRenderer.sprite = burstSprite;

        if (lineRenderer.enabled == true)
            numStrings++;
        Destroy(gameObject, 1);


        AudioManager.Instance.PlayBalloon();
    }


}
