using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DynamicWaterCurrent : MonoBehaviour
{
    [Header("Base Force Settings")]
    
    public float maxForce = 10f; // Maximum opposing force at 100% progress                    
    public AnimationCurve forceCurve; // Controls force scaling across progress

    [Header("Wind Gust Settings")]
    public float gustStrength = 2f; // How strong gusts can be (+/-)
    public float gustSpeed = 0.5f; // How fast gusts change over time: gustSpeed = 1 == 1 second per unit  == slow gusts
    // gustSpeed = 5 == 0.2 seconds per unit == fast gusts || gustSpeed = 10 == 0.1 seconds per unit == very fast gusts
    private float gustOffset; // Unique offset for Perlin noise

    private float centeredNoiseOffset = 0.5f; // To center Perlin noise around 0

    private float amplitude = 2f;

    [Header("Debug Info")]
    [SerializeField] private float currentProgress;
    [SerializeField] private float appliedForce;
    [SerializeField] private float windGust;

    private BoxCollider2D boxCollider;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;

        // Default to a linear curve if a custom curve isn't set
        if (forceCurve == null || forceCurve.keys.Length == 0)
            forceCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        // Randomize offset so multiple zones aren't synchronized
        gustOffset = Random.Range(0f, 999f);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("BoatButton")) return;

        Rigidbody2D boatRb = other.attachedRigidbody;
        if (boatRb == null) return;

        // Calculate boat's progress inside collider (0.0 to 1.0)
        float zoneLeft = boxCollider.bounds.min.x;
        float zoneRight = boxCollider.bounds.max.x;
        float boatX = other.transform.position.x;

        currentProgress = Mathf.InverseLerp(zoneLeft, zoneRight, boatX);

        // Evaluate curve for force scaling
        float forceScale = forceCurve.Evaluate(currentProgress);

        // Generate smooth wind gusts using Perlin Noise. WindGust has centeredNoiseOffset applied so it ranges from -0.5 to +0.5 before scaling to help or hinder the boat
        windGust = (Mathf.PerlinNoise(Time.time * gustSpeed, gustOffset) - centeredNoiseOffset) * amplitude * gustStrength;

        // Final force = base force + gusts
        appliedForce = (maxForce * forceScale) + windGust;

        boatRb.AddForce(Vector2.left * appliedForce, ForceMode2D.Force);
    }
}