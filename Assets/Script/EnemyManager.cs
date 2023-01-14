using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : RotateBall
{
    [SerializeField] private float rotateTime=5f;
    private float currentTime;
    private bool rotate;
    public void Update()
    {
        if (rotate)
            BallSpin();
    }

    public override void BallSpin()
    {
        rotateBall.transform.position = transform.position;
        rotateBall.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        currentTime += Time.deltaTime;
        if (currentTime > rotateTime)
        {
            currentTime = 0;
            rotate = false;
            GetComponent<BallLineRenderer>().OpenRendere();
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            CrushEnemy(other.gameObject);
        }
        if (other.CompareTag("RotateBox"))
        {
            other.gameObject.SetActive(false);
            rotate = true;
            GetComponent<BallLineRenderer>().CloseRenderer();
        }
    }

    public void CrushEnemy(GameObject ball)
    {
        GetComponent<EnemyMovement>().move = false;
        Vector3 direction = transform.position - ball.transform.position;
        direction = new Vector3(direction.x, 0, direction.z);
        transform.DOJump(direction * 5, 15,1,2).OnComplete(() => { GetComponent<EnemyMovement>().move = true;});
        transform.DOLocalRotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360).SetRelative(true)
            .SetEase(Ease.Linear);
    }
}
