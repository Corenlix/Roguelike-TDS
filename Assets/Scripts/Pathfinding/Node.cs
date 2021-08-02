using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    internal class Node
    {
        public int F => G + H;
        public int G = int.MaxValue, H;

        public int X { get; }

        public int Y { get; }

        public Node(int x, int y, bool wall)
        {
            X = x;
            Y = y;
            Wall = wall;
        }

        public Node PreviousNode;

        public void ResetNode()
        {
            Closed = false;
            G = int.MaxValue;
            H = 0;
            PreviousNode = null;
        }
        public List<Vector2Int> GetPathToRootNode()
        {
            var path = new List<Vector2Int>();
            path.Add(new Vector2Int(X, Y));

            if (PreviousNode != null)
                path.AddRange(PreviousNode.GetPathToRootNode());
        
            return path;
        }

        public bool Closed, Wall;

    }
}
