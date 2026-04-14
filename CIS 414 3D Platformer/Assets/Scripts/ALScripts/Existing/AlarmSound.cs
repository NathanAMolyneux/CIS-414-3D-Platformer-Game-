using UnityEngine;

namespace ALScripts.Existing
{
    public class AlarmSound : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip alarmClip;

        private void Awake()
        {
            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();
            }
        }

        public void PlayAlarm()
        {
            if (audioSource == null)
            {
                Debug.LogWarning("AlarmSound: AudioSource is missing.");
                return;
            }

            if (alarmClip == null)
            {
                Debug.LogWarning("AlarmSound: Alarm clip is missing.");
                return;
            }

            audioSource.clip = alarmClip;
            audioSource.loop = true;

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        public void StopAlarm()
        {
            if (audioSource == null) return;

            audioSource.Stop();
        }
    }
}