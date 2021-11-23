using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Gun
{
    // Start is called before the first frame update
    void Start()
    {
        magazineSize = 30;
        accuracyPercentage = 60;
        damage = 5;
        reloadTime = 5;

        fireFreq = 6.66f;

        magazine = magazineSize;

    }

    // Update is called once per frame
    void Update()
    {
        magazine = magazineSize;
        
    }

    public override bool Fire()
    {
        return false;
    }



}
