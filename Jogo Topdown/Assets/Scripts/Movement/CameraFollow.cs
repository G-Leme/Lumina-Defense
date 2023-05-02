using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;

   private float camOffSetZ;

    void Start()
    {
        camOffSetZ = gameObject.transform.position.z - player.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = new Vector3(player.position.x, gameObject.transform.position.y, player.position.z + camOffSetZ);

        gameObject.transform.position = cameraPos;
    }
}
