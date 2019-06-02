using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour
{
    public static CatManager Instance;

    public List<BehaviourTree> Cats;
    public Vector3 TargetSize;
    public GameObject WinText;

    private bool checkIfFinished;


    

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        checkIfFinished = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIfFinished) {
            int count = 0;
            Collider[] colls = Physics.OverlapBox(transform.position, TargetSize / 2);
            foreach (Collider coll in colls) {
                if (coll.CompareTag("Cat"))
                    count++;
            }
            if (count >= Cats.Count)
                GameWon();
            checkIfFinished = false;
            Invoke("SetCheckIfFinished", 1.0f);
        }
    }

    private void SetCheckIfFinished() {
        checkIfFinished = true;
    }

    private void GameWon() {
        WinText.SetActive(true);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, TargetSize);
    }
}
