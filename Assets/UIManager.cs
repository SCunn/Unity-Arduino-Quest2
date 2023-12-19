// Code sourced from Naoise Collins Game Manager Tutorial

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameManagers { 
    public class UIManager : MonoBehaviour
    {
        // Variables //////////////
        public TMP_Text scoreText;

        public GameObject pauseMenu;

        public void UpdateScoreDisplay(int score)
        {
            scoreText.text = "Score: " + score;
        }

        public void TogglePauseMenu(bool isPaused)
        {
            pauseMenu.SetActive(isPaused);
        }
    }
}
