using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{

    [SerializeField] private GameObject turretPrefab;
    [SerializeField] private KeyCode placementKeyCode = KeyCode.B;
    private GameObject currentPlacableObject;
    [SerializeField] LightArea lightAreaScript;
    [SerializeField] private GameObject lightArea;
    [SerializeField] private GameObject turretPlacementArea;

    [SerializeField] LightTurret lightTurretScript;
    [SerializeField] private GameObject lightTurret;


    private void Start()
    {
        lightTurretScript = lightTurret.GetComponent<LightTurret>();
        lightAreaScript = lightArea.GetComponent<LightArea>();
    }


    void Update()
    {
        

        HandleObjectKey();
        if(currentPlacableObject != null )
        {
            MoveCurrentPlacableObjectToMouse();
            ReleaseIfClicked();
        }
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {

    
            currentPlacableObject = null;
            turretPlacementArea.SetActive(false);
            lightAreaScript.TakeDamageLight(7f);
        }
    }

    private void MoveCurrentPlacableObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, 1<<14) )
        {
            currentPlacableObject.transform.position = hitInfo.point;
            //currentPlacableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

        }
    }

   
    private void HandleObjectKey()
    {
        if(Input.GetKeyDown(placementKeyCode))
        {
            if(currentPlacableObject == null) 
            {
                turretPlacementArea.SetActive(true);
                currentPlacableObject = Instantiate(turretPrefab);
            }
            else
            {
                turretPlacementArea.SetActive(false);
                Destroy(currentPlacableObject); 
            }
        }
    }
}
