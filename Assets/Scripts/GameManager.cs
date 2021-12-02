using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject crosshair_idle;
    [SerializeField] GameObject crosshair_attack;

    [SerializeField]TMP_Text healthText;
    [SerializeField]TMP_Text magazineText;
  
    float fireCounter;

    AK47 ak47;
    Deagle deagle;
    public Dummy selectedDummy;

    void Start()
    {
        ak47 = GameObject.Find("AK47").GetComponent<AK47>();
        deagle = GameObject.Find("DesertEagle").GetComponent<Deagle>();

        deagle.gameObject.SetActive(false);
    }

    void Update()
    {
        //Selecting the Dummy in front of camera
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            crosshair_attack.SetActive(true);
            crosshair_idle.SetActive(false);

            selectedDummy = hit.transform.gameObject.GetComponent<Dummy>();
            Debug.Log("Selected Dummy:" + hit.transform.gameObject.name);
        }

        else //Deselecting dummy
        {
            crosshair_attack.SetActive(false);
            crosshair_idle.SetActive(true);
            selectedDummy = null;
        }
        fireCounter += Time.deltaTime;

        //Fire
        
        if(Input.GetKeyDown(KeyCode.S) && selectedDummy != null && !selectedDummy.isDead) //Fire Deagle (Semi-Automatic)
        {            
            if (deagle.gameObject.activeSelf)
            {
                if(deagle.Magazine != 0)
                {
                    int x = deagle.Fire(fireCounter);
                    if (x == 2) selectedDummy.TakeDamage(deagle.Damage);
                }
                else
                {
                    Debug.Log("Magazine is empty. Reload.");
                }
            }
        }

        if(Input.GetKey(KeyCode.S) && selectedDummy != null && !selectedDummy.isDead) //Fire AK47 (Automatic)
        {
            if (ak47.gameObject.activeSelf)
            {
                if(ak47.Magazine != 0)
                {   
                    int x = ak47.Fire(fireCounter);                
                    if (x == 2) selectedDummy.TakeDamage(ak47.Damage);
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
        }

        //Change the weapon
        else if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if(ak47.gameObject.activeSelf) //Current was AK47
            {
                Debug.Log("Active Weapon: Desert Eagle");
                ak47.gameObject.SetActive(false);
                deagle.gameObject.SetActive(true);
            }

            else //Current was Deagle
            {
                Debug.Log("Active Weapon: AK47");
                deagle.gameObject.SetActive(false);
                ak47.gameObject.SetActive(true);

            }
        }
        
        //Revive the target
        else if (Input.GetKeyDown(KeyCode.T)) 
        {
            selectedDummy.RegenerateDummy();
        }

        //Reload
        else if (Input.GetKeyDown(KeyCode.R)) 
        {
            if (ak47.gameObject.activeSelf) ak47.Reload();
            else if (deagle.gameObject.activeSelf) deagle.Reload();
        }

        //UI
        if (ak47.gameObject.activeSelf) magazineText.text = ": " + ak47.Magazine.ToString();
        else magazineText.text = ": " + deagle.Magazine.ToString();
   
        }

    public void ResetCounter()
    {
        fireCounter = 0;
    }
}
