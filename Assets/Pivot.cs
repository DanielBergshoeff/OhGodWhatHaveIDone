using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    private float speed = 3.0f;
    float xRot;
    float yRot;

    private void Start() {
        xRot = transform.eulerAngles.x;
        yRot = transform.eulerAngles.y;
    }

    void Update() {
        xRot += speed * Input.GetAxis("VerticalTurn");
        yRot += speed * Input.GetAxis("HorizontalTurn");

        //transform.Rotate(xRot, yRot, 0.0f, Space.Self);
        transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);
    }
}
