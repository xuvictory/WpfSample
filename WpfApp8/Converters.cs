using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp8
{
    /// <summary>
    /// 转换器1: bool → "运行中" / "已停止"
    /// </summary>
    public class BoolToStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is bool running)
                return running ? "● 运行中" : "○ 已停止";
            return "未知";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }

    /// <summary>
    /// 转换器2: double → 颜色（温度分级）
    /// parameter 为阈值字符串 "30|60"
    /// </summary>
    public class TemperatureToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is double temp)
            {
                // 解析阈值参数
                double low = 30, high = 60;
                if (parameter is string p)
                {
                    var parts = p.Split('|');
                    if (parts.Length == 2)
                    {
                        double.TryParse(parts[0], out low);
                        double.TryParse(parts[1], out high);
                    }
                }
                return new SolidColorBrush(temp <= low
                    ? Color.FromRgb(0x3F, 0xB9, 0x50)
                    : temp <= high
                        ? Color.FromRgb(0xD4, 0xA0, 0x17)
                        : Color.FromRgb(0xCC, 0x22, 0x22));
            }
            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }

    /// <summary>
    /// 转换器3: double 百分比 → 进度条值（输入 0~1 → 输出 0~100）
    /// </summary>
    public class PercentToProgressConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is double pct)
                return pct * 100.0;
            return 0.0;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is double val)
                return val / 100.0;
            return 0.0;
        }
    }
}
