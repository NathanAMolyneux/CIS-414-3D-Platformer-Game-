using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangarInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactLayer;
    private HangarPlayerUI hangarPlayerUI;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        hangarPlayerUI = GetComponent<HangarPlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        hangarPlayerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactDistance);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                hangarPlayerUI.UpdateText(hit.collider.GetComponent<Interactable>().interactMessage);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<Interactable>().BaseInteract();
                }

            }
        }
    }

}
