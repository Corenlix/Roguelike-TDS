using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int F => G + H;
    public int G = Int32.MaxValue, H;

    public int X { get; }

    public int Y { get; }

    public Node(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public Node previousNode;

    public List<Vector2Int> GetPathToRootNode()
    {
        var path = new List<Vector2Int>();
        path.Add(new Vector2Int(X, Y));

        if (previousNode != null)
            path.AddRange(previousNode.GetPathToRootNode());
        
        return path;
    }

    public bool Available, Wall;

}
