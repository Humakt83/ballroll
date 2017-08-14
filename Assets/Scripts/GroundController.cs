using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

    private readonly float TILT = 30.0f;
    private readonly float MINIMUM_AXIS_TILT = -30.0f;

    private void FixedUpdate() {
        float tiltAroundZ = Input.GetAxis("Horizontal") * TILT;
        float tiltAroundX = Input.GetAxis("Vertical") * TILT;
        Quaternion target = Quaternion.Euler(tiltAroundX * -1, 0, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 0.2f);
    }

}
