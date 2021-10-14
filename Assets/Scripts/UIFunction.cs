using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIFunction : MonoBehaviour {

    public static int targetscore;
    public Text _targetScore;
    public Text _score;
    public Image _up;
    public Text m_text;

   

    void Start()
    {
        targetscore = Random.Range(20, 40);
        _targetScore.text = targetscore.ToString();
    }
    void Update() 
    {
        _up.fillAmount -= Time.deltaTime * 0.03f;
        m_text.text = ((int)(_up.fillAmount*100)).ToString()+"%";
    }

    public void OnCLickNext() 
    {
        SceneManager.LoadScene(0);
    }
    public void OnClickQuit() 
    {
        Application.Quit();
    }
    public void OnCLickReStart() 
    {
        SceneManager.LoadScene(1);
    }

}
