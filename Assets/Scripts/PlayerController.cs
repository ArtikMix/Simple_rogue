using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer renderer;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position += new Vector3(speed, 0, 0) * Input.GetAxis("Horizontal") * Time.deltaTime;
            if (Input.GetAxis("Horizontal") > 0)
                renderer.flipX = false;
            if (Input.GetAxis("Horizontal") < 0)
                renderer.flipX = true;
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += new Vector3(0, speed, 0) * Input.GetAxis("Vertical") * Time.deltaTime;
        }
    }

}
