using System;

namespace DataModel.Task.Operations
{
    public class IsLesser<T> : IOperation<T> where T : IComparable<T>
    {
        public bool Check(T baseValue, T secondValue)
        {
            int res = baseValue.CompareTo(secondValue);
            return res < 0;
        }
    }
}