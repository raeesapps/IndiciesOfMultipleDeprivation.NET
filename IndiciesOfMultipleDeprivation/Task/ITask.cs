using IndiciesOfMultipleDeprivation.Model;

namespace IndiciesOfMultipleDeprivation.Task
{
    public interface ITask
    {
        public void Run(Dataset dataset);
    }
}