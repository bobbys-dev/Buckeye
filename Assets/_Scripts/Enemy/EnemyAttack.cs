using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttack = 2.5f;
    public int attackDamage = 5;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer; //to control how fast enemy can attack

    private void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Ellen"); //locate on instantiation
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>(); //get EnemyHealth script
        anim = GetComponent<Animator>(); //get self's Animator

    }

    //check if something touched enemy's sphere of attack and close enough to attack
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("I hit Ellen");

            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttack && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("Idle"); //transition to idle because there's nothing to chase
        }
    }

    void Attack()
    {
        timer = 0;

        //if player has health take away some of her health
        if(playerHealth.currentHealth > 0) {
            playerHealth.TakeDamage(attackDamage);

            //also causes self to take damage
            enemyHealth.TakeDamage(attackDamage * 5, transform.position);
        }
    }

}
