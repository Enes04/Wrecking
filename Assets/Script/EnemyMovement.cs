using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public float range;
    public bool move;
    public Transform centrePoint; 

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        move = true;
    }

    
    void Update()
    {
        if(agent.remainingDistance <= agent.stoppingDistance && move) 
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) 
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); 
                agent.SetDestination(point);
            }
        }

    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; 
        UnityEngine.AI.NavMeshHit hit;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas)) 
        { 
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
}
