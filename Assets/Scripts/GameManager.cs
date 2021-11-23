using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    
    bool isFiring;
    float fireCounter;

    AK47 ak47;
    Deagle deagle;
    Dummy dummy;


    void Start()
    {
        ak47 = GameObject.Find("AK47").GetComponent<AK47>();
        deagle = GameObject.Find("DesertEagle").GetComponent<Deagle>();
        dummy = GameObject.Find("Dummy").GetComponent<Dummy>();

        isFiring = false;
        deagle.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        fireCounter += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.S) && !dummy.isDead) //Fire Deagle (Semi-Automatic)
        {            
            if (deagle.gameObject.activeSelf)
            {
                if(deagle.Magazine != 0)
                {
                    int x = deagle.Fire(fireCounter);


                }



            }
        }

        if(Input.GetKey(KeyCode.S) && !dummy.isDead) //Fire AK47 (Automatic)
        {
            if (ak47.gameObject.activeSelf)
            {
                if(ak47.Magazine != 0)
                { 
                    
                    int x = ak47.Fire(fireCounter);
                    
                    if (x == 2) dummy.TakeDamage(ak47.Damage);
                }
                else
                {
                    Debug.Log("Magazine is empty. Reload.");
                }

            }


        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            if (ak47.gameObject.activeSelf) ak47.FireRecoilStop();
            else if (deagle.gameObject.activeSelf) deagle.FireRecoilStop();

            isFiring = false;
        }

        else if(Input.GetKeyDown(KeyCode.Space)) //Change the weapon
        {
            if(ak47.gameObject.activeSelf) //Change to deagle
            {
                Debug.Log("Active Weapon: Desert Eagle");
                ak47.gameObject.SetActive(false);
                deagle.gameObject.SetActive(true);
            }

            else        //Current is Deagle
            {
                Debug.Log("Active Weapon: AK47");
                deagle.gameObject.SetActive(false);
                ak47.gameObject.SetActive(true);

            }
            

        }

        


        else if(Input.GetKeyDown(KeyCode.T)) //Revive the target
        {
            dummy.RegenerateDummy();
        }

        else if(Input.GetKeyDown(KeyCode.R)) //Reload
        {
            if (ak47.gameObject.activeSelf) ak47.Reload();
            else if (deagle.gameObject.activeSelf) deagle.Reload();
        }



    }

    public void ResetCounter()
    {
        fireCounter = 0;
    }




}
