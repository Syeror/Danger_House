using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class enemyAl : MonoBehaviour
{
    public float ViewAngle;
    private NavMeshAgent _navMeshAgent;
    public List<Transform> PatrolPoint;
    public PlayerMovement Player;
    private bool _isPlayerNoticed;
    public float damage = 15;
    private PlayerHealth _PlayerHealth;
    public float ViewDistance = 5;
    private float timer = 0;
    public float reloader = 0;
    public Animator animator;
    public Collider ColliderMonster;
    void Start()
    {
        inComponentLink();
        PickNewPatrolPoint();
    }


    private void inComponentLink()
    {
       _PlayerHealth = Player.GetComponent<PlayerHealth>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

    }
    // Update is called once per frame
    void Update()
    {
      // PickNewPatrolPoint();
        timer += Time.deltaTime;
        IsplayerNoticedUpdate();
        pursuitUpdate();
        AttackUpdate();






    }
    private void PickNewPatrolPoint()
    {
        if (!_isPlayerNoticed)
        {
          //  Debug.Log(PatrolPoint);
            _navMeshAgent.destination = PatrolPoint[Random.Range(0, PatrolPoint.Count)].position;
            animator.SetTrigger("Walk_Cycle_1");
           // animator.SetTrigger("Intimidate_1");
        }
    }
    private void IsplayerNoticedUpdate()
    {
        var Direction = Player.transform.position - transform.position;

     //   Debug.DrawRay(transform.position, Direction);
         if (Vector3.Distance(transform.position, Player.transform.position) <= ViewDistance)
        {
            if (Vector3.Angle(transform.forward, Direction) < ViewAngle)
            {

                RaycastHit hit;
                _isPlayerNoticed = false;
                //animator.SetTrigger("Take_Damage_3");


                if (Physics.Raycast(transform.position + Vector3.up, Direction, out hit, 9999))
                {
                    if (hit.collider.gameObject == Player.gameObject)
                    {
                        _isPlayerNoticed = true;
                //animator.SetTrigger("Sneak_Cycle_1");
                        animator.SetTrigger("Walk_Cycle_1");
                        animator.SetTrigger("Walk_Cycle_3");



                    }

                }
            }
            // Код проверки угла и рейкаста остается тем же
        }
            else
            {
                PatrolUpdate();
            //animator.SetTrigger("Intimidate_3");
            animator.SetTrigger("Walk_Cycle_2");
        }

    }
    private void pursuitUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = Player.transform.position;
            animator.SetTrigger("Walk_Cycle_2");
        }

    }
    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            PickNewPatrolPoint();
           // animator.SetTrigger("Intimidate_1");
            animator.SetTrigger("Walk_Cycle_1");
        }
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {

            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance || ColliderMonster.isTrigger)
            {
                animator.SetTrigger("Walk_Cycle_1");
                if (timer >= reloader)
                {
                    _PlayerHealth.DealDamage(damage);
                    animator.SetTrigger("Attack_1");
                    timer = 0;
                }
                animator.SetTrigger("Walk_Cycle_2");
            }
        }
    }
}

