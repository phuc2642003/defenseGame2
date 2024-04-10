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

    // Start is called before the first frame update
    void Start()
    {
        hero_anim = GetComponent<Animator>();
        e_weapon = GameObject.FindWithTag(Const.EnemyWeapon_tag);
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
                AudioController.Instance.PlaySound(AudioController.Instance.playerAttack);
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
            GameManagement.Instance.isGameOver = true;
            GameManagement.Instance.totalConis += GameManagement.Instance.instanceCoins;
            GameManagement.Instance.homeCoinText.text = GameManagement.Instance.totalConis.ToString();
            PlayerPrefs.SetInt(Const.Coin_PREF, GameManagement.Instance.totalConis);
            if (GameManagement.Instance.score > PlayerPrefs.GetInt(Const.Best_Score_PREF, 0))
            {
                GameManagement.Instance.bestScore = GameManagement.Instance.score;
            }
            else
            {
                GameManagement.Instance.bestScore = PlayerPrefs.GetInt(Const.Best_Score_PREF, 0);
            }
            GameManagement.Instance.bestScoreText.text = GameManagement.Instance.bestScore.ToString();
            PlayerPrefs.SetInt(Const.Best_Score_PREF, GameManagement.Instance.bestScore);
            AudioController.Instance.PlaySound(AudioController.Instance.gameOver);
            AudioController.Instance.StopPlayMusic();
        }   
    }    
}
    