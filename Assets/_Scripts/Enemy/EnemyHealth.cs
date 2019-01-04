using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime); //move enemy down
        }
    }

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if (isDead)
        {
            return;
        }

        enemyAudio.Play();

        currentHealth -= amount;

        hitParticles.transform.position = hitPoint; //move the particles to the hitPoint of the body
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death();
        }


    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true; // set as trigger to "remove" collision 

        anim.SetTrigger("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false; //turn component off
        GetComponent<Rigidbody>().isKinematic = true; //so that Unity will ignore collidor and prevent recalculation
        isSinking = true;
        //ScoreManager.score += scoreValue;
        Destroy(gameObject, 3f); //remove after 3 seconds
    }

}
