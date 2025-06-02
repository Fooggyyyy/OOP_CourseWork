using System.Threading.Tasks;

namespace OOP_CourseWork.Commands
{
    public interface IUndoableCommand
    {
        Task ExecuteAsync();
        Task UndoAsync();
        string Description { get; }
    }
} 