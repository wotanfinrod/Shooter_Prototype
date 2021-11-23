using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Gun
{
    float fireCounter;

    // Start is called before the first frame update
    void Start()
    {
        managerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

        originalRotation = transform.rotation.eulerAngles;

        recoilRotateRate = new Vector3(-0.5f, 0, 0);
        magazineSize = 30;
        accuracyPercentage = 60;
        damage = 5;
        reloadTime = 5;

        fireFreq = 0.15f; 
        magazine = magazineSize;

    }


}
