using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeiPanManager : MonoBehaviour {

    public GameObject FeiPan;

    private Transform m_transform;

	void Start () {

        InvokeRepeating("CreateFeiPan", 2.0f, 2.0f);

        GameObject FeiPan = gameObject.GetComponent<GameObject>();

        m_transform = transform.GetComponent<Transform>();
	}
	

	void Update () {
		
	}

    void CreateFeiPan() 
    {
        for (int i = 1; i < 6; i++) 
        {
            //飞盘的位置
            Vector3 position = new Vector3(Random.Range(-3.0f, 2.0f), Random.Range(0.5f, 5.0f), Random.Range(0, 10.0f));

            //实例化飞盘
            GameObject go = GameObject.Instantiate(FeiPan, position, Quaternion.identity);

            //给生成的飞盘设置一个父物体
            go.GetComponent<Transform>().SetParent(m_transform);
        }
    }
}
