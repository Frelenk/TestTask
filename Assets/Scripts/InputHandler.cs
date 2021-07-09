using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
   private SphereSpawnHandler spherePoolHandler;

   private void Start()
   {
       spherePoolHandler = GetComponent<SphereSpawnHandler>();
   }

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            spherePoolHandler.SpawnSphere();
        }
    }
}
