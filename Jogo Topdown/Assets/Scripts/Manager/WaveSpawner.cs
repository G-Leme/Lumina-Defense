using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyBrute;
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    private GameObject enemiesInGame;
    private bool BruteAdded;

    [SerializeField] private int waveCost;
    public int currWave;
    private int waveValue;
    public int spawnIndex;

    public Transform[] spawnLocation;

    public float waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    [SerializeField] private TextMeshProUGUI currWaveUI;
    [SerializeField] private TextMeshProUGUI enemiesLeft;
    [SerializeField] private GameObject youWinUI;


    public List<GameObject> spawnedEnemies = new List<GameObject>();
   
    void Update()
    {
        if (waveTimer <= 0 && spawnedEnemies.Count <= 0)
        {


            if (Input.GetKeyDown(KeyCode.G) && currWave <= 9)
            {
                currWave++;
                GenerateWave();
            }
        }
    }


    void FixedUpdate()
    {
        enemiesLeft.text = enemiesToSpawn.Count.ToString();
        currWaveUI.text = currWave.ToString();
        enemiesInGame = GameObject.FindGameObjectWithTag("Enemy");

        if (spawnTimer <= 0)
        {
            //spawn an enemy
            if (enemiesToSpawn.Count > 0)
            {
                GameObject enemy = (GameObject)Instantiate(enemiesToSpawn[0], spawnLocation[Random.Range(0, spawnLocation.Length)].position, Quaternion.identity); // spawn first enemy in our list
                enemiesToSpawn.RemoveAt(0); // and remove it
                spawnedEnemies.Add(enemy);
                spawnTimer = spawnInterval;

                if (spawnIndex + 1 <= spawnLocation.Length - 1)
                {
                    spawnIndex++;
                }
                else
                {
                    spawnIndex = 0;
                }
            }
            else
            {
                waveTimer = 0; // if no enemies remain, end wave
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }

       

        if(currWave >= 4 && BruteAdded == false)
        {
            enemies.Add(enemyBrute);
            BruteAdded = true;
            waveCost = 15;
         
           // waveDuration = waveDuration + 20; ;
        }

        if(currWave >= 9)
        {
            waveCost = 25;
            waveDuration = 35.2f;
        }

        if (enemiesInGame != null)
        {

            return;
        }
        else if(enemiesInGame == null && enemiesToSpawn.Count <= 0 ) 
        {
                spawnedEnemies.Clear();
                if(currWave == 10)
            {
                StartCoroutine(YouWin());
            }

        }
    }

    public void GenerateWave()
    {
        waveValue = currWave + waveCost;
        StopAllCoroutines();
        
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count; // gives a fixed time between each enemies
        waveTimer = waveDuration; // wave duration is read only
    }

    public void GenerateEnemies()
    {
        // Create a temporary list of enemies to generate
        // 
        // in a loop grab a random enemy 
        // see if we can afford it
        // if we can, add it to our list, and deduct the cost.

        // repeat... 

        //  -> if we have no points left, leave the loop

        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0 || generatedEnemies.Count < 50)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
        

    }

 
   IEnumerator YouWin()
    {
       
        youWinUI.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MainMenu");

    }


}


[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
