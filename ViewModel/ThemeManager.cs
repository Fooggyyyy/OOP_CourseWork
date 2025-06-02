using System;
using System.Collections.Generic;
using System.Windows;

namespace OOP_CourseWork.ViewModel
{
    public class ThemeManager
    {
        private static ThemeManager _instance;
        private ResourceDictionary _currentTheme;

        public static ThemeManager Instance => _instance ??= new ThemeManager();

        private readonly Dictionary<string, string> _themes = new Dictionary<string, string>
        {
            { "Optimistic", "pack://application:,,,/OOP_CourseWork;component/Themes/OptimisticTheme.xaml" },
            { "Grayscale", "pack://application:,,,/OOP_CourseWork;component/Themes/GrayscaleTheme.xaml" }
        };

        private ThemeManager()
        {
            // Инициализация темой по умолчанию
            SetTheme("Optimistic");
        }

        public void SetTheme(string themeName)
        {
            if (!_themes.ContainsKey(themeName))
                return;

            var app = Application.Current;
            
            try
            {
                var themeUri = new Uri(_themes[themeName], UriKind.Absolute);
                var newTheme = new ResourceDictionary { Source = themeUri };

                // Удаляем текущую тему
                if (_currentTheme != null)
                {
                    app.Resources.MergedDictionaries.Remove(_currentTheme);
                }

                // Добавляем новую тему
                app.Resources.MergedDictionaries.Add(newTheme);
                _currentTheme = newTheme;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке темы: {ex.Message}");
            }
        }

        public List<string> GetAvailableThemes()
        {
            return new List<string>(_themes.Keys);
        }
    }
} 