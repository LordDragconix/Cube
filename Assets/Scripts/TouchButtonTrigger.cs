using UnityEngine;
using UnityEngine.UI;

public class TouchButtonTrigger : MonoBehaviour
{
    public Button targetButton;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetButton != null)
            {
                targetButton.onClick.Invoke(); // Triggers all assigned OnClick events
            }
        }
    }
}
