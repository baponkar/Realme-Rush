using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;

    [SerializeField] TMP_Text goldBalanceText;

    public int CurrentBalance { get { return currentBalance; } }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void WithDraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);

        if(currentBalance < 0)
        {
            //to loose
            ReloadScene();
        }
    }

    void Awake()
    {
        currentBalance = startingBalance;
        
    }

    void UpdateDisplay()
    {
        goldBalanceText.text = "Gold : " + currentBalance.ToString();
    }

    void Update()
    {
        UpdateDisplay();
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
