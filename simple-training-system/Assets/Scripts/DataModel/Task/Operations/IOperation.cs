namespace DataModel.Task.Operations
{
    public interface IOperation<T>
    {
        bool Check(T baseValue, T secondValue);
    }
}