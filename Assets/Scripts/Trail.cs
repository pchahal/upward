using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    TrailRenderer trail;
    // Use this for initialization
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            trail.enabled = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = new Vector3(ray.origin.x, ray.origin.y, transform.position.z);
        }
        else
            trail.enabled = false;

    }
}
