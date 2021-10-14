using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;           //绘制射线

    private Transform m_transfrom;

    private Transform m_point;

    public  LineRenderer m_LineRenderer;      //Line Renderer组件

    public AudioSource m_AudioSource;      ///声音播放组件
                                           
    public static int score;

    public UIFunction function;

    public GameObject create;

    public Image imgPass;
    public Image imgNotPass;

	void Start () {
		
        m_transfrom = gameObject.GetComponent<Transform>();
        m_point = m_transfrom.Find("point");

	}

	void Update () {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) 
        {         
            //控制手臂跟随鼠标移动
            m_transfrom.LookAt(hit.point);

            //绘制测试线
            Debug.DrawLine(m_point.position, hit.point, Color.red);

            //绘制激光效果
            m_LineRenderer.SetPosition(0, m_point.position);
            m_LineRenderer.SetPosition(1, hit.point);


            if (hit.collider.tag == "FeiPan" && Input.GetMouseButtonDown(0)) 
            {
                //播放声音
                m_AudioSource.Play();

                //通过子物体来查找该子物体的父物体
                Transform parent = hit.collider.gameObject.GetComponent<Transform>().parent;
                 
                //通过父物体查找所有子物体
                Transform[] FeiPan = parent.GetComponentsInChildren<Transform>();

                for (int i = 0; i < FeiPan.Length; i++) 
                {
                    //飞盘击碎
                    FeiPan[i].gameObject.AddComponent<Rigidbody>();
                    //Debug.Log("111");
                }
                //销毁击碎的飞盘
                GameObject.Destroy(parent.gameObject, 2.0f);

                score++;
                function._score.text = score.ToString();

            }
            if (score >= UIFunction.targetscore)
            {
                create.SetActive(false);
                imgPass.gameObject.SetActive(true);
                score = 0;
                function._score.text = score.ToString();
            }
            if (function._up.fillAmount == 0) 
            {
                if (score < UIFunction.targetscore) 
                {
                    create.SetActive(false);
                    imgNotPass.gameObject.SetActive(true);
                    score = 0;
                    function._score.text = score.ToString();
                }
            }
        }
        
	}
}
