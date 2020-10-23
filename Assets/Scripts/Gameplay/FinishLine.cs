using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public int count;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.main.game.FinishRace();
        }else if(other.gameObject.TryGetComponent(out AIMovement component))
        {
            component.Animate(Vector3.zero);
            component.enabled = false;
        }
    }
}
