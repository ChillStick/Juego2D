using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuCode : MonoBehaviour
{
    // Start is called before the first frame update
    public void GotoGame()
    {
        SceneManager.LoadScene("Lobby");
    }
}
