using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{

    Transform house;

    // Use this for initialization
    void Start()
    {
        house = GameObject.Find("House").GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(house.position.x, house.position.y + 5, Camera.main.transform.position.z);
    }
}
