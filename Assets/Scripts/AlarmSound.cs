using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void PlayAlarm()
    {
        audioSource.Play();
    }

    public void StopAlarm()
    {
        audioSource.Stop();
    }
}