﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public class RotationProperty : IProperty
    {
        public Vector3 Rotation { get; private set; }
        private bool lockX;
        private bool lockY;
        private bool lockZ;
        private float minX, maxX;
        private float minY, maxY;
        private float minZ, maxZ;

        public RotationProperty(Vector3 initRotation, bool lockX, bool lockY, bool lockZ, Vector3 minRot, Vector3 maxRot)
        {
            Rotation = initRotation;
            this.lockX = lockX;
            this.lockY = lockY;
            this.lockZ = lockZ;
            minX = minRot.x;
            minY = minRot.y;
            minZ = minRot.z;
            maxX = maxRot.x;
            maxY = maxRot.y;
            maxZ = maxRot.z;
        }

        public void SetRotation(Vector3 newRot)
        {
            Vector3 curRot = Rotation;

            if (!lockX)
            {
                PutInsideBorders(ref newRot.x, minX, maxX);
                curRot.x = newRot.x;
            }
            if (!lockY)
            {
                PutInsideBorders(ref newRot.y, minY, maxY);
                curRot.y = newRot.y;
            }
            if (!lockZ)
            {
                PutInsideBorders(ref newRot.z, minZ, maxZ);
                curRot.z = newRot.z;
            }

            Rotation = curRot;
        }

        // ToDo: Добавить учет углов больших 360 и меньших -360 град.
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