using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using UnityEngine.UI;

public class GameControl: MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public TextMeshProUGUI ScoreText;
    public AudioClip flySound;
    public AudioClip scoreSound;
    public AudioClip deathSound;
 
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        PlaySound(flySound);
    }

    // Update is called once per frame
    void Update()
    {
       if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        ScoreText.text = "Score: " + score.ToString();

        PlaySound(scoreSound);
    }
    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;

        PlaySound(deathSound);
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
