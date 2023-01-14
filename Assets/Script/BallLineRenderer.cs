using System.ComponentModel;
using UnityEngine;
using UnityEngine.Serialization;

public class BallLineRenderer : MonoBehaviour
{
     LineRenderer lineRenderer; 
    public GameObject playerBall;
    public GameObject carBackPosition;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0,carBackPosition.transform.position);
        lineRenderer.SetPosition(1,playerBall.transform.position);
    }
}
