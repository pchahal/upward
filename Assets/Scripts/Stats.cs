using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class Stats : MonoBehaviour
{

    Text text;
    House house;

    void Start()
    {
        text = GetComponentInChildren<Text>();
        house = GameObject.Find("House").GetComponent<House>();
    }
    void BuildStats()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("UpwardForce " + house.upwordForce.force);
        builder.AppendLine(house.balloonList.Count + "Balloons " + house.balloonList.Count * .3f);
        builder.AppendLine("WindForce " + house.windForce);

        Vector2 netForce = house.upwordForce.force + house.windForce + Vector2.up * house.balloonList.Count * .3f;
        builder.AppendLine("NetForce " + netForce);
        text.text = builder.ToString();

    }


    void Update()
    {
        BuildStats();
    }

}
