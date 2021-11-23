using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int currentWeapon; // 0 for AK47, 1 for Desert Eagle

    

    AK47 ak47;
    Deagle deagle;
    Dummy dummy;


    void Start()
    {
        ak47 = GameObject.Find("AK47").GetComponent<AK47>();
        deagle = GameObject.Find("DesertEagle").GetComponent<Deagle>();
        dummy = GameObject.Find("Dummy").GetComponent<Dummy>();

        currentWeapon = 0;
        deagle.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)) //Fire
        {
            if (currentWeapon == 0) ak47.Fire();
            else if (currentWeapon == 1) deagle.Fire();


        }

        else if(Input.GetKeyDown(KeyCode.Space)) //Change the weapon
        {
            if(currentWeapon == 0) //Change to deagle
            {
                Debug.Log("Active Weapon: Desert Eagle");
                currentWeapon = 1;
                ak47.gameObject.SetActive(false);
                deagle.gameObject.SetActive(true);
            }

            else        //Current is Deagle
            {
                Debug.Log("Active Weapon: AK47");
                currentWeapon = 0;
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
            switch (currentWeapon)             
            {
                case 0:
                    ak47.Reload();
                    break;
                case 1:
                    deagle.Reload();
                    break;
            }
                


        }



    }




}
