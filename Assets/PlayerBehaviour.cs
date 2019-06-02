using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float maxFollowTime;
    public float maxCatDistance;
    public float timeBetweenFollow;

    private bool timeOut = false;
    private float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey("joystick button 2") || Input.GetKey(KeyCode.M)) && timer <= 0f && !timeOut) {
            timeOut = true;
            timer = maxFollowTime;
            Invoke("SetTimeOut", timeBetweenFollow + maxFollowTime);
        }
        if(timer > 0f) {
            timer -= Time.deltaTime;
            if (timer > 0f)
                MakeCatsFollow();
        }
    }

    private void SetTimeOut() {
        timeOut = false;
    }

    private void MakeCatsFollow() {
        foreach (BehaviourTree cat in CatManager.Instance.Cats) {
            if (Vector3.Distance(cat.transform.position, transform.position) < maxCatDistance) {
                cat.follow = true;
            }
        }
    }
}
