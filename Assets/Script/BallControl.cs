using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Transform ballBasePosition;

    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ball.transform.position = Vector3.Lerp(ball.transform.position, ballBasePosition.position, 0.025f);
    }
}
