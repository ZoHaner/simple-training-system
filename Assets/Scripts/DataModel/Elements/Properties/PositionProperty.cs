using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void SetPosition(Vector3 newPos)
    {
        Vector3 curPos = Position;

        if(!lockX)
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
        if(value < min)
        {
            value = min;
        }
        else if(value > max)
        {
            value = max;
        }
    }
}
