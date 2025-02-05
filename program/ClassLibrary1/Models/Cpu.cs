using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ClassLibrary1.Models;

public partial class Cpu : INotifyPropertyChanged
{
    private string _cpuBrand;
    private string _cpuModel;
    private decimal _cpuFrequency;
    private int _cpuCores;
    private int _cpuThreads;
    private decimal _cpuPrice;

    public int IdCpu { get; set; }

    public string CpuBrand
    {
        get => _cpuBrand;
        set
        {
            _cpuBrand = value;
            OnPropertyChanged(nameof(CpuBrand));
        }
    }

    public string CpuModel
    {
        get => _cpuModel;
        set
        {
            _cpuModel = value;
            OnPropertyChanged(nameof(CpuModel));
        }
    }

    public decimal CpuFrequency
    {
        get => _cpuFrequency;
        set
        {
            _cpuFrequency = value;
            OnPropertyChanged(nameof(CpuFrequency));
        }
    }

    public int CpuCores
    {
        get => _cpuCores;
        set
        {
            _cpuCores = value;
            OnPropertyChanged(nameof(CpuCores));
        }
    }

    public int CpuThreads
    {
        get => _cpuThreads;
        set
        {
            _cpuThreads = value;
            OnPropertyChanged(nameof(CpuThreads));
        }
    }

    public decimal CpuPrice
    {
        get => _cpuPrice;
        set
        {
            _cpuPrice = value;
            OnPropertyChanged(nameof(CpuPrice));
        }
    }

    public Cpu()
    {
        _cpuBrand = "defaultBrand";
        _cpuModel = "defaultModel";
        _cpuFrequency = 0;
        _cpuCores = 0;
        _cpuThreads = 0;
        _cpuPrice = 0;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
