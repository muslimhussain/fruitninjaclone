using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public int highscore;
    public Text scoreText;
    public Text highscoreText;
    [Header("Game Over Elements")]
    public GameObject gameOverPanel;

    [Header("Sounds")]
    public AudioClip[] sliceSounds;

    private AudioSource audioSource;

    private void Start()
    {
        Debug.Log("MAKE SURE YOU ADD SOUNDS IN THE GAME MANAGER");
        audioSource = GetComponent<AudioSource>();
        GetHighScore();
    }

    private void GetHighScore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore.ToString();
    }

    public void IncreaseScore(int addedPoints)
    {
        score += addedPoints;
        scoreText.text = score.ToString();

        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = "Best: " + score.ToString();
        }
    }

    public void OnBombHit()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void PlayRandomSliceSound()
    {
        AudioClip randomSound = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }

}
