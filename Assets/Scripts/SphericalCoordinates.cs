using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalCoordinates
{
    // NO MORE USED
    /* 
    public Transform targetTransform;

    [SerializeField]
    public float radius, theta, phi, speed;

    public Vector3 TargetPos;

    [ContextMenu("Deploy")]
    private void Deploy(){
        sphe2orth()
    }
    */

    /*
        theta : azimuth
        phi : inclination
    

    public Vector3 sphe2orth(radius, theta, phi)
    {
        Vector3 TargetPos = new Vector3(0.0f, 0.0f, 0.0f);
        theta_rad = theta * Mathf.Deg2Rad;
        phi_rad = phi * Mathf.Deg2Rad;
        TargetPos.x = radius * Mathf.Cos(phi_rad) * Mathf.Cos(theta_rad);
        TargetPos.y = radius * Mathf.Sin(phi_rad);
        TargetPos.z = radius * Mathf.Cos(phi_rad) * Mathf.Sin(theta_rad);

        return TargetPos
    }
    */

}
