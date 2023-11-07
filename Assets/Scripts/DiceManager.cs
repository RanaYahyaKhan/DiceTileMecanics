using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class DiceManager : MonoBehaviour
{
    public Transform[] diceFaces;

    private Rigidbody rb;

    private bool stopRolling;
    private bool delayFinish;

    public int diceIndex = -1;


    public static UnityAction<int, int> onDiceResult;
    //private bool diceResult = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody> ();
    }

    private void Update()
    {
        if (!delayFinish) { return; }

        if (!stopRolling && rb.velocity.sqrMagnitude == 0f)
        {
            stopRolling= true;
            GetNumberOnTop();

        }
        //GetNumberOnTop();
    }

    private int GetNumberOnTop()
    {
        if (diceFaces == null) return -1;
        var topFace = 0;
        var lastPosition = diceFaces[0].position.y;

        for (int i = 0; i < diceFaces.Length;i ++)
        {
            if (diceFaces[i].position.y > lastPosition)
            {
                lastPosition = diceFaces[i].position.y;
                topFace=i;
            }
        }
        diceIndex = topFace + 1;
        Debug.Log("The No On Dice " + diceIndex);
        onDiceResult?.Invoke(diceIndex, topFace + 1);
        return topFace +1;
    }

    public void RollDice(float throwForce, float rollForce, int i)
    {
        diceIndex = i;
        var randValue = Random.Range(-1f, 1f);
        rb.AddForce(transform.forward * (throwForce + randValue), ForceMode.Impulse);

        var randX=Random.Range(0f,1f);
        var randY = Random.Range(0f, 1f);
        var randZ = Random.Range(0f, 1f);

        rb.AddTorque(new Vector3(randX,randY,randZ)*(rollForce+randValue),ForceMode.Impulse);

        DelayResult();

    }
    private async void DelayResult()
    {
        await Task.Delay(1000);
        delayFinish = true;
    }


}// end of Class
