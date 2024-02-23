using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    [SerializeField] private float movSpeed = 3.0f;

    private bool _isGrounded = true;
    private Vector3 moveDir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += Vector3.right * movSpeed * Time.deltaTime;
            if (!Mathf.Approximately(transform.rotation.y, 0f))
            {
                transform.rotation = Quaternion.identity;
            }
            transform.position += Vector3.right * movSpeed * Time.deltaTime;
            //transform.RotateAround(transform.position, transform.up, 180f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Mathf.Approximately(transform.rotation.y, 0f))
            {
                transform.RotateAround(transform.position, transform.up, 180f);
            }
            transform.position += Vector3.left * movSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * movSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * movSpeed * Time.deltaTime;
        }
    }

}
