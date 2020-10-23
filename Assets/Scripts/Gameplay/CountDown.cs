using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{

    public float duration;
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(CountDownRoutine(duration));
    }

    private IEnumerator CountDownRoutine(float duration)
    {
        Text countDown = GetComponent<Text>();
        while (duration > 0)
        {
            duration -= Time.deltaTime;
            countDown.text = duration.ToString("0.00");

            yield return new WaitForSeconds(Time.deltaTime);
        }

        countDown.text = "Good Job!";
        yield return new WaitForSeconds(2f);
        GameManager.main.game.Play();
    }
}
