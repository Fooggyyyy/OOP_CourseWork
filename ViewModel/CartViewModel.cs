﻿using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Model;
using OOP_CourseWork.Model.CurrentUser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OOP_CourseWork.ViewModel
{
    public class CartViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ICommand LoadCartCommand { get; }
        public ICommand RemoveCartCommand { get; }

        private ObservableCollection<Item> _cartItems = new ObservableCollection<Item>();
        public ObservableCollection<Item> CartItems
        {
            get => _cartItems;
            set
            {
                _cartItems = value;
                OnPropertyChanged(nameof(CartItems));
            }
        }

        public CartViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            LoadCartCommand = CreateAsyncCommand(LoadCartAsync);
            RemoveCartCommand = CreateAsyncCommand(RemoveCartAsync);

            LoadCartCommand.Execute(null);
        }


        private async Task LoadCartAsync()
        {
            try
            {
                CartItems.Clear(); 

                var carts = await _unitOfWork.Carts.GetAll();

                var items = carts.Where(c => c.UserId == CurrentUser.UserId).Select(x => x.ItemId).ToList();

                var allItems = await _unitOfWork.Items.GetAll();

                var filteredItems = allItems.Where(item => items.Contains(item.Id)).ToList();

                foreach (var item in filteredItems)
                {
                    if (item.Name != null)
                    {
                        CartItems.Add(item);
                    }
                   
                }

                OnPropertyChanged(nameof(CartItems));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private async Task RemoveCartAsync(object parameter)
        {
            if (parameter is Item itemToRemove)
            {
                var carts = await _unitOfWork.Carts.GetAll();

                var cartToRemove = carts.FirstOrDefault(c => c.ItemId == itemToRemove.Id && c.UserId == CurrentUser.UserId);

                if (cartToRemove != null)
                {
                    await _unitOfWork.Carts.Remove(cartToRemove);

                    CartItems.Remove(itemToRemove);

                    await _unitOfWork.CompleteAsync();
                }
            }
        }
    }
}
