using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> briks = new List<GameObject>();
    public List<GameObject> leve1Tiles = new List<GameObject>();
    public List<GameObject> Level2Tiles = new List<GameObject>();
    public List<Button> buttons = new List<Button>();

    public int sum = 0;
    public int dicRes = 0;
    public int levelIndex = 1;
    public TMP_Text gameOverText;

    private void OnEnable()
    {
        DiceManager.onDiceResult += TotalResult;
    }
    private void OnDisable()
    {
        DiceManager.onDiceResult -= TotalResult;

    }
    private void Awake()
    {
        if(levelIndex== 1 )
        {
            for (int i = 0; i < leve1Tiles.Count-1; i++)
            {
                briks[i] = leve1Tiles[i];

            }
        }
        if(levelIndex== 2 )
        {
            for (int i = 0; i < Level2Tiles.Count; i++)
            {
                briks[i] = leve1Tiles[i];
            }
        }
    }
    private void TotalResult(int diceIndex, int diceResult)
    {
        if (diceIndex == 0)
        {
            dicRes += diceResult;
        }
        else
        {
            dicRes += diceResult;
            ShowBtnS(dicRes);
        }

    }

    private void ShowBtnS(int temp)
    {


        if (briks[temp - 1].activeInHierarchy)
        {
            ShowPairBtn(temp);
        }
        else
        {
            gameOverText.gameObject.SetActive(true);
        }
    }
    private void ShowPairBtn(int tSum)
    {
        for (int i = 0; i < briks.Count; i++)
        {
            for (int j = i + 1; j < briks.Count; j++)
            {
                if (i + j + 1 == tSum && i == j)
                {
                    if (briks[i].activeInHierarchy && briks[j].activeInHierarchy)
                    {
                        buttons[i].gameObject.SetActive(true);
                        buttons[j].gameObject.SetActive(true);
                        buttons[tSum - 1].gameObject.SetActive(true);

                    }
                }
                else
                {
                    buttons[tSum - 1].gameObject.SetActive(true);
                }
            }
        }
    }

    public void OnClickBtn(int i)
    {
        briks[i - 1].SetActive(false);
        sum += i;
        SumUpBuutons();
        Destroy(buttons[i - 1].gameObject);
        buttons[i - 1] = null;
    }
    void SumUpBuutons()
    {
        if (sum == dicRes)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i] != null && buttons[i].gameObject.activeInHierarchy)
                    buttons[i].gameObject.SetActive(false);
            }
            sum = 0;
        }
    }
}// End of Class
