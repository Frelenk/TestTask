using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLifeTime : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(DisableObject());
    }

    private IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
}
