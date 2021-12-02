using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dummy : MonoBehaviour
{
    const int healthTextIndex = 2;
    TMP_Text healthText;
    
    Animator dummyAnim;

    private int healthPoint;
    public bool isDead; 

    void Start()
    {
        dummyAnim = gameObject.GetComponent<Animator>();
        healthText = gameObject.transform.GetChild(healthTextIndex).gameObject.GetComponent<TMP_Text>();
        isDead = false;
        healthPoint = 100;

        

    }

    public void TakeDamage(int damagePoint)
    {
        gameObject.GetComponent<Animator>().SetTrigger("pushTrig");

        healthPoint -= damagePoint;
        if(healthPoint <= 0)
        {
            dummyAnim.SetTrigger("dieTrig");
            isDead = true;
            Debug.Log("Dummy is dead");
            healthPoint = 0;
        }

        healthText.text = healthPoint.ToString();

    }

    public void RegenerateDummy()
    {
        Debug.Log("Dummy is revived");
        dummyAnim.SetTrigger("reviveTrig");
        isDead = false;
        healthPoint = 100;

        healthText.text = healthPoint.ToString();

    }

    //Getter-Setters
    public int HealthPoint
    {
        get {return healthPoint;}
    }


}
