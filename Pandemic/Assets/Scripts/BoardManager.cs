using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    
    public GameObject[] playerRoleArray; // Array to store player role GameObjects
    public Text text;

    void Start()
    {
        // placeholder for all playerroles as gameObjects
        playerRoleArray = GameObject.FindGameObjectsWithTag("PlayerRole");
        UpdateText();
    }

    //placeholder to display commencement prompt and playerRoles in UI text at beginning of the gameplay scene
    void UpdateText()
    {
        string playerNames = "";
        foreach (GameObject playerRole in playerRoleArray)
        {
            playerNames += playerRole.name + " ";
        }

        text.text = "Press 'Space' to start. Players: " + playerNames;
    }

}
