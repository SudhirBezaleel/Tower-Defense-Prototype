using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnim : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("walkStyle", Random.Range(0, 5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
