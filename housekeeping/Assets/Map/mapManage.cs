using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Map
{
    public class mapManage : MonoBehaviour
    {
        public static int roomType = 0;

        //��弱��
        public static void nodeProgre()
        {
            GameObject clicked = EventSystem.current.currentSelectedGameObject;
            int x = clicked.GetComponent<nodePoint>().x;
            int y = clicked.GetComponent<nodePoint>().y;

            //������ ���� ��� ��Ȱ��ȭ
            for (int i = 0; i < 7; i++)
            {
                roomType = Map.node[i, y];
                if (Map.nodeMng[i, y] != null)
                    Map.nodeMng[i, y].GetComponent<Button>().interactable = false;
            }
            //���� �� ��� Ȱ��ȭ
            for(int i = 0;i < 5; i++)
            {
                if (x == Map.nodePath[i, y])
                    Map.nodeMng[Map.nodePath[i, y + 1], y+1].GetComponent<Button>().interactable = true;
            }
        }

    }
}
