using UnityEngine;

public class CubeCollisionLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollectable collectable = other.GetComponent<ICollectable>();
        
        if (collectable != null)
        {
            collectable.Collect();
            GameController.Instance.SphereCollection();
        }
    }
}
