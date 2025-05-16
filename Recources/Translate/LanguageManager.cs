using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_CourseWork.Recources.Translate
{
    public static class LanguageManager
    {
        public static void ChangeLanguage(string lang)
        {
            var dict = new ResourceDictionary();
            switch (lang)
            {
                case "en":
                    dict.Source = new Uri("Recources/Translate/en.xaml", UriKind.Relative);
                    break;
                case "ru":
                    dict.Source = new Uri("Recources/Translate/ru.xaml", UriKind.Relative);
                    break;
            }

            var oldDict = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.StartsWith("Recources/Translate/."));
            if (oldDict != null)
                Application.Current.Resources.MergedDictionaries.Remove(oldDict);

            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
    }

}
