using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                rb.AddForce(Vector3.up, ForceMode.Impulse);
                Debug.Log("Saltar");
            }
        }
    }
}
