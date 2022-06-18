using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;
    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    private int _lives = 1;
    public int maxLives = 3;

    public int lives
    {
        get { return _lives; }
        set
        {
            if (_lives > value)
            {
                sfxManager.Play(dieSound, soundFXGroup);
                playerInstance.transform.position = currentLevel.spawnPoint.transform.position;
            }

            _lives = value;

            if (_lives > maxLives)
                _lives = maxLives;

            onLifeValueChanged.Invoke(value);

            if (_lives < 1)
                GameOver();

            Debug.Log("Lives Set To: " + lives.ToString());
        }
    }

    public PlayerController playerPrefab;

    public ObjectSounds sfxManager;

    public AudioClip jumpSound;
    public AudioClip dieSound;
    public AudioClip killSound;
    public AudioClip buttonFX;
    public AudioClip pauseSound;
    public AudioClip enemyHit;
    public AudioMixerGroup soundFXGroup;

    [HideInInspector] public PlayerController playerInstance;
    [HideInInspector] public Level currentLevel;
    [HideInInspector] public UnityEvent<int> onLifeValueChanged;

    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (SceneManager.GetActiveScene().name == "Start")
        //        SceneManager.LoadScene("Level");
        //    else if (SceneManager.GetActiveScene().name == "GameOver")
        //        SceneManager.LoadScene("Start");
        //}
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        Debug.Log("GO TO GAME OVER SCREEN");
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        playerInstance = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
    }
}
