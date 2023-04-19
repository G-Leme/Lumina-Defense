using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    [SerializeField] float currentHealth, maxHealth = 100f;
    private LightArea lightAreaScript;
    [SerializeField] private float lightRefund;
    [SerializeField] private float spark;
    private Rigidbody rb;
    private TurretPlacement turretSpark;
    // Start is called before the first frame update
    void Start()
    {
        turretSpark = GameObject.Find("TurretPlacement").GetComponent<TurretPlacement>();
        lightAreaScript = GameObject.Find("LightArea").GetComponent<LightArea>();
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(8, 8);
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            turretSpark.sparkCount += spark;
            Destroy(gameObject);
            if (lightAreaScript.lightArea.x <= 60)
            {
                lightAreaScript.lightArea.x += lightRefund;
                lightAreaScript.lightArea.y += lightRefund;
                lightAreaScript.lightArea.z += lightRefund;
            }
        }
    }
}
