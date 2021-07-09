using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem : MonoBehaviour
{
    public static ParticleSystem Instance { get; private set; }

    [SerializeField] private Transform parentParticlePoollPlayer;
    
    private List<GameObject> particlesForPlayer;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        particlesForPlayer=new List<GameObject>();

        foreach (Transform child in parentParticlePoollPlayer)
        {
            particlesForPlayer.Add(child.gameObject);
        }
            
    }

    // Start is called before the first frame update
    public void InstantiateSphereParticles(Vector3 position)
    {
        foreach (var particle in particlesForPlayer)
        {
            if (!particle.activeSelf)
            {
                particle.transform.position = position;
                particle.SetActive(true);
                break;
            }
        }
    }
}
