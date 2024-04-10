using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement: MonoBehaviour
{
    public static GameManagement Instance { get; private set; }
    
    public int spawnTime;
    public Enemy[] enemies;
    internal bool isGameOver=false;
    internal bool isGameReplay= false;
    private Player player;
    private List<Enemy> enemiesSpawned = new List<Enemy>();
    private GameObject heroPrefabs;
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
        if(Instance!=null && Instance!=this)
        {
            Destroy(this);
        }    
        else
        {
            Instance = this;
        }    
    }
    void Start()
    {
        GUIManager.Instance.showHomeGUI();
        totalConis = PlayerPrefs.GetInt(Const.Coin_PREF, 0);
        homeCoinText.text = totalConis.ToString();
    }
    public void PlayGame()
    {
        GUIManager.Instance.showGameGUI();
        player = FindAnyObjectByType<Player>();
        
        StartCoroutine(spawnEnemy());
        
        instanceCoins = 0;
        score = 0;
        var shopUnits = ShopManagement.Instance.shopUnits;
        for(int i=0; i<shopUnits.Length;i++)
        {
            if(i==PlayerPrefs.GetInt(Const.PlayerId_PREF))
            {
                heroPrefabs = shopUnits[i].playerPrefab;
            }    
        }    
        heroInstance=Instantiate(heroPrefabs, new Vector3(-6, -1, 0), Quaternion.identity);
        instanceCoins = 0;
        score = 0;
        coinText.text = instanceCoins.ToString();
        AudioController.Instance.PlayBGMusic();
        isGameOver = false;
        isGameReplay = false;
    }    
    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            GUIManager.Instance.showGameOverBox();
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
