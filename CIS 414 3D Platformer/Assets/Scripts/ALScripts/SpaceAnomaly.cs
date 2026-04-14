using UnityEngine;

public class SpaceAnomaly : MonoBehaviour
{
    [SerializeField] private Transform pullPoint;
    [SerializeField] private float floatForce = 1.5f;
    [SerializeField] private float driftForce = 0.6f;
    [SerializeField] private float pullForce = 1.2f;
    [SerializeField] private float torqueForce = 0.8f;
    [SerializeField] private float smoothSpeed = 2f;

    private Rigidbody rb;
    private bool anomalyActive = false;
    private bool isPlayerObject = false;
    private float currentStrength = 0f;
    private Vector3 randomDrift;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogWarning($"{name}: SpaceAnomaly requires a Rigidbody.");
        }

        if (CompareTag("Player") || GetComponentInParent<Camera>() != null || GetComponent<PlayerInteractionMarker>() != null)
        {
            isPlayerObject = true;
        }

        randomDrift = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(0.2f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;
    }

    private void FixedUpdate()
    {
        if (isPlayerObject) return;
        if (rb == null) return;
        if (pullPoint == null) return;

        float targetStrength = anomalyActive ? 1f : 0f;
        currentStrength = Mathf.Lerp(currentStrength, targetStrength, Time.fixedDeltaTime * smoothSpeed);

        if (currentStrength <= 0.01f) return;

        Vector3 upwardFloat = Vector3.up * floatForce;

        Vector3 drift =
            randomDrift * driftForce +
            new Vector3(
                Mathf.Sin(Time.time + transform.position.x) * 0.3f,
                0f,
                Mathf.Cos(Time.time + transform.position.z) * 0.3f
            );

        Vector3 towardPullPoint = (pullPoint.position - transform.position).normalized * pullForce;

        Vector3 finalForce = upwardFloat + drift + towardPullPoint;

        rb.AddForce(finalForce * currentStrength, ForceMode.Acceleration);
        rb.AddTorque(randomDrift * torqueForce * currentStrength, ForceMode.Acceleration);
    }

    public void ActivateAnomaly()
    {
        if (isPlayerObject) return;
        if (rb == null) return;

        anomalyActive = true;
        rb.useGravity = false;
        rb.drag = 0.8f;
        rb.angularDrag = 0.8f;

        Debug.Log($"{name}: Anomaly Activated");
    }

    public void DeactivateAnomaly()
    {
        if (rb == null) return;

        anomalyActive = false;
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.drag = 0f;
        rb.angularDrag = 0.05f;

        Debug.Log($"{name}: Anomaly Deactivated");
    }
}