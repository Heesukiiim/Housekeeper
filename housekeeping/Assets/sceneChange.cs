using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Map;


public class sceneChange : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene("mapScene");
    }

    public void Change2()
    {
        mapManage.nodeProgre();
        SceneManager.LoadScene("gameScene");
    }
}
