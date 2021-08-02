using System.Collections.Generic;
using UnityEngine;

namespace LevelGeneration
{
    internal class Corridor
    {
        public Corridor(List<RectInt> rects)
        {
            Rects = rects;
        }

        public readonly List<RectInt> Rects;
        public int GetSize() 
        {
            int size = 0;
            foreach(var rect in Rects) 
            {
                size += rect.size.sqrMagnitude;
            }
            return size;
        }
    }
}
