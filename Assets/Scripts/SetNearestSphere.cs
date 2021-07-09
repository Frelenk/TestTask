using System.Collections.Generic;
using UnityEngine;

public class SetNearestSphere : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 SetNearestPoint(List<Transform> spheresTransforms, Vector3 playerPosition)
    {

        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        foreach(Transform potentialTarget in spheresTransforms)
        {
            Vector3 directionToTarget = potentialTarget.position - playerPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget.position;
    }
}
