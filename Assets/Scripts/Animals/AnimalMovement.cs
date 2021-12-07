using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    private GameObject self;
    public AudioSource soundEffect;

    private Rigidbody rb;
    public Transform target;
    Animator anim;

    bool canMove = false;
    bool canFollow = false;

    void Awake()
    {
        self = GetComponent<GameObject>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (canFollow)
            FollowTargetWithRotation(target, 3f, 5f, 20f);
    }

    void FollowTargetWithRotation(Transform target, float distanceToStop,float distanceToStart, float speed)
     {
         transform.LookAt(target);

         if (Vector3.Distance(transform.position, target.position) <= distanceToStop) {
            anim.SetInteger("Walk", 0);
            canMove = false;
         }
         else if((!canMove && Vector3.Distance(transform.position, target.position) > distanceToStart) || canMove)
         {
             canMove = true;
             transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.08f);
             anim.SetInteger("Walk", 1);
         } else {
            anim.SetInteger("Walk", 0);
            canMove = false; 
         }
     }

     private void OnTriggerEnter(Collider other) {
         if (!canFollow)
            if (other.CompareTag("Player"))
                if (Inventory.instance.Add(this.gameObject)) {
                    canFollow = true;
                    soundEffect.Play();
                }
     }
}
