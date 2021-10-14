using System.Collections;

public class HUIWindowRoot : HUIBase {

    private IEnumerator Start()
    {
        yield return -1;
        ShowDemoWindow();
    }



    void ShowDemoWindow()
    {
        HUIManager.Instance.OpenUI("UIWindow_Demo");
    }




}
