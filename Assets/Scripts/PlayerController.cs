using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Space]
    [Header("Game Board")]
    [SerializeField] List<GameObject> defenders;
    [SerializeField] Canvas gameBoard;
    private GameObject currentSquare;
    private GraphicRaycaster gameBoardRaycaster;
    private bool boardActive = true;
    [Space]
    [Header("Defender Select")]
    [SerializeField] Canvas defenderSelectMenu;
    [SerializeField] TMP_Text tmpCactusPrice;
    private GraphicRaycaster defenderSelectRaycaster;
    [Space]
    [Header("Utilities")]
    private GameSys sys;
    private Economy econ;
    private PointerEventData clickData;
    private List<RaycastResult> clickResults;
    [Space]
    [Header("VFX")]
    [SerializeField] GameObject buttonPressedVFX;
    private float buttonVfxDelay = 1f;
    
    private void DeselectAll(){
        boardActive = true;
        defenderSelectMenu.gameObject.SetActive(false);
    }
    private void MenuDefenderSelect(GameObject square){
        boardActive = false;
        defenderSelectMenu.gameObject.transform.position = square.transform.position;
        currentSquare = square;
        defenderSelectMenu.gameObject.SetActive(true);
    }
    private void UpdateDefenderPrices(){
        tmpCactusPrice.text = econ.GetDefenderCost("cactus").ToString();
    }
    public void SpawnCactus(){
        if (econ.BuyCactus()){
            sys.SpawnVFX(buttonPressedVFX, currentSquare.transform, buttonVfxDelay);
            sys.SpawnDefender(defenders[0], currentSquare);
            DeselectAll();
        } else {
            // play 'nix sound
            // visual Q on UI
        }
    }
    void OnClick(){
        clickData.position = Mouse.current.position.ReadValue();
        clickResults.Clear();
        if(defenderSelectMenu.gameObject.activeSelf){
            defenderSelectRaycaster.Raycast(clickData, clickResults);
            if(clickResults.Count > 0){clickResults[0].gameObject.GetComponent<Button>()?.onClick.Invoke(); return;}
        }
        gameBoardRaycaster.Raycast(clickData, clickResults);
        if(clickResults.Count == 0){DeselectAll(); return;}
        foreach (RaycastResult result in clickResults){
            GameObject uiElement = result.gameObject;
            if (!uiElement.GetComponentInChildren<Defender>()){
                Debug.Log(uiElement.name + " - Open");
                MenuDefenderSelect(uiElement);
            } else {
                Debug.Log(uiElement.name + " - Occupied");
                // when placing, play the 'nix' sound
                // normal play, Prompt to sell / replace / upgrade
                // MenuDefenderSwap();
            }
        }
    }
    private void Awake(){
        sys = GameObject.Find("GameSys").GetComponent<GameSys>();
        econ = sys.gameObject.GetComponent<Economy>();
        gameBoardRaycaster = gameBoard.GetComponent<GraphicRaycaster>();
        defenderSelectRaycaster = defenderSelectMenu.GetComponent<GraphicRaycaster>();
        clickData = new PointerEventData(EventSystem.current);
        clickResults = new List<RaycastResult>();
    }
    private void Start() {
        UpdateDefenderPrices();
    }
}
