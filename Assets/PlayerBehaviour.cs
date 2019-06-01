using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float maxFollowTime;
    public float maxCatDistance;

    private float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V)) {
            foreach(BehaviourTree cat in CatManager.Instance.Cats) {
                if(Vector3.Distance(cat.transform.position, transform.position) < maxCatDistance) {
                    cat.follow = true;
                }
            }
        }
    }
}
