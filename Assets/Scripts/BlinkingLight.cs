using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    [SerializeField] private Light myLight;
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);
        myLight.intensity = Mathf.Lerp(0f, 5f, t);
    }
}