using UnityEngine;

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectableManager.Instance.Collect();
            Destroy(gameObject);
        }
    }
}
