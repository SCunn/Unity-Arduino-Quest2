// Code sourced from Naoise Collins's Game manager tutorial
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagers { 
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public int score;

        [SerializeField] private UIManager uiManager;
        
        private bool isPaused = false;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if(Instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }

        private void Start()
        {
            ResetScore();
        }

        void Update()
        {   // This will update UIManager and add score to UI
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AddScore(10);
            }
            // This will update UIManager to Pause game
            if (Input.GetKeyDown(KeyCode.P))
            {
                TogglePause();
            }
            // This will update UIManager to Quit game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitGame();
            }

        }

        public void AddScore(int points)
        {
            score += points;
            uiManager.UpdateScoreDisplay(score);
            //AudioManager.Instance.PlaySoundEffect("PointScored");
        }

        public void ResetScore()
        {
            score = 0;
            uiManager.UpdateScoreDisplay(score);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void TogglePause()
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
                AudioManager.Instance.PlaySoundEffect("Pause");
            }
            else
            {
                Time.timeScale = 1;
                AudioManager.Instance.PlaySoundEffect("Unpause");
            }
            uiManager.TogglePauseMenu(isPaused);
        }
    }
}