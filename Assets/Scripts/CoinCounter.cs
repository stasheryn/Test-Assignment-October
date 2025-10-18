using System;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private int numberOfCoins;
    [SerializeField] private TextMeshProUGUI textMesh;

    public void AddCoins(int coinsValue)
    {
        numberOfCoins += coinsValue;
        // update ui text
        textMesh.text = $"Number of coins: {numberOfCoins}";
    }

    private void Start()
    {
        //AddCoins(10);
    }
    // private void UpdateUI()
    // {
    //     //textMesh.text = "Coins: " + numberOfCoins;
    //     textMesh.text = $"Number of coins: {numberOfCoins}";
    // }
}
