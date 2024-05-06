using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Map
{
    public enum nodeName
    {
        Nothing=0,
        Monster, //일반 전투
        Elite, //정예 전투
        Store, //상인
        Event, //랜덤 이벤트
        Treasure //불로소득
    }

    public class Map
    {
        public static GameObject[,] nodeMng = new GameObject[7, 15]; //노드 오브젝트배치를 위한 변수
        public static int[,] node = new int[7, 15]; //노드의 위치,종류를 알기위한 변수
        public static System.Random rnd = new System.Random(); //랜덤
        public static int[,] nodePath = new int[5, 15]; //각 노드의 길 [길의갯수,단계별 길의 좌표]

        //2차원 배열에 맵을 만드는 함수
        public static void mapMake()
        {
            while (true)
            {
                //배열 초기화
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        node[i, j] = 0;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        nodePath[i, j] = 0;
                    }
                }

                //맵 만들기
                for (int i = 0; i < 5; i++)
                {
                    int rand = rnd.Next(0, 7);
                    for (int j = 0; j < 15; j++)
                    {
                        int nextnode = rnd.Next(0, 3) - 1;
                        rand += nextnode;
                        if (rand < 0)
                        {
                            rand++;
                        }
                        else if (rand > 6)
                        {
                            rand--;
                        }
                        nodePath[i, j] = rand;
                        node[rand, j] = roomGet();
                    }
                }
                if (mapCheck() == 0)
                    break;
            }
        }

        //방에 길이 3개이상인지 검수
        public static int mapCheck()
        {
            for (int z = 0; z < 15; z++)
            {
                int level = 0;
                for (int x = 0; x < 7; x++)
                {
                    if (node[x, z] == 0)
                    {
                        level++;
                    }
                }
                if (level > 4)
                    return 1;
            }
            return 0;
        }

        // 방의 종류를 정하는 함수
        public static int roomGet()
        {

            int room = (int)nodeName.Nothing;
            int rand = rnd.Next(0, 100);
            if (rand < 60)
                room = (int)nodeName.Monster;
            else if (rand >= 60 && rand < 70)
                room = (int)nodeName.Elite;
            else if (rand >= 70 && rand < 80)
                room = (int)nodeName.Store;
            else if (rand >= 80 && rand < 90)
                room = (int)nodeName.Treasure;
            else if (rand >= 90 && rand < 100)
                room = (int)nodeName.Event;
            return room;
        } 
    }

}