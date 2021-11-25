using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenMovement : MonoBehaviour
{
   public Transform goal;
   Animator anim;

    NavMeshAgent agent;
       
       void Start () {
         agent = GetComponent<NavMeshAgent>();
         anim = GetComponent<Animator>();
       }

       private void Update() {
         agent.destination = goal.position - new Vector3(-0.5f, 0f, -0.5f);
         if (Mathf.Abs(agent.velocity.x + agent.velocity.y + agent.velocity.z) < .05) {
            anim.SetBool("Run", false);
            anim.SetBool("Eat", true);
         } else {
            anim.SetBool("Eat", false);
            anim.SetBool("Run", true);
         }
       }
}
