using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public ParticleSystem fxGrass;
    void GetHit(int amount)
    {
        transform.localScale = new Vector3(2f, 2f, 2f);
        fxGrass.Emit(20);
    }
}
