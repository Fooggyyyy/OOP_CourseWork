using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace OOP_CourseWork.Commands
{
    public class AddItemCommand : IUndoableCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Item _itemCopy;
        private readonly ObservableCollection<Item> _items;

        public string Description => $"Add item: {_itemCopy.Name}";

        public AddItemCommand(IUnitOfWork unitOfWork, Item item, ObservableCollection<Item> items)
        {
            _unitOfWork = unitOfWork;
            _items = items;
            _itemCopy = new Item
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                PhotoPath = item.PhotoPath,
                Size = item.Size,
                Color = item.Color,
                Type = item.Type
            };
        }

        public async Task ExecuteAsync()
        {
            await _unitOfWork.Items.Add(_itemCopy);
            await _unitOfWork.CompleteAsync();
            _items.Add(_itemCopy);
        }

        public async Task UndoAsync()
        {
            var itemToRemove = await _unitOfWork.Items.Get(_itemCopy.Id);
            if (itemToRemove != null)
            {
                await _unitOfWork.Items.Remove(itemToRemove);
                await _unitOfWork.CompleteAsync();
                var itemInCollection = _items.FirstOrDefault(i => i.Id == _itemCopy.Id);
                if (itemInCollection != null)
                {
                    _items.Remove(itemInCollection);
                }
            }
        }
    }

    public class DeleteItemCommand : IUndoableCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Item _itemCopy;
        private readonly ObservableCollection<Item> _items;

        public string Description => $"Delete item: {_itemCopy.Name}";

        public DeleteItemCommand(IUnitOfWork unitOfWork, Item item, ObservableCollection<Item> items)
        {
            _unitOfWork = unitOfWork;
            _items = items;
            _itemCopy = new Item
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                PhotoPath = item.PhotoPath,
                Size = item.Size,
                Color = item.Color,
                Type = item.Type
            };
        }

        public async Task ExecuteAsync()
        {
            var itemToDelete = await _unitOfWork.Items.Get(_itemCopy.Id);
            if (itemToDelete != null)
            {
                await _unitOfWork.Items.Remove(itemToDelete);
                await _unitOfWork.CompleteAsync();
                var itemInCollection = _items.FirstOrDefault(i => i.Id == _itemCopy.Id);
                if (itemInCollection != null)
                {
                    _items.Remove(itemInCollection);
                }
            }
        }

        public async Task UndoAsync()
        {
            await _unitOfWork.Items.Add(_itemCopy);
            await _unitOfWork.CompleteAsync();
            _items.Add(_itemCopy);
        }
    }

    public class UpdateItemCommand : IUndoableCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _itemId;
        private readonly Item _originalState;
        private readonly Item _newState;

        public string Description => $"Update item: {_newState.Name}";

        public UpdateItemCommand(IUnitOfWork unitOfWork, Item item)
        {
            _unitOfWork = unitOfWork;
            _itemId = item.Id;
            
            // Сохраняем оригинальное состояние
            _originalState = new Item
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                PhotoPath = item.PhotoPath,
                Size = item.Size,
                Color = item.Color,
                Type = item.Type
            };

            // Сохраняем новое состояние
            _newState = new Item
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                PhotoPath = item.PhotoPath,
                Size = item.Size,
                Color = item.Color,
                Type = item.Type
            };
        }

        public async Task ExecuteAsync()
        {
            var item = await _unitOfWork.Items.Get(_itemId);
            if (item != null)
            {
                CopyState(_newState, item);
                await _unitOfWork.Items.Update(item);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task UndoAsync()
        {
            var item = await _unitOfWork.Items.Get(_itemId);
            if (item != null)
            {
                CopyState(_originalState, item);
                await _unitOfWork.Items.Update(item);
                await _unitOfWork.CompleteAsync();
            }
        }

        private void CopyState(Item source, Item target)
        {
            target.Name = source.Name;
            target.Description = source.Description;
            target.Price = source.Price;
            target.PhotoPath = source.PhotoPath;
            target.Size = source.Size;
            target.Color = source.Color;
            target.Type = source.Type;
        }
    }
} 