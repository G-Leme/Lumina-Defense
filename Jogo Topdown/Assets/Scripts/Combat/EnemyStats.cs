using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    [SerializeField] float currentHealth, maxHealth = 100f;
    private LightArea lightAreaScript;
    [SerializeField] private float lightRefund;
    [SerializeField] private float spark;
    [SerializeField] public float moveSpeed;
    private Rigidbody rb;
    private TurretPlacement turretSpark;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.dome;
        turretSpark = GameObject.Find("TurretPlacement").GetComponent<TurretPlacement>();
        lightAreaScript = GameObject.Find("LightArea").GetComponent<LightArea>();
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Physics.IgnoreLayerCollision(8, 8);

       // float distance = Vector3.Distance(target.transform.position, transform.position);
     


    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            turretSpark.sparkCount += spark;
            Destroy(gameObject);
            if (lightAreaScript.lightArea.x <= 80)
            {
                lightAreaScript.lightArea.x += lightRefund;
                lightAreaScript.lightArea.y += lightRefund;
                lightAreaScript.lightArea.z += lightRefund;
            }
        }
    }
}
