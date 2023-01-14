using System.ComponentModel;
using UnityEngine;
using UnityEngine.Serialization;

public class BallLineRenderer : MonoBehaviour
{
    private bool renderer = true;
    LineRenderer lineRenderer;
    public GameObject playerBall;
    public GameObject carBackPosition;

    void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    void Update()
    {
        if (renderer)
        {
            lineRenderer.SetPosition(0, carBackPosition.transform.position);
            lineRenderer.SetPosition(1, playerBall.transform.position);
        }
    }

    public void CloseRenderer()
    {
        renderer = false;
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
        GetComponent<RotateBall>().rotateBall.SetActive(true);
        playerBall.GetComponent<Collider>().enabled = false;
        playerBall.transform.GetChild(0).gameObject.SetActive(false);
    }
    
    public void OpenRendere()
    {
        renderer = true;
        GetComponent<RotateBall>().rotateBall.SetActive(false);
        playerBall.GetComponent<Collider>().enabled = true;
        playerBall.transform.GetChild(0).gameObject.SetActive(true);
    }
}