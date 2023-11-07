using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text diceText;
    

    private void OnEnable()
    {
        DiceManager.onDiceResult += SetText;
        //DiceManager.onDiceResult += InstanicateBtn;
            
    }
    private void OnDisable()
    {
        DiceManager.onDiceResult -= SetText;

    }
    private void SetText(int diceIndex,int diceResult)
    {
       
        diceText.SetText($"Dice No: {diceResult}");
       

    }



   
}// end of class
