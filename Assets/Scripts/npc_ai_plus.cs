using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class npc_ai_plus : MonoBehaviour
{
 public NavMeshAgent _agent;
 [SerializeField] public Transform _player;
 public LayerMask ground, player;

 public Vector3 destinationPoint;
 private bool destinationPointSet;
 public float walkPointRange;

 public float reloadTime;
 // private bool alreadyAttacked;
 // public GameObject sphere;

 public float sightRange, attackRange;
 public bool playerInSightRange;
 public bool playerInAttackRange;


 private void Awake()
 {
  _agent = GetComponent<NavMeshAgent>();
  
 }


 private void Update()
 {
  playerInSightRange = Physics.CheckSphere(transform.position, sightRange, player);
  playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, player);
  
  // Patrol / Chase / Attack

  if (!playerInSightRange && !playerInAttackRange) Patroling ();
  if (playerInSightRange && !playerInAttackRange) ChasePlayer();
 // if (playerInSightRange && playerInAttackRange) AttackPlayer();

 }


 void Patroling()
 {
  if (!destinationPointSet) SearchWalkPoint();
  if (destinationPointSet)
  {
   _agent.SetDestination(destinationPoint);
  }

  Vector3 distanceToDestinationPoint = transform.position - destinationPoint;
  if (distanceToDestinationPoint.magnitude<1.0f)
  {
   destinationPointSet = false;
  }

 }

 void SearchWalkPoint()
 {
  float randomX = Random.Range(-walkPointRange, walkPointRange);
  float randomZ = Random.Range(-walkPointRange, walkPointRange);

  destinationPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

  if (Physics.Raycast(destinationPoint,-transform.up,2.0f,ground))
  {
   destinationPointSet = true;
  }

 }
 
 
 void ChasePlayer()
 {
  _agent.SetDestination(_player.position);
 }

 
 
//void AttackPlayer()
//{
// _agent.SetDestination(transform.position);
// 
// transform.LookAt(_player);
// if (!alreadyAttacked)
// {
//  Rigidbody rb = Instantiate(sphere, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
//  rb.AddForce(transform.forward * 25f,ForceMode.Impulse);
//  rb.AddForce(transform.up * 7f,ForceMode.Impulse);
//  StartCoroutine(changetag(rb.gameObject));
//  
//  alreadyAttacked = true;
//  Invoke(nameof(ResetAttack),reloadTime);
//  
// }
// 
//}

 IEnumerator changetag(GameObject gameObject)
 {
  yield return new WaitForSeconds(2);
  gameObject.tag = "Respawn";
 }
 
 
 

//  void ResetAttack()
//  {
//   alreadyAttacked = false;
//  }
 

}
