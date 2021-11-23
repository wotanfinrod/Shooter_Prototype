using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    private Vector3 originalRotation;
    Vector3 recoilRotateRate = new Vector3(-5, 0, 0);


    protected int magazineSize;
    protected int magazine;
    protected int accuracyPercentage;
    protected int damage;
    protected int reloadTime;

    protected float fireFreq; //Fire frequency

    

    private void Start()
    {
        originalRotation = gameObject.transform.rotation.eulerAngles;
    }



    public abstract bool Fire();
    

    protected virtual void FireRecoil()
    {
        gameObject.transform.localEulerAngles += recoilRotateRate;        
    }

    protected virtual void FireRecoilStop()
    {
        gameObject.transform.localEulerAngles -= recoilRotateRate;
    }

    public virtual void Reload()
    {
        Debug.Log("Gun reloaded");
        magazine = magazineSize;
    }



    







}
