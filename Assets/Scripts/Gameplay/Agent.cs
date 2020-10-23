using UnityEngine;

public class Agent : MonoBehaviour
{
    public void ResetAgent()
    {
        transform.position = Vector3.zero;
        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.isKinematic = false;
        

    }

    public void CheckPos()
    {
        if (!Helper.IsPlaying())
            return;
        if (transform.position.y < -10f)
            ResetAgent();
                
    }

}

