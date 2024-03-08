using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemy_speed;
    public float atkDistance;
    private GameObject hero;
    private Rigidbody2D rb;
    private Animator enemy_anim;
    private GameObject hero_weapon;
    private bool isDead;
    private Player player;
    private GameManagement gameManage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy_anim = GetComponent<Animator>();
        hero = GameObject.FindWithTag(Const.Player_tag);
        hero_weapon= GameObject.FindWithTag(Const.HeroWeapon_tag);
        player = FindObjectOfType<Player>();
        gameManage = FindObjectOfType<GameManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttacked = enemy_anim.GetBool(Const.attackParameter);
        if (rb != null && hero != null)
        {
            if (ableToAttack(hero))
            {
                enemy_anim.SetBool(Const.attackParameter, true);
            }
            else
            {
                // Cách 1:
                //Vector2 movement = new Vector2(-enemy_speed * Time.deltaTime, 0); // Di chuyển theo trục x
                //transform.position = (Vector2)transform.position + movement;
                // Cách 2:
                //rb.MovePosition(rb.position + movement);
                //Cách 3:
                rb.velocity = new Vector2(-enemy_speed,rb.velocity.y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Const.HeroWeapon_tag))
        {
            isDead = true;
            enemy_anim.SetTrigger(Const.deathParameter);
            gameObject.layer = LayerMask.NameToLayer(Const.Dead_layer);
            int randomCoins = Random.Range(1, 5);
            gameManage.instanceCoins += randomCoins;
            gameManage.score++;
            gameManage.coinText.text = gameManage.instanceCoins.ToString();
        }    
    }
    public bool ableToAttack(GameObject obj)
    {
        if(Vector2.Distance(obj.transform.position, transform.position)<=atkDistance)
        {
            return true;
        }    
        return false;
    }
    public void resetDead()
    {
        if(isDead)
        {
            gameObject.SetActive(false);
        }    
    } 
    
}
