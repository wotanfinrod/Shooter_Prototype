using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deagle : Gun
{
    [SerializeField]AudioClip deagle_reload;
    [SerializeField] AudioClip deagle_shot;

    void Start()
    {
        managerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        recoilRotateRate = new Vector3(0, 0, -10f);
        magazineSize = 10;
        accuracyPercentage = 90;
        damage = 40;
        reloadTime = 4;
        fireFreq = 1f;

        magazine = magazineSize;
        originalRotation = transform.rotation.eulerAngles;


    }

    public override void Reload()
    {
        StartCoroutine(ReloadWait());
    }

    IEnumerator ReloadWait()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(deagle_reload);
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(4);
        Debug.Log("Gun reloaded");
        magazine = magazineSize;

    }

}