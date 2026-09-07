using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfApp8
{
    public class DeviceStatus
    {
        public string Name { get; set; } = "";
        public bool IsRunning { get; set; }
        public double Temperature { get; set; }
        public double LoadPercent { get; set; }
    }

    public class StatusViewModel
    {
        public ObservableCollection<DeviceStatus> Devices { get; } = new()
        {
            new() { Name = "电机 M-101", IsRunning = true, Temperature = 25, LoadPercent = 0.42 },
            new() { Name = "变频器 VFD-01", IsRunning = false, Temperature = 45, LoadPercent = 0.0 },
            new() { Name = "PLC-CPU2", IsRunning = true, Temperature = 78, LoadPercent = 0.88 },
            new() { Name = "传感器 S-101", IsRunning = true, Temperature = 55, LoadPercent = 0.30 },
        };
    }
}
