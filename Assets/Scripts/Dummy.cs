using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    Animator dummyAnim;

    private int healthPoint;
    public bool isDead;

    void Start()
    {
        dummyAnim = gameObject.GetComponent<Animator>();
        isDead = false;
        healthPoint = 100;
    }

    public void TakeDamage(int damagePoint)
    {
        healthPoint -= damagePoint;
        if(healthPoint <= 0)
        {
            dummyAnim.SetTrigger("dieTrig");
            isDead = true;
            Debug.Log("Dummy is dead");
            healthPoint = 0;
        }
    }

    public void RegenerateDummy()
    {
        Debug.Log("Dummy is revived");
        dummyAnim.SetTrigger("reviveTrig");
        isDead = false;
        healthPoint = 100;

    }



}
