using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ClassLibrary1.Models;

public partial class Gpu : INotifyPropertyChanged
{
    private string _gpuBrand;
    private string _gpuModel;
    private int _gpuMemorySize;
    private decimal _gpuFrequency;
    private decimal _gpuPrice;

    public int IdGpu { get; set; }

    public string GpuBrand
    {
        get => _gpuBrand;
        set
        {
            _gpuBrand = value;
            OnPropertyChanged(nameof(GpuBrand));
        }
    }

    public string GpuModel
    {
        get => _gpuModel;
        set
        {
            _gpuModel = value;
            OnPropertyChanged(nameof(GpuModel));
        }
    }

    public int GpuMemorySize
    {
        get => _gpuMemorySize;
        set
        {
            _gpuMemorySize = value;
            OnPropertyChanged(nameof(GpuMemorySize));
        }
    }

    public decimal GpuFrequency
    {
        get => _gpuFrequency;
        set
        {
            _gpuFrequency = value;
            OnPropertyChanged(nameof(GpuFrequency));
        }
    }

    public decimal GpuPrice
    {
        get => _gpuPrice;
        set
        {
            _gpuPrice = value;
            OnPropertyChanged(nameof(GpuPrice));
        }
    }

    public Gpu()
    {
        _gpuBrand = "defaultBrand";
        _gpuModel = "model";
        _gpuMemorySize = 0;
        _gpuFrequency = 0;
        _gpuPrice = 0;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
