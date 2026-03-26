using UnityEngine;

public class ShipShake : MonoBehaviour
{
    [SerializeField] private float shakeAmount = 0.03f;
    [SerializeField] private float shakeSpeed = 2f;

    private Vector3 startLocalPosition;

    private void Start()
    {
        startLocalPosition = transform.localPosition;
    }

    private void Update()
    {
        float x = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
        float y = Mathf.Cos(Time.time * shakeSpeed * 1.3f) * shakeAmount;

        transform.localPosition = startLocalPosition + new Vector3(x, y, 0f);
    }
}