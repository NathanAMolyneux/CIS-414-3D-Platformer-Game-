using UnityEngine;
using UnityEngine.SceneManagement;

public class TunnelSceneLoader : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Scene2";

    private bool canLoad = false; 

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
        Debug.Log("Tunnel unlocked!");
    }
}