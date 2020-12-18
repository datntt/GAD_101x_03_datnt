using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1;
    }
}
