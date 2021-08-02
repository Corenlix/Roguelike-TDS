using System.Collections.Generic;
using LevelGeneration;
using UnityEngine;

namespace LevelGeneration
{
    internal class DungeonFragment
    {
        private RectInt _rect;
        
        
        private readonly List<Corridor> _corridors = new List<Corridor>();
        private bool _isRoom;
        private DungeonFragment _firstChild, _secondChild;

        [Range(0, 5)]
        public static float MaxSizeDivide = 1.5f;
        [Range(10, 100)]
        public static int MinRoomSizePercent = 10;
        [Range(10, 100)]
        public static int MaxRoomSizePercent = 20;
        [Range(1,5)]
        public static int CorridorsThickness = 2;

        public DungeonFragment(RectInt rect) 
        {
            this._rect = rect;
        }
        public void SplitDungeon(int iterationsCount) 
        {
            Split(iterationsCount);
        }

        public List<RectInt> GetRooms()
        {
            var rooms = new List<RectInt>();

            if (_isRoom) 
            {
                rooms.Add(_rect);
            }
            else 
            {
                rooms.AddRange(_firstChild.GetRooms());
                rooms.AddRange(_secondChild.GetRooms());
            }

            return rooms;
        }
        public List<RectInt> GetCorridors()
        {
            if (_isRoom)
                return new List<RectInt>();
            var corridorsRects = new List<RectInt>();

            _corridors.ForEach(x=> corridorsRects.AddRange(x.Rects));

            corridorsRects.AddRange(_firstChild.GetCorridors());
            corridorsRects.AddRange(_secondChild.GetCorridors());

            return corridorsRects;
        }

        private List<RectInt> GetRoomsRects()
        {
            var rooms = new List<RectInt>();

            if (_isRoom)
            {
                rooms.Add(_rect);
            }
            else
            {
                rooms.AddRange(_firstChild.GetRoomsRects());
                rooms.AddRange(_secondChild.GetRoomsRects());
            }

            return rooms;
        }
        private void Split(int iterationsCount) 
        {
            if(iterationsCount == 0) 
            {
                CreateRoom();
                return;
            }

            var newRects = SplitRect(_rect);
            
            _firstChild = new DungeonFragment(newRects[0]);
            _firstChild.Split(iterationsCount - 1);

            _secondChild = new DungeonFragment(newRects[1]);
            _secondChild.Split(iterationsCount - 1);
        }
        private void CreateRoom() 
        {
            var width = GetRoomSize(_rect.width);
            var height = GetRoomSize(_rect.height);

            var x = _rect.x + Random.Range(0, _rect.width - width);
            var y = _rect.y + Random.Range(0, _rect.height - height);

            _rect = new RectInt(x, y, width, height);

            _isRoom = true;
        }

        public void CreateCorridors() 
        {
            if (_isRoom)
                return;

            _firstChild.CreateCorridors();            
            _secondChild.CreateCorridors();

            var newCorridor = GetPossibleCorridorBetweenFragments(_firstChild, _secondChild);
            _corridors.Add(newCorridor);
        }
        private static Corridor GetPossibleCorridorBetweenFragments(DungeonFragment firstFragment, DungeonFragment secondFragment, bool searchShortestWay = true, bool includingCorridors = true) 
        {
            Corridor bestCorridor = null;
            var bestCorridorSquare = int.MaxValue;

            var firstRooms = firstFragment.GetRoomsRects();
            var secondRooms = secondFragment.GetRoomsRects();

            if (includingCorridors) 
            {
                firstRooms.AddRange(firstFragment.GetCorridors());
                secondRooms.AddRange(secondFragment.GetCorridors());
            }

            foreach (var firstRoom in firstRooms)
            {
                foreach (var secondRoom in secondRooms)
                {
                    var possibleCorridor = GetCurvingCorridorBetweenRooms(firstRoom, secondRoom);
                    if (possibleCorridor != null) 
                    {
                        if (!searchShortestWay)
                            return possibleCorridor;

                        int corridorSize = possibleCorridor.GetSize();
                        if(corridorSize < bestCorridorSquare) 
                        {
                            bestCorridorSquare = corridorSize;
                            bestCorridor = possibleCorridor;
                        }
                    }
                }
            }

            return bestCorridor;
        }
        private static Corridor GetCurvingCorridorBetweenRooms(RectInt firstRoom, RectInt secondRoom) 
        {
            var firstPoint = new Vector2Int(Random.Range(firstRoom.x, firstRoom.xMax), Random.Range(firstRoom.y, firstRoom.yMax));
            var secondPoint = new Vector2Int(Random.Range(secondRoom.x, secondRoom.xMax), Random.Range(secondRoom.y, secondRoom.yMax));

            var horizontalRect = new RectInt(); 

            horizontalRect.SetMinMax(new Vector2Int(Mathf.Min(firstPoint.x, secondPoint.x), secondPoint.y),
                new Vector2Int(Mathf.Max(firstPoint.x, secondPoint.x), secondPoint.y + CorridorsThickness - 1));

            var verticalRect = new RectInt();
            verticalRect.SetMinMax(new Vector2Int(firstPoint.x, Mathf.Min(firstPoint.y, secondPoint.y)),
                new Vector2Int(firstPoint.x + CorridorsThickness - 1, Mathf.Max(firstPoint.y, secondPoint.y)));

            return new Corridor( new List<RectInt> { horizontalRect, verticalRect } );
        }

        private static RectInt[] SplitRect(RectInt rect) 
        {
            var isHorizontalSplit = Random.Range(1, 100) < 50;
            return isHorizontalSplit ? HorizontalSplitRect(rect) : VerticalSplitRect(rect);
        }
        private static RectInt[] HorizontalSplitRect(RectInt rect) 
        {
            RectInt[] newRects = new RectInt[2];
            int firstRectWidth = DivideSize(rect.width);

            newRects[0] = new RectInt(rect.x, rect.y, firstRectWidth, rect.height);
            firstRectWidth += 1;
            newRects[1] = new RectInt(rect.x + firstRectWidth, rect.y, rect.width - firstRectWidth, rect.height);

            return newRects;
        }
        private static RectInt[] VerticalSplitRect(RectInt rect)
        {
            var newRects = new RectInt[2];
            var firstRectHeight = DivideSize(rect.height);

            newRects[0] = new RectInt(rect.x, rect.y, rect.width, firstRectHeight);
            firstRectHeight += 1;
            newRects[1] = new RectInt(rect.x, rect.y + firstRectHeight, rect.width, rect.height - firstRectHeight);

            return newRects;
        }

        private static int DivideSize(int size) 
        {
            var divideRate = Random.Range(100, (int)MaxSizeDivide*100)/100;
            return size / (divideRate + 1);
        }
        private static int GetRoomSize(int size) 
        {
            var roomSizeModifier = Random.Range(MinRoomSizePercent, MaxRoomSizePercent) / 100f;
            return (int)(roomSizeModifier * size);
        }
    }
}
