using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] Obstaculos;
    [SerializeField] GameObject[] PuntosSpawns;
    [SerializeField] TMP_Text puntaje;
    public int numberRandomObs;
    public int numberRandomPt;
    private float timeToReset = 0;
    public float timeToReturnPosition = 3;
    public int score = 0;
    bool isPause=true;
    // Start is called before the first frame update
    void Start()
    {
        puntaje.text = "Score: 0";
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeToReset += Time.deltaTime;
        if (timeToReset >= timeToReturnPosition)
        {
            NumberRandomsObstaculos();
            NumberRandomsPuntos();
            Instantiate(Obstaculos[numberRandomObs],PuntosSpawns[numberRandomPt].transform.position,Quaternion.identity);
            timeToReset = 0;
        }
        CheckScore();
        
    }
    public void Score()
    {
        score = score + 1;
        puntaje.text = "Score: " + score;
    }
    void NumberRandomsObstaculos()
    {
        numberRandomObs = Random.Range(0, Obstaculos.Length);
    }
    void NumberRandomsPuntos()
    {
        numberRandomPt = Random.Range(0, Obstaculos.Length);
    }
    public void ResetScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Pause()
    {
        if (isPause == true)
        {
            Time.timeScale = 0;
            isPause = false;
        }else if(isPause == false)
        {
            Time.timeScale = 1;
            isPause =true;
        }
    }
    void CheckScore()
    {
        if(score == 15)
        {
            timeToReturnPosition = 2.5f;
        }
        if(score == 30)
        {
            timeToReturnPosition = 2;
        }
        if(score == 45)
        {
            timeToReturnPosition = 1.5f;
        }
        if(score == 60)
        {
            timeToReturnPosition = 1;
        }
    }
}
