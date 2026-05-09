using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;

    [Header("Difficulty Settings")]
    public float initialSpeed = 3.5f;
    public float speedIncrease = 0.5f;
    public float currentGlobalSpeed;

    private float startTime;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float timePassed = (Time.time - startTime) / 15f;
        currentGlobalSpeed = initialSpeed + (timePassed * speedIncrease);
    }
}