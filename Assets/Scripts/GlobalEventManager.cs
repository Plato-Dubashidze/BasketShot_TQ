using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent starCollected = new UnityEvent();
    public static UnityEvent netReached = new UnityEvent();
    public static UnityEvent levelEnd = new UnityEvent();
    public static UnityEvent spawnBasket = new UnityEvent();
    public static UnityEvent gameFirstStart = new UnityEvent();
    public static UnityEvent rimTouch = new UnityEvent();
    public static UnityEvent bounce = new UnityEvent();
    public static UnityEvent<GameObject> newNetAssigned = new UnityEvent<GameObject>();
    public static UnityEvent<Vector3> shoot = new UnityEvent<Vector3>();

    public static void StarCollected()
    {
        starCollected.Invoke();
    }

    public static void GameFirstStart()
    {
        gameFirstStart.Invoke();
    }

    public static void NetReached()
    {
        netReached.Invoke();
    }

    public static void Shoot(Vector3 force)
    {
        shoot.Invoke(force);
    }

    public static void NewNetAssigned(GameObject net)
    {
        newNetAssigned.Invoke(net);
    }

    public static void LevelEnd()
    {
        levelEnd.Invoke();
    }

    public static void SpawnBasket()
    {
        spawnBasket.Invoke();
    }

    public static void Bounce()
    {
        bounce.Invoke();
    }

    public static void RimTouch()
    {
        rimTouch.Invoke();
    }
}
