using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)) 
        {
            Vector3 targetPostion= new Vector3(hit.point.x, transform.position.y, hit.point.z);

            Quaternion rotation = Quaternion.LookRotation(targetPostion - transform.position);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10.0f); 
        }
    }
}
