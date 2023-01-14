using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : RotateBall
{
    public void Update()
    {
        BallSpin();
    }

    public override void BallSpin()
    {
        rotateBall.transform.position = transform.position;
        rotateBall.transform.Rotate(0,rotateSpeed*Time.deltaTime,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GetComponent<EnemyMovement>().move = false;
            Vector3 direction = transform.position - other.transform.position;
            direction = new Vector3(direction.x, 0, direction.z);
            transform.DOJump(direction * 5, 15,1,2).OnComplete(() => { GetComponent<EnemyMovement>().move = true;});
            transform.DOLocalRotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360).SetRelative(true)
                .SetEase(Ease.Linear);
        }
    }
}
