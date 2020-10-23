using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{
    public float power;
    private void OnCollisionExit(Collision collision)
    {


        if (collision.other.CompareTag("Opponent"))
        {
            collision.other.GetComponent<AIMovement>().ResetAgent();
            collision.other.GetComponent<AIMovement>().nextLocation = collision.transform.position;

            return;
        }

        var dir = collision.transform.forward;
        Debug.Log(collision.gameObject.name);
        if(collision.contactCount>0)
            dir = collision.transform.position - collision.contacts[0].point;
        collision.other.GetComponent<Rigidbody>().AddForce((dir) * power, ForceMode.Force);


    }
}
