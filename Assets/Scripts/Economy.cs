using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    [SerializeField] TMP_Text tmpCoinsDisplay;
    private int coins = 250;
    public Dictionary<string, int> defenderPrices = new Dictionary<string, int>(){
        {"cactus", 50},
        {"trophy", 75},
        {"tree", 100}
    };
    public int GetDefenderCost(string name){
        if (defenderPrices.ContainsKey(name)) {return defenderPrices[name];}
        return 0;
    }
    public bool BuyCactus(){
        if (coins >= defenderPrices["cactus"]) { coins -= defenderPrices["cactus"]; return true; }
        else { return false; }
    }
    void Start(){
        
    }
    void Update()
    {
        tmpCoinsDisplay.text = coins.ToString();
    }
}