using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LightArea : MonoBehaviour
{

    public Vector3 lightArea;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    private WaveSpawner currWave;
    public bool canGrow;
    // Start is called before the first frame update
    void Start()
    {
       
        currWave = GameObject.Find("GameManager").GetComponent<WaveSpawner>();
        health = maxHealth;
    }

    // Update is called once per frame

    private void Update()
    {
        transform.localScale = lightArea;

       
    }


    public void TakeDamageLight(float damage)
    {
        if (lightArea.x > 20)
        {
            lightArea.x -= damage;
            lightArea.y -= damage;
            lightArea.z -= damage;
        }
        if (lightArea.x <=20)
        {
            StartCoroutine(GameOver());
            gameOverUI.SetActive(true);
        }

     
        
    }

    

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(4f);
        Application.Quit();
    }
}
