using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretPlacement : MonoBehaviour
{
    [SerializeField] private GameObject turretPreview;
    [SerializeField] private GameObject turretPrefab;
    [SerializeField] private KeyCode placementKeyCode = KeyCode.B;
    private GameObject placableObject;
    [SerializeField] LightArea lightAreaScript;
    [SerializeField] private GameObject lightArea;
    [SerializeField] private GameObject turretPlacementArea;
    [SerializeField] private GameObject turretLostArea;
    [SerializeField] LightTurret lightTurretScript;
    [SerializeField] private GameObject lightTurret;
    public float sparkCount;



    private void Start()
    {
        lightTurretScript = lightTurret.GetComponent<LightTurret>();
        lightAreaScript = lightArea.GetComponent<LightArea>();
    }


    void Update()
    {


        HandleObjectKey();
        if (placableObject != null)
        {
            MoveCurrentPlacableObjectToMouse();
            ReleaseIfClicked();
        }
    }

    private void ReleaseIfClicked()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            var turretPrefabInstance = GameObject.Instantiate(turretPrefab, new Vector3(placableObject.transform.position.x,
           placableObject.transform.position.y, placableObject.transform.position.z), Quaternion.identity);
            Destroy(placableObject);
            placableObject = null;
            turretLostArea.SetActive(false);
            turretPlacementArea.SetActive(false);
            lightAreaScript.TakeDamageLight(7f);
            sparkCount = sparkCount - 20;
        }
    }

    private void MoveCurrentPlacableObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, 1 << 14))
        {
            placableObject.transform.position = hitInfo.point;
            //currentPlacableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

        }
    }


    private void HandleObjectKey()
    {
       if(sparkCount >= 20) {
            if (Input.GetKeyDown(placementKeyCode))
            {
                if (placableObject == null)
                {
                    turretLostArea.SetActive(true);
                    turretPlacementArea.SetActive(true);
                    placableObject = Instantiate(turretPreview);
                }
                else
                {
                    turretLostArea.SetActive(false);
                    turretPlacementArea.SetActive(false);
                    Destroy(placableObject);
                }
            }
        }
    }
}