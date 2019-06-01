using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class BehaviourTree : MonoBehaviour
{
    public float AngerLevel = 0f;
    public int AngerStage = 0;
    public GameObject Target;

    private float followDistance = 0.1f;
    public bool follow;

    private Selector RootSelector;
    private ActionNode MoveRandomAction;
    private ActionNode FollowPlayerAction;

    private NavMeshAgent myNavMeshAgent;
    private Animator myAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        MoveRandomAction = new ActionNode(MoveRandom);
        FollowPlayerAction = new ActionNode(FollowPlayer);

        RootSelector = new Selector(new List<Node>() { MoveRandomAction, FollowPlayerAction});


        myNavMeshAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RootSelector.Evaluate();
        follow = false;
    }

    private NodeStates MoveRandom() {
        if (follow)
            return NodeStates.FAILURE;

        myAnimator.SetFloat("Speed", 2f);
        float yRotation = Random.Range(-1f, 1f);
        transform.Rotate(new Vector3(0f, yRotation * 3f, 0f));
        myNavMeshAgent.SetDestination(transform.position + transform.forward);
        return NodeStates.RUNNING;
    }

    private NodeStates FollowPlayer() {
        Vector3 direction = (transform.position - Target.transform.position).normalized;
        //myNavMeshAgent.SetDestination(Target.transform.position + direction * followDistance);
        myNavMeshAgent.SetDestination(Target.transform.position);

        return NodeStates.SUCCESS;
    }
}
