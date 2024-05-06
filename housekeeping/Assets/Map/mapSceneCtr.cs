using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Map
{
    public class mapSceneCtr : MonoBehaviour
    {
        public GameObject sc;
        int start = 0;

        /*void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        */
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if(start == 0)
            {
                sc.GetComponent<mapGenerator>().stageStart();
                start++;
            }
            else
                sc.GetComponent<mapGenerator>().nodeGenerator();

        }

        /*void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }*/

        void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void Update()
        {

        }
    }


}
