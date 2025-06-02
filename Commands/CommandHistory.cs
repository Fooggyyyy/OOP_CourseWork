using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOP_CourseWork.Commands
{
    public class CommandHistory
    {
        private readonly Stack<IUndoableCommand> _undoStack = new();
        private readonly Stack<IUndoableCommand> _redoStack = new();

        public bool CanUndo => _undoStack.Count > 0;
        public bool CanRedo => _redoStack.Count > 0;

        public async Task ExecuteCommand(IUndoableCommand command)
        {
            await command.ExecuteAsync();
            _undoStack.Push(command);
            _redoStack.Clear(); // Clear redo stack when new command is executed
        }

        public async Task Undo()
        {
            if (!CanUndo) return;

            var command = _undoStack.Pop();
            await command.UndoAsync();
            _redoStack.Push(command);
        }

        public async Task Redo()
        {
            if (!CanRedo) return;

            var command = _redoStack.Pop();
            await command.ExecuteAsync();
            _undoStack.Push(command);
        }

        public void Clear()
        {
            _undoStack.Clear();
            _redoStack.Clear();
        }
    }
} 