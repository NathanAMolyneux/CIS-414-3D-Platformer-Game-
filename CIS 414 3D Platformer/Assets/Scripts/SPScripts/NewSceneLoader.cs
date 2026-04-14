using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneLoader : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "NextScene";
    [SerializeField] private bool canLoad = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!canLoad) return;

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    public void EnableLoading()
    {
        canLoad = true;
        Debug.Log("Tunnel unlocked");
    }
}