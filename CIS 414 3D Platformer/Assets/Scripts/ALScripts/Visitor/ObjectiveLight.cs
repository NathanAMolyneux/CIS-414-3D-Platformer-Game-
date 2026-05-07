using UnityEngine;
using ALScripts.Data;

public class ObjectiveLight : MonoBehaviour
{
    [SerializeField] private Light objectiveLight;

    private void Awake()
    {
        if (objectiveLight == null)
            objectiveLight = GetComponent<Light>();
    }

    private void Start()
    {
        if (objectiveLight != null)
        {
            objectiveLight.enabled = false; // start OFF
            objectiveLight.color = Color.red; // emergency
        }
    }

    private void OnEnable()
    {
        ShipStatus.Instance.OnStatusChanged += CheckObjective;
    }

    private void OnDisable()
    {
        ShipStatus.Instance.OnStatusChanged -= CheckObjective;
    }

    private void CheckObjective()
    {
        if (objectiveLight == null) return;

        bool completed =
            ShipStatus.Instance.RepairedBreaches >= ShipStatus.Instance.TotalBreaches;

        if (completed)
        {
            objectiveLight.enabled = true;
            objectiveLight.color = Color.cyan; // fixed system
        }
    }
}