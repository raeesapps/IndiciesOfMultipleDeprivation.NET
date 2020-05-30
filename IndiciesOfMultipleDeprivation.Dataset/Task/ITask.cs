using IndiciesOfMultipleDeprivation.Models;

namespace IndiciesOfMultipleDeprivation.Task
{
    public interface ITask
    {
        public void Run(Dataset dataset);
    }
}