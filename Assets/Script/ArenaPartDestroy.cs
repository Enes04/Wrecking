using UnityEngine;

public class ArenaPartDestroy : MonoBehaviour
{
   
    public void DestroyPart(int destroyTime)
    {
        Destroy(gameObject,destroyTime);
    }
}
