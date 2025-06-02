using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace OOP_CourseWork.Controls
{
    public class StarInfo : INotifyPropertyChanged
    {
        private bool _isFilled;
        private int _index;

        public bool IsFilled
        {
            get => _isFilled;
            set
            {
                if (_isFilled != value)
                {
                    _isFilled = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Index
        {
            get => _index;
            set
            {
                if (_index != value)
                {
                    _index = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RatingControl : Control
    {
        private ObservableCollection<StarInfo>? _stars;
        private ItemsControl? _starsContainer;
        private bool _isInitialized;

        static RatingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RatingControl),
                new FrameworkPropertyMetadata(typeof(RatingControl)));
        }

        public RatingControl()
        {
            _stars = new ObservableCollection<StarInfo>();
            this.Loaded += RatingControl_Loaded;
        }

        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register(
                "Rating",
                typeof(double),
                typeof(RatingControl),
                new FrameworkPropertyMetadata(0.0, 
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnRatingChanged));

        public static readonly DependencyProperty MaxRatingProperty =
            DependencyProperty.Register(
                "MaxRating",
                typeof(int),
                typeof(RatingControl),
                new PropertyMetadata(5, OnMaxRatingChanged));

        public static readonly DependencyProperty StarSizeProperty =
            DependencyProperty.Register(
                "StarSize",
                typeof(double),
                typeof(RatingControl),
                new PropertyMetadata(20.0));

        public double Rating
        {
            get => (double)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        public int MaxRating
        {
            get => (int)GetValue(MaxRatingProperty);
            set => SetValue(MaxRatingProperty, value);
        }

        public double StarSize
        {
            get => (double)GetValue(StarSizeProperty);
            set => SetValue(StarSizeProperty, value);
        }

        private static void OnRatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RatingControl control)
            {
                control.UpdateStars();
            }
        }

        private static void OnMaxRatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RatingControl control)
            {
                control.UpdateStarCollection();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (_starsContainer != null)
            {
                _starsContainer.MouseMove -= StarsContainer_MouseMove;
                _starsContainer.MouseLeave -= StarsContainer_MouseLeave;
                _starsContainer.MouseLeftButtonUp -= StarsContainer_MouseLeftButtonUp;
            }

            _starsContainer = GetTemplateChild("PART_StarsContainer") as ItemsControl;
            
            if (_starsContainer != null)
            {
                _starsContainer.ItemsSource = _stars;
                _starsContainer.MouseMove += StarsContainer_MouseMove;
                _starsContainer.MouseLeave += StarsContainer_MouseLeave;
                _starsContainer.MouseLeftButtonUp += StarsContainer_MouseLeftButtonUp;
            }

            if (!_isInitialized)
            {
                UpdateStarCollection();
                _isInitialized = true;
            }
        }

        private void RatingControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_isInitialized)
            {
                UpdateStarCollection();
                _isInitialized = true;
            }
            UpdateStars();
        }

        private void UpdateStarCollection()
        {
            if (_stars == null) return;

            _stars.Clear();
            for (int i = 0; i < MaxRating; i++)
            {
                _stars.Add(new StarInfo { Index = i, IsFilled = i < Rating });
            }

            if (_starsContainer != null)
            {
                _starsContainer.ItemsSource = null;
                _starsContainer.ItemsSource = _stars;
            }
        }

        private void UpdateStars()
        {
            if (_stars == null) return;

            for (int i = 0; i < _stars.Count; i++)
            {
                _stars[i].IsFilled = i < Rating;
            }
        }

        private void StarsContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsEnabled) return;

            var position = e.GetPosition(_starsContainer);
            var tempRating = CalculateRatingFromPosition(position);

            for (int i = 0; i < _stars?.Count; i++)
            {
                if (_stars[i] != null)
                {
                    _stars[i].IsFilled = i < tempRating;
                }
            }

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Rating = tempRating;
            }
        }

        private void StarsContainer_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!IsEnabled) return;
            UpdateStars();
        }

        private void StarsContainer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!IsEnabled) return;
            var position = e.GetPosition(_starsContainer);
            Rating = CalculateRatingFromPosition(position);
        }

        private double CalculateRatingFromPosition(Point position)
        {
            if (_starsContainer?.ActualWidth == 0) return 0;
            
            var starWidth = _starsContainer.ActualWidth / MaxRating;
            var rating = (position.X / starWidth);
            return Math.Min(Math.Max(rating, 0), MaxRating);
        }
    }
} 