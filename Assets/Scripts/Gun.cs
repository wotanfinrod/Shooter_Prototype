using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour, IGun
{
    protected GameManager managerScript;

    [SerializeField] AudioClip shotSFX;
    [SerializeField] ParticleSystem muzzleEffect;

    int recoilCount = 0;
    protected Vector3 recoilRotateRate;

    protected float fireFreq; //Fire frequency

    protected int magazineSize;
    protected int magazine;
    protected int accuracyPercentage;
    protected int damage;
    protected int reloadTime;

    //Return values : 0-> Couldn't fire, 1-> Shot but missed, 2-> Shot and hit
    public virtual int Fire(float fireCounter)
    {

        if (fireCounter > fireFreq) //Fire permission
        {

            gameObject.GetComponent<AudioSource>().PlayOneShot(shotSFX);
            muzzleEffect.Play();

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
        
        else 
            return 0;
    }

    public virtual void FireRecoil()
    {
        gameObject.transform.localEulerAngles += recoilRotateRate;
        recoilCount++;
    }

    public virtual void FireRecoilStop()
    {
        gameObject.transform.localEulerAngles -= recoilRotateRate * recoilCount;
        recoilCount = 0;
    }

    public abstract void Reload();

    //Getter-Setters
    public int Damage
    {
        get {return damage;}
    }

    public int GetMagazine()
    {
        return magazine;
    }









}
