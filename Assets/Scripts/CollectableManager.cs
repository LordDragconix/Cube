using UnityEngine;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager Instance;

    public TextMeshProUGUI collectableText;
    public GameObject exitObject;

    private int totalCollectables;
    private int collected = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        totalCollectables = GameObject.FindGameObjectsWithTag("Collectable").Length;
        UpdateUI();

        if (exitObject != null)
            exitObject.SetActive(false); // Hide/disable exit at start
    }

    public void Collect()
    {
        collected++;
        UpdateUI();

        if (collected >= totalCollectables && exitObject != null)
            exitObject.SetActive(true); // Enable exit when all are collected
    }

    void UpdateUI()
    {
        if (collectableText != null)
            collectableText.text = $"{collected} / {totalCollectables}";
    }
}
