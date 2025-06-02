using System;
using System.Collections.Generic;
using System.Windows;

namespace OOP_CourseWork
{
    public class ThemeManager
    {
        private static ThemeManager _instance;
        private string _currentTheme;

        public static ThemeManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ThemeManager();
                }
                return _instance;
            }
        }

        private ThemeManager()
        {
            _currentTheme = "Optimistic"; // Тема по умолчанию
        }

        public void SetTheme(string themeName)
        {
            if (string.IsNullOrEmpty(themeName))
                return;

            _currentTheme = themeName;

            // Очищаем текущие словари ресурсов
            Application.Current.Resources.MergedDictionaries.Clear();

            // Добавляем базовые стили
            Application.Current.Resources.MergedDictionaries.Add(
                new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/Recources/Style.xaml", UriKind.Absolute)
                }
            );

            // Добавляем выбранную тему
            string themePath = $"pack://application:,,,/Recources/Themes/{themeName}Theme.xaml";
            Application.Current.Resources.MergedDictionaries.Add(
                new ResourceDictionary
                {
                    Source = new Uri(themePath, UriKind.Absolute)
                }
            );
        }

        public List<string> GetAvailableThemes()
        {
            return new List<string>
            {
                "Optimistic",
                "Grayscale"
            };
        }

        public string CurrentTheme => _currentTheme;
    }
} 