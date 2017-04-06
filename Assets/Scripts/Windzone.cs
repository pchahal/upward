using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windzone : MonoBehaviour
{

    public Vector2 windForce;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Up")
        {
            EventManager.Instance.PostNotification(EVENT_TYPE.WINDZONE, this, windForce);
            InvokeRepeating("AudioManager.Instance.PlayWindZone()", 0, 2);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Up")
        {
            CancelInvoke();
            EventManager.Instance.PostNotification(EVENT_TYPE.WINDZONE, this, Vector2.zero);

        }
    }
}
