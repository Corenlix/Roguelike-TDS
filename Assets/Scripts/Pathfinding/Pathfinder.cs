using System;
using System.Collections.Generic;
using LevelGeneration;
using UnityEngine;

namespace Pathfinding
{
    public class Pathfinder
    {
        private const int StraightMovingCost = 10;
        private const int DiagonalMovingCost = 14;

        private readonly Level level;
        private Node[,] nodes;
        private List<Node> openedNodes;
        private Vector2Int endPoint;
        
        public Pathfinder(Level level)
        {
            this.level = level;
            GenerateNodesFromLevel();
        }
        public List<Vector2Int> FindPath(Vector2 pointA, Vector2 pointB)
        {
            if (pointA.x < 0 || pointA.x >= nodes.GetLength(0) || pointB.x < 0 || pointB.y >= nodes.GetLength(1))
                return null;
            
            foreach (var node in nodes)
            {
                node.ResetNode();
            }
        
            openedNodes = new List<Node>();
            var firstNode = OpenNode(new Vector2Int((int)(pointB.x), (int)(pointB.y)));
            firstNode.G = 0;
        
            endPoint = new Vector2Int(Mathf.RoundToInt(pointA.x), Mathf.RoundToInt(pointA.y));
        
            while (openedNodes.Count > 0)
            {
                var selectedNode = GetMinFNode();

                if (selectedNode.X == endPoint.x && selectedNode.Y == endPoint.y)
                {
                    var path = selectedNode.GetPathToRootNode();
                    path.RemoveAt(0);
                    if (path.Count == 0)
                        return null;
                    DrawPath(path);
                    return path;
                }
                CheckNodesAroundNode(selectedNode);
                selectedNode.Closed = true;
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
            if (node.F == int.MaxValue && !node.Wall)
            {
                openedNodes.Add(node);
                node.H = GetH(position);
            }
            return node;
        }
        private void CheckNodesAroundNode(Node node)
        {
            var levelCells = level.LevelCells;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                
                    var checkX = node.X + i;
                    var checkY = node.Y + j;

                    //out of bounds
                    if (checkX < 0 || checkY < 0 || checkX >= levelCells.GetLength(0) || checkY >= levelCells.GetLength(1))
                        continue;
                
                    //is diagonal path available
                    if(nodes[checkX, node.Y].Wall || nodes[node.X, checkY].Wall)
                        continue;

                    var checkNode = OpenNode(new Vector2Int(checkX, checkY));
                    if (checkNode.Closed)
                        continue;

                    int gCost = node.G;
                    if (i == 0 || j == 0)
                        gCost += StraightMovingCost;
                    else gCost += DiagonalMovingCost;

                    if (checkNode.G > gCost)
                    {
                        checkNode.G = gCost;
                        checkNode.PreviousNode = node;
                    }
                }
            }
        }
        private int GetH(Vector2Int point)
        {
            var rectWidth = Mathf.Abs(point.x - endPoint.x);
            var rectHeight = Mathf.Abs(point.y - endPoint.y);
            var delta = Mathf.Abs(rectWidth - rectHeight);
            return DiagonalMovingCost * Mathf.Min(rectWidth, rectHeight) + StraightMovingCost * delta;
        }
        private void GenerateNodesFromLevel()
        {
            var levelCells = level.LevelCells;
            nodes = new Node[levelCells.GetLength(0),levelCells.GetLength(1)];
            for(int i = 0; i < levelCells.GetLength(0); i++)
            {
                for (int j = 0; j < levelCells.GetLength(1); j++)
                {
                    bool nodeIsWall = levelCells[i, j] == CellType.Wall;
                    var newNode = new Node(i, j, nodeIsWall);
                    nodes[i, j] = newNode;
                }
            }
        }

        private static void DrawPath(List<Vector2Int> path)
        {
            for (int i = 0; i < path.Count - 1; i++)
            {
                var a = new Vector3(path[i].x, path[i].y);
                var b = new Vector3(path[i + 1].x, path[i + 1].y);
                Debug.DrawLine(a, b, Color.green, 1);
            }
        }
    }
}
