using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOneCode : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Game1");
    }
}
