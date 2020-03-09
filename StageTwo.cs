using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTwo : StateMachineBehaviour
{
     private Transform playerPos;

   // public BulletHellMono bulletHellMono;

    public float startWaitTime;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float speed;
    public Transform moveSpot;
    private float waitTime;

    public GameManager gm;


    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject bossProjectile1;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("player1").transform;
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        timeBtwShots = startTimeBtwShots;

       // bulletHellMono.InvokeRepeating("Fire", 0f, 2f);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed
        //    * Time.deltaTime);

          /*if (gm.gameOver)
          {
              return;
          } */

        animator.transform.position = Vector2.MoveTowards(animator.transform.position, moveSpot.position,
         speed * Time.deltaTime);
        if (Vector2.Distance(animator.transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(bossProjectile1, animator.transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

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
