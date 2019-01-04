using UnityEngine;
using UnityEngine.AI; //for NavMeshAgent
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    private Transform player; // enemy will have to find player when instantiated
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    public bool isDamaging;
    public float damage = 25; 

    private NavMeshAgent nav; 

    //Whenever the player is inside the enemy sphere collider send message
    /*
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Ellen")
            col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
    }*/

    private void Awake()
    {
        //find Ellen
        player = GameObject.FindGameObjectWithTag("Ellen").transform;

        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> (); 

        nav = GetComponent<NavMeshAgent>();
        Debug.Log(nav.name + " found Ellen at coordinates" + GameObject.FindGameObjectWithTag("Ellen").transform.position);

    }


    // Update is called once per frame. Use for non-physics code
    void Update()
    {
        if (playerHealth.currentHealth > 0 && enemyHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position); //keep going toward the player
        }
        else
        {
            nav.enabled = false; //set navmesh componet to false
        }


    }
}
