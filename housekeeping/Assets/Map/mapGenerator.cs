using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



namespace Map
{
    public class mapGenerator : MonoBehaviour
    {
        GameObject nodePrefab = null; //맵 노드 프리펩
        public static List<LineRenderer> nodeLine = new List<LineRenderer>();
        LineRenderer linePrefab = null;
        int nx;
        float ny;
        int nr;

        void Start()
        {
            nodePrefab = Resources.Load("mapRes/nodeBtn") as GameObject;
            linePrefab = Resources.Load("mapRes/nodeline").GetComponent<LineRenderer>();
            Debug.Log("1");
        }

        public void stageStart()
        {
            //초기화
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (Map.nodeMng[i, j] != null)
                        Destroy(Map.nodeMng[i, j]);
                    Map.nodeMng[i, j] = null;
                }
            }
            for (int i = 0; i < nodeLine.Count; i++)
                Destroy(nodeLine[i]);
            nodeLine.Clear();

            Map.mapMake(); //맵 생성
            nodeGenerator();
            startSet();
        }

        //갈수있는 노드만 활성화
        void startSet()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (j == 0)
                    {
                        if (Map.nodeMng[i, j] != null)
                        {
                            Map.nodeMng[i, j].GetComponent<Button>().interactable = true;
                        }
                    }
                    else
                    {
                        if (Map.nodeMng[i, j] != null)
                        {
                            Map.nodeMng[i, j].GetComponent<Button>().interactable = false;
                        }
                    }
                }
            }
        }

        //노드 생성 함수
        public void nodeGenerator() 
        {
            Map.mapMake(); //맵 생성
            //DontDestroyOnLoad(GameObject.Find("mapUI"));
            // 노드를 배치하는 파트
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (Map.node[i, j] != 0)
                    {
                        nodeMake(i, j);
                    }
                }
            }
            lineGenerator();
        }

        //노드를 맵에 생성시키는 함수
        public void nodeMake(int x, int y)
        {
            nr = Map.rnd.Next(0, 50) - 25;
            nx = (y * 85 - 600) + nr;
            nr = Map.rnd.Next(0, 100) - 50;
            ny = (x * 100 - 300) + (y - 7) * (y - 7) * (3 - x) + y * (15 - y) * nr * (float)0.01;
            /*y값은 j값(x열)의 2차함수값과 i값(y열)의 1차함수의 곱으로
              맵씬의 행성 표면에 맞게 늘리고 줄인다 
             nr변수에 랜덤값을 받아 좌표를 조금 흩트려준다*/

            //mapUI 캔버스를 부모로 생성
            Map.nodeMng[x, y] = Instantiate(nodePrefab, GameObject.Find("mapUI").transform, false);
            Map.nodeMng[x, y].transform.localPosition = new Vector2(nx, ny);
            Map.nodeMng[x, y].GetComponent<nodePoint>().x = x;
            Map.nodeMng[x, y].GetComponent<nodePoint>().y = y;
        }

        //노드 사이에 선을 잇는 함수
        public void lineGenerator()
        {
            int i = 0;
            while (i < 5)
            {
                for(int j = 0; j < 14; j++)
                {
                    lineMake(Map.nodePath[i, j], j, Map.nodePath[i, j + 1], j + 1);
                }
                i++;
            }
        }

        //선을 그려주는 함수
        public void lineMake(int x1, int y1, int x2, int y2)
        {
            nodeLine.Add(Instantiate(linePrefab, GameObject.Find("mapUI").transform, false));
            nodeLine[nodeLine.Count - 1].
                SetPosition(0, Map.nodeMng[x1, y1].GetComponent<Transform>().position);
            nodeLine[nodeLine.Count - 1].
                SetPosition(1, Map.nodeMng[x2, y2].GetComponent<Transform>().position);
        }

    }

}