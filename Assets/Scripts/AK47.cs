using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Gun
{
    [SerializeField] AudioClip ak47_reload;
   
    float fireCounter;

    void Start()
    {
        managerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

        recoilRotateRate = new Vector3(-0.5f, 0, 0);

        magazineSize = 30;
        accuracyPercentage = 60;
        damage = 5;
        reloadTime = 5;
        fireFreq = 0.15f; 
        magazine = magazineSize;
    }

    public override void Reload()
    {
        StartCoroutine(ReloadWait());
    }

    IEnumerator ReloadWait()
    {
        if(managerScript.isSFXActive)gameObject.GetComponent<AudioSource>().PlayOneShot(ak47_reload);
        Debug.Log("Reloading...");       
        yield return new WaitForSeconds(5);
        Debug.Log("Gun reloaded");
        magazine = magazineSize;
    }

}
