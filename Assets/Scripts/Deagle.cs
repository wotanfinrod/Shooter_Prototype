using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deagle : Gun
{

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

}