using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOP_CourseWork.Controls
{
    public class CircularProgressBar : Control
    {
        static CircularProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CircularProgressBar), 
                new FrameworkPropertyMetadata(typeof(CircularProgressBar)));
        }

        public static readonly DependencyProperty ProgressProperty =
            DependencyProperty.Register("Progress", typeof(double), typeof(CircularProgressBar),
                new PropertyMetadata(0.0, OnProgressChanged, CoerceProgress));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(CircularProgressBar),
                new PropertyMetadata(100.0));

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(CircularProgressBar),
                new PropertyMetadata(10.0));

        public static readonly DependencyProperty ProgressBrushProperty =
            DependencyProperty.Register("ProgressBrush", typeof(Brush), typeof(CircularProgressBar),
                new PropertyMetadata(Brushes.Green));

        public static readonly DependencyProperty BackgroundBrushProperty =
            DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(CircularProgressBar),
                new PropertyMetadata(Brushes.LightGray));

        public double Progress
        {
            get { return (double)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public Brush ProgressBrush
        {
            get { return (Brush)GetValue(ProgressBrushProperty); }
            set { SetValue(ProgressBrushProperty, value); }
        }

        public Brush BackgroundBrush
        {
            get { return (Brush)GetValue(BackgroundBrushProperty); }
            set { SetValue(BackgroundBrushProperty, value); }
        }

        private static object CoerceProgress(DependencyObject d, object baseValue)
        {
            var progress = (double)baseValue;
            var maximum = ((CircularProgressBar)d).Maximum;

            if (progress > maximum)
                return maximum;
            if (progress < 0)
                return 0;
            return progress;
        }

        private static void OnProgressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CircularProgressBar)d).InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            var width = ActualWidth;
            var height = ActualHeight;
            var size = Math.Min(width, height);
            var center = new Point(width / 2, height / 2);
            var radius = (size - StrokeThickness) / 2;

            // Фоновый круг
            drawingContext.DrawEllipse(null, new Pen(BackgroundBrush, StrokeThickness),
                center, radius, radius);

            // Прогресс
            if (Progress > 0)
            {
                var pen = new Pen(ProgressBrush, StrokeThickness);
                var startPoint = new Point(center.X, center.Y - radius);
                var angle = (Progress / Maximum) * 360;
                var isLargeArc = angle > 180;

                var endPoint = new Point(
                    center.X + radius * Math.Sin(angle * Math.PI / 180),
                    center.Y - radius * Math.Cos(angle * Math.PI / 180));

                var arcSize = new Size(radius, radius);

                var figure = new PathFigure(startPoint, new[]
                {
                    new ArcSegment(endPoint, arcSize, 0, isLargeArc, SweepDirection.Clockwise, true)
                }, false);

                var geometry = new PathGeometry(new[] { figure });
                drawingContext.DrawGeometry(null, pen, geometry);
            }

            // Текст с процентами
            var text = $"{(int)((Progress / Maximum) * 100)}%";
            var formattedText = new FormattedText(
                text,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Segoe UI"),
                size / 6,
                Brushes.Black,
                VisualTreeHelper.GetDpi(this).PixelsPerDip);

            var textPoint = new Point(
                center.X - formattedText.Width / 2,
                center.Y - formattedText.Height / 2);

            drawingContext.DrawText(formattedText, textPoint);
        }
    }
} 