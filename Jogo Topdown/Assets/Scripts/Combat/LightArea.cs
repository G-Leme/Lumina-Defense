using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightArea : MonoBehaviour
{

    public Vector3 lightArea;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = lightArea;
    }

    public void TakeDamageLight(float damage)
    {
        if (lightArea.x >= 20)
        {
            lightArea.x -= damage;
            lightArea.y -= damage;
            lightArea.z -= damage;
        }
    }
}
