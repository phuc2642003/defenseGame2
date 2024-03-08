using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement: MonoBehaviour
{
    public GUIManager guiManager;
    public int spawnTime;
    public Enemy[] enemies;
    internal bool isGameOver=false;
    internal bool isGameReplay= false;
    private Player player;
    private List<Enemy> enemiesSpawned;
    public GameObject heroPrefabs;
    private GameObject heroInstance;
    internal int instanceCoins;
    internal int score;
    internal int totalConis;
    internal int bestScore;
    public Text coinText;
    public Text homeCoinText;
    public Text bestScoreText;
    // Start is called before the first frame update
    private void Awake()
    {
        enemiesSpawned = new List<Enemy>();
    }
    void Start()
    {
        guiManager.showHomeGUI();
        totalConis = PlayerPrefs.GetInt(Const.Coin_PREF, 0);
        homeCoinText.text = totalConis.ToString();
    }
    public void PlayGame()
    {
        guiManager.showGameGUI();
        player = FindAnyObjectByType<Player>();
        
        StartCoroutine(spawnEnemy());
        
        instanceCoins = 0;
        score = 0;
        heroInstance=Instantiate(heroPrefabs, new Vector3(-6, -1, 0), Quaternion.identity);
        instanceCoins = 0;
        score = 0;
        coinText.text = instanceCoins.ToString();
        isGameOver = false;
        isGameReplay = false;
    }    
    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            guiManager.showGameOverBox();
            //Debug.Log(bestScore + " " + totalConis);
        }
    }
    private IEnumerator spawnEnemy()
    {
        while(!isGameOver && !isGameReplay)
        {
            yield return new WaitForSeconds(spawnTime);
            if (gameObject)
            {
                int random = Random.Range(0, enemies.Length);
                Enemy newEnemy = Instantiate(enemies[random], new Vector3(10, 0, 0), Quaternion.identity);
                enemiesSpawned.Add(newEnemy);
            }
        }        
    }
    public void destroyInstanceObject()
    {
        foreach (Enemy enemy in enemiesSpawned)
        {
            Destroy(enemy.gameObject);
        }
        enemiesSpawned.Clear();
        Destroy(heroInstance);
    }   
    public void ReplayGame()
    {
        isGameReplay = true;
    }
}
