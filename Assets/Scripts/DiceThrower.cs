using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DiceThrower : MonoBehaviour
{
    public DiceManager diceThrow;
    public int noOfDice = 1;
    public float throwForce = 5f;
    public float rollForce = 10f;
    public List<GameObject> spawnList = new List<GameObject>();

    public Level1Manager level1Manager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowDice();
        }
    }
    private async void ThrowDice()
    {
        if(diceThrow==null)  return;

        foreach (var dice in spawnList)
        {
            //spawnList.Clear();
            Destroy(dice);
        }
        for (int i = 0; i < noOfDice; i++)
        {
            DiceManager dice = Instantiate(diceThrow, transform.position, transform.rotation);
            spawnList.Add(dice.gameObject);
            dice.RollDice(throwForce, rollForce, i);
            await Task.Yield();
        }
    }
}//End of class
