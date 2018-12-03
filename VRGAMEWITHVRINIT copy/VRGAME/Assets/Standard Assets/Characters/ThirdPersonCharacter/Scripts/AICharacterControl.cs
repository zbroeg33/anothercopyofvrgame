using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    [RequireComponent(typeof(AudioSource))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
       
       
        public Transform target;    
        
        public GameObject[] players;   
        public AudioSource audio;
        public AudioClip AttackSound;
        public AudioClip IdleSound;

        public AudioClip ChaseSound;       
        
        int i;      
                      


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            audio = GetComponent<AudioSource>();
            
	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length > 0) {
                target = players[i].transform;
               // Debug.Log("Player " + target);
               // Debug.Log(players.Length);
            }
             agent.isStopped = false;
           
           GameObject closest = null;
                    float distance = Mathf.Infinity;
                    Vector3 postiion = players[i].transform.position;

            foreach ( GameObject player in players) {
                
                Vector3 diff = player.transform.position - transform.position;
                float curDistance = diff.sqrMagnitude;
                if(curDistance < distance) {
                    closest = player;
                    distance = curDistance;
                    if((closest.transform.position - transform.position).magnitude <= 25.0f && (closest.transform.position - transform.position).magnitude >= 3.5f) {
                        agent.SetDestination(closest.transform.position);
                        //audio.clip=ChaseSound;
                       audio.PlayOneShot(ChaseSound);
                       // audio.Play();
                        
                       
                    } else if((closest.transform.position - transform.position).magnitude <=3.0f) {
                        //audio.clip=AttackSound;
                      audio.PlayOneShot(AttackSound);
                        //audio.Play();
                    }
                    else  {
                        agent.isStopped = true;
                       // audio.clip = IdleSound;
                      audio.PlayOneShot(IdleSound);
                       // audio.Play();
                    }
                    
                     
                     
                     
                if (agent.remainingDistance > agent.stoppingDistance) {
                character.Move(agent.desiredVelocity, false, false);
                 } else{
                character.Move(Vector3.zero, false, false);
                }
            }
                }  
               
            }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
