using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    [SerializeField] float currentHealth, maxHealth = 100f;
    private LightArea lightAreaScript;
    [SerializeField] private float lightRefund;
    // Start is called before the first frame update
    void Start()
    {
        lightAreaScript = GameObject.Find("LightArea").GetComponent<LightArea>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
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
