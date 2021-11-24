using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    protected GameManager managerScript;

    [SerializeField] AudioClip shotSFX;
    [SerializeField] ParticleSystem muzzleEffect;

    protected Vector3 originalRotation;
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
                GameObject.Find("Dummy").GetComponent<Animator>().SetTrigger("pushTrig");
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

    protected virtual void FireRecoil()
    {
        gameObject.transform.localEulerAngles += recoilRotateRate;        
    }

    public virtual void FireRecoilStop()
    {
        gameObject.transform.rotation = Quaternion.Euler(originalRotation.x, originalRotation.y, originalRotation.z);  
    }

    public abstract void Reload();

    //Getter-Setters
    public int Damage
    {
        get {return damage;}
    }

    public int Magazine
    {
        get {return magazine;}
    }









}
