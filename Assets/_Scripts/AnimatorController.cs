using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour { 

    private Animator anim; 

     float animSpeed;
    string nameofAnimation;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim[nameofAnimation].speed = animSpeed;
    }
}
