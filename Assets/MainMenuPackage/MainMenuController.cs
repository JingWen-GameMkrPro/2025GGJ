using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject ButtonGroup;

    [HideInInspector]
    public List<Button> Buttons = new();

    [HideInInspector]
    public int SelectButtonIndex = 0;

    private void Start()
    {
        //Auto Get All Buttons
        getAllButtons();
    }

    private void Update()
    {
        updateSelectButtonIndex();
        Buttons[SelectButtonIndex].Select();
    }

    void getAllButtons()
    {
        Buttons.AddRange(ButtonGroup.GetComponentsInChildren<Button>(true));
    }

    void updateSelectButtonIndex()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            SelectButtonIndex = (SelectButtonIndex-1) < 0 ? SelectButtonIndex /*Loop: Buttons.Count - 1*/ : --SelectButtonIndex;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            SelectButtonIndex = (SelectButtonIndex+1) >= Buttons.Count ? SelectButtonIndex /*Loop: 0*/ : ++SelectButtonIndex;
        }
    }

    //自動查詢旗下按鈕

    public void OnButtonClick_Play()
    {
        Debug.Log("OnButtonClick_Play");
    }
    public void OnButtonClick_Exit()
    {
        Debug.Log("OnButtonClick_Exit");
    }
}
