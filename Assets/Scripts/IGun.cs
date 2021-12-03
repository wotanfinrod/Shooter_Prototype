using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun 
{
    void FireRecoil();
    void FireRecoilStop();
    void Reload();
    int  GetMagazine();
    bool Fire(float fireCounter);
    }
