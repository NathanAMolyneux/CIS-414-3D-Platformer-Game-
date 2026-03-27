using UnityEngine;

public class SpaceAnomaly : MonoBehaviour
{
    [SerializeField] private Transform pullPoint;
    [SerializeField] private float pullForce = 25f;
    [SerializeField] private float floatForce = 3f;

    private Rigidbody rb;
    private bool isActive = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError(gameObject.name + " NO RIGIDBODY FOUND!");
        }

        if (pullPoint == null)
        {
            Debug.LogError(gameObject.name + " Pull Point NOT assigned!");
        }
    }

    private void FixedUpdate()
    {
        if (!isActive) return;
        if (pullPoint == null) return;
        if (rb == null) return;

        Debug.DrawLine(transform.position, pullPoint.position, Color.red);

        rb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);

        Vector3 dir = (pullPoint.position - transform.position).normalized;
        rb.AddForce(dir * pullForce, ForceMode.Acceleration);
    }

    public void ActivateAnomaly()
    {
        Debug.Log(gameObject.name + " Anomaly Activated");

        isActive = true;

        if (rb != null)
        {
            rb.useGravity = false;
        }

        AstronautFirstPersonController player = GetComponent<AstronautFirstPersonController>();
        if (player != null)
        {
            player.SetAnomalyState(true);
        }
    }

    public void DeactivateAnomaly()
    {
        Debug.Log(gameObject.name + " Anomaly Deactivated");

        isActive = false;

        if (rb != null)
        {
            rb.useGravity = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        AstronautFirstPersonController player = GetComponent<AstronautFirstPersonController>();
        if (player != null)
        {
            player.SetAnomalyState(false);
        }
    }
}