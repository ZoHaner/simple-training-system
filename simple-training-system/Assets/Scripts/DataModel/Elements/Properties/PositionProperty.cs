using Components.Interactables;
using UnityEngine;

namespace DataModel.Elements.Properties
{
    public class PositionProperty : IProperty
    {
        public Vector3 Position { get; private set; }
        private bool lockX;
        private bool lockY;
        private bool lockZ;
        private float minX, maxX;
        private float minY, maxY;
        private float minZ, maxZ;

        public PositionProperty(Vector3 initPosition, bool lockX, bool lockY, bool lockZ, Vector3 minPos, Vector3 maxPos)
        {
            Position = initPosition;
            this.lockX = lockX;
            this.lockY = lockY;
            this.lockZ = lockZ;
            minX = minPos.x;
            minY = minPos.y;
            minZ = minPos.z;
            maxX = maxPos.x;
            maxY = maxPos.y;
            maxZ = maxPos.z;
        }

        public PositionProperty(MoveableElement moveableElement)
        {
            Position = moveableElement.GetStartPosition();
            var locks = moveableElement.GetLocks();
            this.lockX = locks[0];
            this.lockY = locks[1];
            this.lockZ = locks[2];
            var minValues = moveableElement.GetMinValues();
            minX = minValues.x;
            minY = minValues.y;
            minZ = minValues.z;
            var maxValues = moveableElement.GetMaxValues();
            maxX = maxValues.x;
            maxY = maxValues.y;
            maxZ = maxValues.z;
        }

        public void Move(Vector3 deltaPos)
        {
            Vector3 curPos = Position;
            Vector3 newPos = curPos + deltaPos;

            if (!lockX)
            {
                PutInsideBorders(ref newPos.x, minX, maxX);
                curPos.x = newPos.x;
            }
            if (!lockY)
            {
                PutInsideBorders(ref newPos.y, minY, maxY);
                curPos.y = newPos.y;
            }
            if (!lockZ)
            {
                PutInsideBorders(ref newPos.z, minZ, maxZ);
                curPos.z = newPos.z;
            }

            Position = curPos;
        }

        private void PutInsideBorders(ref float value, float min, float max)
        {
            if (value < min)
            {
                value = min;
            }
            else if (value > max)
            {
                value = max;
            }
        }
    }
}