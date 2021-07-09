using System;
using UnityEngine;

public class CollectableSphere : MonoBehaviour, ICollectable, IParticle
{
    public void Collect()
    {
        gameObject.SetActive(false);
        GameController.Instance.UpdateScore();
        InstantiateParticles();
    }

    public void InstantiateParticles()
    {
        ParticleSystem.Instance.InstantiateSphereParticles(transform.position);
    }
}
