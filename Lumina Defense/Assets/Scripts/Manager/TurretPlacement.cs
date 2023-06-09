using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TurretPlacement : MonoBehaviour
{
    [SerializeField] private GameObject turretPreview;
    [SerializeField] private GameObject turretPrefab;
    [SerializeField] private KeyCode placementKeyCode = KeyCode.B;
    private GameObject placableObject;

    [SerializeField] LightArea lightAreaScript;
    [SerializeField] private GameObject lightArea;
    [SerializeField] private GameObject turretPlacementArea;

    [SerializeField] private PlayerCombat playerCombat;

    public float sparkCount;
    public int sparkAmount;

    [SerializeField] private TextMeshProUGUI sparkCountUI;


    private void Start()
    {
        playerCombat = GameObject.Find("Player").GetComponent<PlayerCombat>();
   
        lightAreaScript = lightArea.GetComponent<LightArea>();
    }


    void Update()
    {
        sparkCountUI.text = sparkCount.ToString();

        HandleObjectKey();
        if (placableObject != null)
        {
            MoveCurrentPlacableObjectToMouse();
            ReleaseIfClicked();
        }
    }

    private void ReleaseIfClicked()
    {
       
        if (Input.GetMouseButtonDown(0) )
        {
            var turretPrefabInstance = GameObject.Instantiate(turretPrefab, new Vector3(placableObject.transform.position.x,
           placableObject.transform.position.y, placableObject.transform.position.z), Quaternion.identity);
            Destroy(placableObject);

            placableObject = null;
            playerCombat.canShoot = true;

            turretPlacementArea.SetActive(false);
            lightAreaScript.TakeDamageLight(4f);

            sparkCount = sparkCount - sparkAmount;
            sparkAmount = sparkAmount + 20;
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
       if(sparkCount >= sparkAmount && lightAreaScript.lightArea.x >= 30) {
            if (Input.GetKeyDown(placementKeyCode) && GameObject.FindGameObjectsWithTag("LightTurret").Length <= 3)
            {
                if (placableObject == null)
                {
                    playerCombat.canShoot = false;
                    turretPlacementArea.SetActive(true);
                    placableObject = Instantiate(turretPreview);
                }
                else
                {
                    playerCombat.canShoot = true;
                    turretPlacementArea.SetActive(false);
                    Destroy(placableObject);
                }
            }
        }
    }
}