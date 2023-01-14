using System;
using UnityEngine;

public class EventBus
{
    public static event Action<int> OnDestroyByPlayer;
    public static event Action<float> OnDestroyByFall;
    public static event Action OnLosed;
    public static event Action OnBalloonPoped;
    public static event Action<Vector3> OnParticleCreated;

    public static void SendPlayerDestruction(int reward)
    {
        OnDestroyByPlayer.Invoke(reward);
    }

    public static void SendFallDestruction(float damage)
    {
        OnDestroyByFall.Invoke(damage);
    }

    public static void SendGameOver()
    {
        OnLosed?.Invoke();
    }

    public static void SendBalloonPoped()
    {
        OnBalloonPoped?.Invoke();
    }

    public static void CreateParticle(Vector3 position)
    {
        OnParticleCreated.Invoke(position);
    }
}

