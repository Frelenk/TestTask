using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SphereSpawnHandler : MonoBehaviour
{
    [SerializeField] private Transform parentToAdd;
    [SerializeField] private Collider colliderWhereSpawn;
    [SerializeField] private List<GameObject> sphereList;
    [SerializeField] private GameObject spherePrefab;

    private SetNearestSphere setNearestSphere;
    private Bounds areaBoundsToSpawn;

    private void Start()
    {
        areaBoundsToSpawn = colliderWhereSpawn.bounds;
        setNearestSphere = GetComponent<SetNearestSphere>();
    }

    public void SpawnSphere()
    {
        foreach (var sphere in sphereList)
        {
            if (!sphere.activeSelf)
            {
                sphere.transform.position = RandomPointInBounds();
                sphere.SetActive(true);
                GameController.Instance.SphereSpawn();
                return;
            }
        }

        GameObject tempGameObject = Instantiate(spherePrefab, RandomPointInBounds(), Quaternion.identity);
        tempGameObject.transform.parent = parentToAdd;
        sphereList.Add(tempGameObject);
        GameController.Instance.SphereSpawn();
    }

    public List<Transform> GetActiveSperesTransform()
    {
        List<Transform> activeTransforms=new List<Transform>();

        foreach (var sphere in sphereList)
        {
            if(sphere.activeSelf)
                activeTransforms.Add(sphere.transform);
        }

        return  activeTransforms;
    }

    public bool IsAnySphereActive()
    {
        foreach (var item in sphereList)
        {
            if (item.activeSelf)
                return true;
        }

        return false;
    }
    private Vector3 RandomPointInBounds() {
        return new Vector3(
            Random.Range(areaBoundsToSpawn.min.x, areaBoundsToSpawn.max.x),
            1f,
            Random.Range(areaBoundsToSpawn.min.z, areaBoundsToSpawn.max.z)
        );
    }
}
