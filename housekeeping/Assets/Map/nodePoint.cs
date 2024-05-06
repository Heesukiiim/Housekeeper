using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class nodePoint : mapGenerator
    {
        public int x;
        public int y;
        public nodePoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
    }
}