using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.Events;

public class Level1Manager : MonoBehaviour
{
    public List<GameObject> briks=new List<GameObject>();
    public List<Button> buttons = new List<Button>();

    public int sum = 0;
    public int dicRes = -1;
    public TMP_Text gameOverText;
    //public static UnityAction<int, int> onButtonClick;

    private void OnEnable()
    {
        DiceManager.onDiceResult += ShowButton;
    }
    private void OnDisable()
    {
        DiceManager.onDiceResult -= ShowButton;

    }
    private void Update()
    {
        //if (sum == dicRes)
        //{
        //    Debug.Log("sum is equal to result");
        //    for (int i = 0; i < buttons.Count; i++)
        //    {
        //        if (buttons[i] != null && buttons[i].gameObject.activeInHierarchy)
        //            buttons[i].gameObject.SetActive(false);
        //    }
        //    sum = 0;
        //}
    }

    private void ShowButton(int diceIndex, int diceResult)
    {
        dicRes= diceResult;

    //these if statements can show buttons acording to dice result
        if(diceResult==1) { BrikOne(diceResult); }
        if(diceResult==2) { BrickTwo(diceResult); }
        if(diceResult==3) { BrikThree(diceResult); }
        if(diceResult==4) { BrickFour(diceResult); }
        if(diceResult==5) { BrikFive(diceResult); }
        if(diceResult==6) { BrikSix(diceResult); }
        


    }
    // If dice result is one this function is executed 
    void BrikOne(int res)
    {
        if (briks[res-1].activeInHierarchy)
        {
            buttons[res - 1].gameObject.SetActive(true);
        }
        else
        {
            gameOverText.gameObject.SetActive(true);
            //Debug.Log("Game Over");
        }
    }
    // If dice result is 2 this function is executed 
    void BrickTwo(int res)
    {
        if (briks[res-1].activeInHierarchy)
        {
            buttons[res - 1].gameObject.SetActive(true);
        }
        else
        {
            gameOverText.gameObject.SetActive(true);
        }
    }
    // If dice result is 3 this function is executed 
    void BrikThree(int res)
    {
        if (briks[res - 1].activeInHierarchy)
        {
            //show button 3
            buttons[res - 1].gameObject.SetActive(true);
            //show button 1 and 2
            if (briks[res-2].activeInHierarchy && briks[res - 3].activeInHierarchy)
            {
                buttons[res - 2].gameObject.SetActive(true);
                buttons[res - 3].gameObject.SetActive(true);
            }
        }
        else
        {
            gameOverText.gameObject.SetActive(true);
        }


    }
    // If dice result is 4 this function is executed 
    void BrickFour(int res)
    {
        if (briks[res - 1].activeInHierarchy)
        {
            //show button 4
            buttons[res - 1].gameObject.SetActive(true);
            //show button 1 and 3
            if (briks[res-2].activeInHierarchy && briks[res - 4].activeInHierarchy)
            {
                buttons[res - 2].gameObject.SetActive(true);
                buttons[res - 4].gameObject.SetActive(true);
            }
            
        }
        else
        {
            gameOverText.gameObject.SetActive(true);
        }
    }
    // If dice result is 5 this function is executed 
    void BrikFive(int res)
    {
        if (briks[res - 1].activeInHierarchy)
        {
            //show button 5
            buttons[res - 1].gameObject.SetActive(true);
            //show button 1 and 4
            if (briks[res-2].activeInHierarchy && briks[res - 5].activeInHierarchy)
            {
                buttons[res - 2].gameObject.SetActive(true);
                buttons[res - 5].gameObject.SetActive(true);

            }
            // show button 2 and 3
            if (briks[res - 3].activeInHierarchy && briks[res - 4].activeInHierarchy)
            {
                buttons[res - 3].gameObject.SetActive(true);
                buttons[res - 4].gameObject.SetActive(true);
            }
        }
        else
        {
            gameOverText.gameObject.SetActive(true);
        }

    }
    // If dice result is 6 this function is executed 
    void BrikSix(int res)
    {
        if (briks[res - 1].activeInHierarchy)
        {
            // show button 6
            buttons[res - 1].gameObject.SetActive(true);
            //show button 1 and 5
            if (briks[res - 2].activeInHierarchy && briks[res - 6].activeInHierarchy)
            {
                buttons[res - 2].gameObject.SetActive(true);
                buttons[res - 6].gameObject.SetActive(true);
            }
            // show button 2 and 4
            if (briks[res - 3].activeInHierarchy && briks[res-5].activeInHierarchy)
            {
                buttons[res - 3].gameObject.SetActive(true);
                buttons[res - 5].gameObject.SetActive(true);
            }
            // show butoons 1 2 and 3
            if (briks[res-4].activeInHierarchy && briks[res-5].activeInHierarchy&& briks[res - 6].activeInHierarchy)
            {
                buttons[res - 4].gameObject.SetActive(true);
                buttons[res - 5].gameObject.SetActive(true);
                buttons[res - 6].gameObject.SetActive(true);
            }
        }
        else
        {
            gameOverText.gameObject.SetActive(true);
        }
    }
    void SumUpBuutons()
    {
        if (sum == dicRes)
        {
            Debug.Log("sum is equal to result");
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i] != null && buttons[i].gameObject.activeInHierarchy)
                    buttons[i].gameObject.SetActive(false);
            }
            sum = 0;
        }
    }
    public void OnClickBtn(int i)
    {
        briks[i-1].SetActive(false);
        sum += i;
        SumUpBuutons();
        Destroy(buttons[i-1].gameObject);
        buttons[i - 1] = null;
    }
}//End of Level 1 Manager Class
