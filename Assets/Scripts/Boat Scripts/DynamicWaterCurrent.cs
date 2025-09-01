using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DynamicWaterCurrent : MonoBehaviour
{
    [Header("Force Settings")]
    public float maxForce = 10f;                   // Maximum possible opposing force
    public AnimationCurve forceCurve;             // Curve to control force distribution

    [Header("Debug Info")]
    [SerializeField] private float currentProgress;
    [SerializeField] private float appliedForce;

    private BoxCollider2D boxCollider;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;

        // Default curve if none is assigned (linear 1:1 mapping)
        if (forceCurve == null || forceCurve.keys.Length == 0)
            forceCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("BoatButton")) return;

        Rigidbody2D boatRb = other.attachedRigidbody;
        if (boatRb == null) return;

        // Calculate boat progress inside the collider (0.0 → 1.0)
        float zoneLeft = boxCollider.bounds.min.x;
        float zoneRight = boxCollider.bounds.max.x;
        float boatX = other.transform.position.x;

        currentProgress = Mathf.InverseLerp(zoneLeft, zoneRight, boatX);

        // Evaluate curve to determine force scale
        float forceScale = forceCurve.Evaluate(currentProgress);

        // Apply force against the boat (push left)
        appliedForce = maxForce * forceScale;
        boatRb.AddForce(Vector2.left * appliedForce, ForceMode2D.Force);
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        // Visualize collider bounds
        Gizmos.color = new Color(0f, 0.5f, 1f, 0.2f);
        Gizmos.DrawCube(transform.position, boxCollider ? boxCollider.size : Vector3.zero);
    }
#endif
}
