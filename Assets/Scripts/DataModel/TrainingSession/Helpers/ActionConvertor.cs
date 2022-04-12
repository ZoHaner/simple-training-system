using UnityEngine;

namespace DataModel.TrainingSession.Helpers
{
    /// <summary>
    /// Converter of mouse movement to change of position and rotation of an object
    /// </summary>
    public class ActionConvertor
    {
        /// <summary>
        /// Convert mouse movement to position change
        /// </summary>
        public static Vector3 ConvertToDeltaPosition(Vector2 mouseDelta)
        {
            float deltaX = mouseDelta.x * 0.005f;
            float deltaY = mouseDelta.y * 0.0025f;
            float deltaZ = mouseDelta.y * 0.0025f;
            return new Vector3(deltaX, deltaY, deltaZ);
        }

        /// <summary>
        /// ПConvert mouse movement to rotation change
        /// </summary>
        public static Vector3 ConvertToDeltaRotation(Vector2 mouseDelta)
        {
            float deltaX = mouseDelta.y * 0.1f;
            float deltaY = mouseDelta.x * 0.1f;
            float deltaZ = - mouseDelta.y * 0.2f;
            return new Vector3(deltaX, deltaY, deltaZ);
        }
    }
}
