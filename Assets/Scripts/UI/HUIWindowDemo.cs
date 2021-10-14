using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUIWindowDemo : HUIBase
{
    [SerializeField]
    private InputField userName;
    [SerializeField]
    private InputField userPwd;

    public void Sure()
    {
        Debug.Log("用户名 :" +  userName.text + " 请求登录");
    }
}
