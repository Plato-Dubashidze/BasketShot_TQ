using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent starCollected = new UnityEvent();
    public static UnityEvent<GameObject> newNetAssigned = new UnityEvent<GameObject>();
    public static UnityEvent<Vector3> shoot = new UnityEvent<Vector3>();

    public static void StarCollected()
    {
        starCollected.Invoke();
    }

    public static void Shoot(Vector3 force)
    {
        shoot.Invoke(force);
    }

    public static void NewNetAssigned(GameObject net)
    {
        newNetAssigned.Invoke(net);
    }
}
