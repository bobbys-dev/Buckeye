using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Image currentHealthBar;
    public Text ratioText;
    private float hitpoint = 150;
    private float maxHitpoint = 150;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthbar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + '%';
    }

    private void TakeDamage(float damage)
    {
        hitpoint -= damage;
        if (hitpoint < 0)
        {
            hitpoint = 0;
            Debug.Log("Dead!");
        }
        UpdateHealthbar();
    }

    private void HealDamage(float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxHitpoint)
            hitpoint = maxHitpoint;

        UpdateHealthbar();
    }

}
