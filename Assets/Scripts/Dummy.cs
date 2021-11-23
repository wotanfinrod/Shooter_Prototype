using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    private int healthPoint;
    public bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        healthPoint = 100;
    }

    public void TakeDamage(int damagePoint)
    {
        healthPoint -= damagePoint;
        if(healthPoint <= 0)
        {
            isDead = true;
            Debug.Log("Dummy is dead");
            healthPoint = 0;
        }
       


    }

    public void RegenerateDummy()
    {
        isDead = false;
        healthPoint = 100;

    }
}
