using System.Collections;
using UnityEngine;
using UnityEngine.UI; //for Slider UI, text, images...

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f,0f,0f,0.7f);

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement; //reference to outside script
    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>(); //get reference to script
        //playerShooting = GetComponentInChildren<PlayerShooting>();
        currentHealth = startingHealth;

    }

    // Update is called once per frame
    void Update()
    {
        //flash whenever we get damaged
        if (damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            //smoothly transition color to transparent using linear interpolation 
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed*Time.deltaTime);

        }
        damaged = false;
    }

    //other scripts call this function
    public void TakeDamage (int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth; //update slider
        playerAudio.Play();

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        //playerShooting.DisableEffects();

        anim.SetTrigger("playerDie"); //set animator controller to play death animation

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false; //disable input for movement
        //playerShooting.enabled = false;

    }
}
