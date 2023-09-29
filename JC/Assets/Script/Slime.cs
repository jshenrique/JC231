using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    private Animator anim;
    public int HP;
    private bool isDie;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void GetHit(int amount)
    {
         HP -= amount;
        if(HP > 0)
        {
            anim.SetTrigger("GetHit");
        }
        else if(!isDie)
        {
            anim.SetTrigger("Die");
            isDie = true;
            Destroy(this.gameObject, 2f);
        }
        
    }
}
