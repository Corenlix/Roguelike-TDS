using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LevelGeneration;
using UnityEngine;

public class Pathfinder
{
    private const int STRAIGHT_MOVING_COST = 10;
    private const int DIAGONAL_MOVING_COST = 14;

    private CellType[,] level;
    private Node[,] nodes;
    private List<Node> openedNodes;
    private Vector2Int endPoint;

    public Pathfinder(CellType[,] level)
    {
        this.level = level;
    }
    public List<Vector2Int> FindPath(Vector2Int pointA, Vector2Int pointB)
    {
        GenerateNodesFromLevel();
        
        openedNodes = new List<Node>();
        var firstNode = OpenNode(pointA);
        firstNode.G = 0;
        
        endPoint = pointB;
        
        while (openedNodes.Count > 0)
        {
            var selectedNode = GetMinFNode();

            if (selectedNode.X == endPoint.x && selectedNode.Y == endPoint.y)
            {
                return selectedNode.GetPathToRootNode();
            }
            CheckNodesAroundNode(selectedNode);
            selectedNode.Available = false;
            openedNodes.Remove(selectedNode);

        }

        return null;
    }

    private Node GetMinFNode()
    {
        var minNode = openedNodes[0];
        foreach (var node in openedNodes)
        {
            if (node.F < minNode.F)
                minNode = node;
        }

        return minNode;
    }
    private Node OpenNode(Vector2Int position)
    {
        var node = nodes[position.x, position.y];
        if (node.F == Int32.MaxValue && node.Available)
        {
            openedNodes.Add(node);
            node.H = GetH(position);
        }
        return node;
    }

    private void CheckNodesAroundNode(Node node)
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;
                
                var checkX = node.X + i;
                var checkY = node.Y + j;

                //get out of bounds
                if (checkX < 0 || checkY < 0 || checkX >= level.GetLength(0) || checkY >= level.GetLength(1))
                    continue;
                
                //is diagonal path available
                if(nodes[checkX, node.Y].Wall || nodes[node.X, checkY].Wall)
                    continue;
                
                var checkNode = OpenNode(new Vector2Int(checkX, checkY));
                if (!checkNode.Available)
                    continue;

                int gCost = node.G;
                if (i == 0 || j == 0)
                    gCost += STRAIGHT_MOVING_COST;
                else gCost += DIAGONAL_MOVING_COST;

                if (checkNode.G > gCost)
                {
                    checkNode.G = gCost;
                    checkNode.previousNode = node;
                }
            }
        }
    }
    private int GetH(Vector2Int point)
    {
        var rectWidth = Mathf.Abs(point.x - endPoint.x);
        var rectHeight = Mathf.Abs(point.y - endPoint.y);
        var delta = Mathf.Abs(rectWidth - rectHeight);
        return DIAGONAL_MOVING_COST * Mathf.Min(rectWidth, rectHeight) + STRAIGHT_MOVING_COST * delta;
    }
    private void GenerateNodesFromLevel()
    {
        nodes = new Node[level.GetLength(0),level.GetLength(1)];
        for(int i = 0; i < level.GetLength(0); i++)
        {
            for (int j = 0; j < level.GetLength(1); j++)
            {
                var newNode = new Node(i, j);
                newNode.Wall = level[i, j] == CellType.Wall;
                newNode.Available = !newNode.Wall;
                nodes[i, j] = newNode;
            }
        }
    }
}
