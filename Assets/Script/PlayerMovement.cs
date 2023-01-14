using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool move;
    public float speed;
    private DynamicJoystick dynamicJoystick;


    private void Start()
    {
        dynamicJoystick = FindObjectOfType<DynamicJoystick>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && move)
        {
            transform.Translate(speed * dynamicJoystick.Horizontal * Time.deltaTime, 0,
                speed * dynamicJoystick.Vertical * Time.deltaTime);
            Vector3 lookatPos = new Vector3(dynamicJoystick.Horizontal, 0f, dynamicJoystick.Vertical);
            Quaternion lookRot = Quaternion.LookRotation(lookatPos);
            transform.GetChild(0).rotation = Quaternion.Lerp(transform.GetChild(0).rotation, lookRot, 0.035f);
        }
    }
}