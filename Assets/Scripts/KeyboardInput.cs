using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public float force;
    ConstantForce2D constantForce2D;

    // Use this for initialization
    void Start()
    {
        constantForce2D = GameObject.Find("Up").GetComponent<ConstantForce2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            constantForce2D.force += Vector2.left * force;
            AudioManager.Instance.PlayWindFlap();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            constantForce2D.force += Vector2.right * force;
            AudioManager.Instance.PlayWindFlap();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            constantForce2D.force += Vector2.down * force;
            AudioManager.Instance.PlayWindFlap();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            constantForce2D.force += Vector2.up * force;
            AudioManager.Instance.PlayWindFlap();
        }
        CheckForTarget();
    }


    void CheckForTarget()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                IHittable hittable = hit.collider.gameObject.GetComponent<IHittable>();
                if (hittable != null)
                    hittable.OnHit();
            }
        }

        if (Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);


            if (hit.collider != null)
            {
                IHittable hittable = hit.collider.gameObject.GetComponent<IHittable>();
                Debug.Log(hit.collider.name);
                if (hittable != null)
                    hittable.OnHit();
            }
        }
    }

}
