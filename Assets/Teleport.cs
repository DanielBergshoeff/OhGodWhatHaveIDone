using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform transformToTeleportTo;
    
    private void OnTriggerEnter(Collider other) {
        other.transform.position = transformToTeleportTo.position;
    }
}
