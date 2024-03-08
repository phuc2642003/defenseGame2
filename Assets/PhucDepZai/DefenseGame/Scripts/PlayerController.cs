using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    private Animator hero_anim;
    private GameObject e_weapon;
    private static bool isDead;
    private GameManagement gameManage;
    // Start is called before the first frame update
    void Start()
    {
        hero_anim = GetComponent<Animator>();
        e_weapon = GameObject.FindWithTag(Const.EnemyWeapon_tag);
        gameManage = FindObjectOfType<GameManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttacked = hero_anim.GetBool(Const.attackParameter);
        if (Input.GetMouseButtonDown(0))
        {
            //if(hero_anim)
            if(!isAttacked && hero_anim)
            {
                hero_anim.SetBool(Const.attackParameter, true);
            }
        }    
    }
    public void resetAtk()
    {
        if(hero_anim.GetBool(Const.attackParameter))
        {
            hero_anim.SetBool(Const.attackParameter, false);
        }    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(Const.EnemyWeapon_tag))
        {
            hero_anim.SetTrigger(Const.deathParameter);
            isDead = true;
            //gameManage.isGameOver = true;
            gameObject.layer = LayerMask.NameToLayer(Const.Dead_layer);
        }    
    }
    public void GameOver()
    {
        if(isDead)
        {
            gameManage.isGameOver = true;
            gameManage.totalConis += gameManage.instanceCoins;
            gameManage.homeCoinText.text = gameManage.totalConis.ToString();
            PlayerPrefs.SetInt(Const.Coin_PREF, gameManage.totalConis);
            if (gameManage.score > PlayerPrefs.GetInt(Const.Best_Score_PREF, 0))
            {
                gameManage.bestScore = gameManage.score;
            }
            else
            {
                gameManage.bestScore = PlayerPrefs.GetInt(Const.Best_Score_PREF, 0);
            }
            gameManage.bestScoreText.text = gameManage.bestScore.ToString();
            PlayerPrefs.SetInt(Const.Best_Score_PREF, gameManage.bestScore);
        }   
    }    
}
