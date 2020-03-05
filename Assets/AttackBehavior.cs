using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : StateMachineBehaviour
{
    public Transform speechBubbleSpawn;
    public GameObject speechBubble;
    private float rotationSpeed = 3.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Shoot();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    /*
     * void UpdateTarget()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player.transform.position);
        gunEnd.LookAt(player.transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), rotationSpeed * Time.deltaTime);
        //transform.position += transform.forward * moveSpeed * Time.deltaTime;

    }
    */

    /*
     * IEnumerator Shooting()
    {
        while (true)
        {
            GameObject temp = new GameObject();
            //Destroy(temp, 2f);
            temp = Instantiate(bullet, gunEnd.position, gunEnd.rotation);
            temp.transform.parent = transform;
            float length = temp.GetComponent<AudioSource>().clip.length + 5;

            yield return new WaitForSeconds(length);
        }
    }
     */
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
