using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkToPlayer : MonoBehaviour
{
    protected enum Situation {Stop,Walk,Run};
    [SerializeField] VRMAnimControler vrmAnimControler;
    [SerializeField] BaseVRMAnimEnum idleAnim;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Transform target;
    /// <summary>
    /// x:í‚é~ãóó£ y:ï‡çsãóó£ z:ëñçsãóó£
    /// </summary>
    [SerializeField] Vector3 controllDistance;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    Situation situation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = target.position;
        UpdateSituation();
        UpdateBehavior();
        
    }
    void UpdateSituation()
    {
        float distance = (navMeshAgent.destination - transform.position).magnitude;
        if(distance <= controllDistance.x)
        {
            situation = Situation.Stop;
        }else if(distance <= controllDistance.y)
        {
            situation= Situation.Walk;
        }
        else if(distance <= controllDistance.z)
        {
            situation = Situation.Run;
        }
    }
    void UpdateBehavior()
    {
        switch (situation)
        {
            case Situation.Stop:
                navMeshAgent.speed = 0;
                navMeshAgent.velocity = Vector3.zero;
                vrmAnimControler.BaseAnimEnum = idleAnim;
                break;
            case Situation.Walk:
                navMeshAgent.speed = walkSpeed;
                navMeshAgent.acceleration = 10;
                vrmAnimControler.BaseAnimEnum = BaseVRMAnimEnum.WALK00_F;
                break;
            case Situation.Run:
                navMeshAgent.speed = runSpeed;
                navMeshAgent.acceleration = 10;
                vrmAnimControler.BaseAnimEnum = BaseVRMAnimEnum.RUN00_F;
                break;
        }
    }
}
