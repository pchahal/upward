﻿
using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        float windDir = GetComponentInParent<Windzone>().windForce.x;
        scrollSpeed *= Mathf.Sign(windDir);
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.right * newPosition;
    }

    void Update2()
    {
        transform.position += Vector3.right * .1f;
    }
}