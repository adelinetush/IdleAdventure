using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
    float cuttingSpeed, minSpeed, speedMultiplier;
    int woodcutters, archaeologists;
    int totalCoins, totalGems;
    int treeReward, gemReward;
    float gemFindTime;

    int speedCost, cutterCost, historianCost;

    int totalTreesCut;

    Button cuttersButton, speedButton, researcherButton;

    public TextMeshProUGUI totalGemsText, totalCoinText, woodCuttersText, cuttingSpeedText, historiansText;
    public TextMeshProUGUI speedCostText, cutterCostText, historianCostText;

    private float nextTreeCutTime = 0.0f;
    private float nextGemFound = 45.0f;


    private void Start()
    {
        cuttingSpeed = 1;
        woodcutters = 1;
        archaeologists = 1;

        gemFindTime = 60;

        totalCoins = 0;
        totalGems = 0;

        speedCost = 20;
        cutterCost = 40;
        historianCost = 200;

        cuttersButton = GameObject.Find("Cutter").GetComponent<Button>();
        speedButton = GameObject.Find("Speed").GetComponent<Button>();
        researcherButton = GameObject.Find("Historian").GetComponent<Button>();
    }

    private void Update()
    {
        totalCoinText.text = totalCoins.ToString();
        totalGemsText.text = totalGems.ToString();
        woodCuttersText.text = woodcutters.ToString();
        cuttingSpeedText.text = cuttingSpeed.ToString("0.##");
        historiansText.text = archaeologists.ToString();
        speedCostText.text = speedCost.ToString();
        cutterCostText.text = cutterCost.ToString();
        historianCostText.text = historianCost.ToString();

        if (cutterCost > totalCoins)
        {
            cuttersButton.interactable = false;
        }
        else if (woodcutters >= 10)
        {
            cuttersButton.interactable = false;
        }
        else
        {
            cuttersButton.interactable = true;
        }

        if (speedCost > totalCoins)
        {
            speedButton.interactable = false;
        }
        else if (cuttingSpeed <= 0.1f)
        {
            speedButton.interactable = false;
        }
        else
        {
            speedButton.interactable = true;
        }

        if (historianCost > totalCoins)
        {
            researcherButton.interactable = false;
        }
        else
        {
            researcherButton.interactable = true;
        }

        if (Time.time > nextTreeCutTime)
        {
            nextTreeCutTime += cuttingSpeed / woodcutters;
            CutTrees();
        }

        if (Time.time > nextGemFound)
        {
            nextGemFound += gemFindTime / archaeologists;
            FindGems();
        }
    }

    void CutTrees()
    {
        totalCoins += 1;
        //totalTreesCut += 1;
    }

    void FindGems()
    {
        totalCoins += 20;
        totalGems += 1;
    }

    public void BuyCutter()
    {
        if (cutterCost < totalCoins)
        {
            woodcutters += 1;
            totalCoins -= cutterCost;
            cutterCost = (int)(cutterCost * 2.5f);
        }
    }

    public void BuySpeed()
    {
        if (speedCost < totalCoins)
        {
            if (cuttingSpeed > 0.1f)
            {
                cuttingSpeed -= 0.1f;
                totalCoins -= speedCost;
                speedCost = (int)(speedCost * 2.0f);
            }

        }
    }

    public void BuyArchaeologist()
    {
        if (historianCost < totalCoins)
        {
            archaeologists += 1;
            totalCoins -= historianCost;
            historianCost = (int)(historianCost * 3.5f);
        }
    }

}
