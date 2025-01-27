using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class bounceInGma : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 directionOut = gameObject.transform.position-collision.transform.position  ;
        collision.rigidbody.AddForce(directionOut, ForceMode.Impulse);
    }
}
