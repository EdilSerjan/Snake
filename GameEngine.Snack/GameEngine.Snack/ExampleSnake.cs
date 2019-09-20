using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class ExampleSnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 1;
        private Point _myHeadPosition;

        public string Name => "Example Snake";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection, int foodX, int foodY)
        {
            if(currentDirection == SnakeDirection.Up 
                && _myHeadPosition.Y < _wallDistanceThreshold)
            {
                return SnakeDirection.Left;
            }

            if(currentDirection == SnakeDirection.Right
                && _myHeadPosition.X > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Up;
            }

            if(currentDirection == SnakeDirection.Down
                && _myHeadPosition.Y > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Right;
            }

            if (currentDirection == SnakeDirection.Left
                && _myHeadPosition.X <  _wallDistanceThreshold)
            {
                return SnakeDirection.Down;
            }

            if ((currentDirection == SnakeDirection.Down
                && _myHeadPosition.Y >= foodY) || (currentDirection == SnakeDirection.Up
                && _myHeadPosition.Y <= foodY))
            {
                if(_myHeadPosition.X > foodX)
                    return SnakeDirection.Left;

                if (_myHeadPosition.X < foodX)
                    return SnakeDirection.Right;
            }

            if ((currentDirection == SnakeDirection.Right
            && _myHeadPosition.X >= foodX) || (currentDirection == SnakeDirection.Left
            && _myHeadPosition.X <= foodX))
            {
                if (_myHeadPosition.Y > foodY)
                    return SnakeDirection.Up;

                if (_myHeadPosition.Y < foodY)
                    return SnakeDirection.Down;
            }

            return currentDirection;
        }

        public void UpdateMap(string map)
        {
            _myHeadPosition = getMyHeadPosition(map);
        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');
            return new Point(headIndex % _width, headIndex / _width);
        }
    }
}
