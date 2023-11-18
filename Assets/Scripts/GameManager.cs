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
    private float timeToReturnPosition = 3;
    public int score = 0;
    bool isPause=true;
    // Start is called before the first frame update
    void Start()
    {
        puntaje.text = "Puntaje: 0";
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
        
    }
    public void Score()
    {
        score = score + 1;
        puntaje.text = "Puntaje: " + score;
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
}
