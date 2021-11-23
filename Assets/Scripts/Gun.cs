using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    protected GameManager managerScript;


    protected Vector3 originalRotation;
    protected Vector3 recoilRotateRate;

    protected int magazineSize;
    protected int magazine;
    protected int accuracyPercentage;
    protected int damage;
    protected int reloadTime;

    protected float fireFreq; //Fire frequency

    //GETTERS-SETTERS
    
    

    private void Start()
    {
    }



    public virtual int Fire(float fireCounter)
    {
        if (fireCounter > fireFreq) //Fire permission
        {
            managerScript.ResetCounter(); //Reset the counter
            FireRecoil();

            if (Random.Range(1, 101) <= accuracyPercentage && magazineSize != 0) //Hit check
            {
                Debug.Log(gameObject.name + " has shot and hit the target.");
                magazine--;
                return 2;
            }

            else
            {
                Debug.Log(gameObject.name + " has shot but couldn't hit the target.");
                magazine--;
                return 1;
            }
        }

        else return 0;

    }


        
    

    protected virtual void FireRecoil()
    {
        gameObject.transform.localEulerAngles += recoilRotateRate;        
    }

    public virtual void FireRecoilStop()
    {
        gameObject.transform.rotation = Quaternion.Euler(originalRotation.x, originalRotation.y, originalRotation.z);
        
    }

    public virtual void Reload()
    {
        Debug.Log("Gun reloaded");
        magazine = magazineSize;
    }

    //Getter-Setters
    public int Damage
    {
        get { return damage; }
    }

    public int Magazine
    {
        get { return magazine; }
    }









}
