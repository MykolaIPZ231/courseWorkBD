using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ClassLibrary1.Models;

public partial class Ram : INotifyPropertyChanged
{
    private string _ramBrand;
    private string _ramModel;
    private int _ramMemorySize;
    private decimal? _ramFrequency;
    private decimal _ramPrice;
    private string _ramType;

    public int IdRam { get; set; }

    public string RamBrand
    {
        get => _ramBrand;
        set
        {
            _ramBrand = value;
            OnPropertyChanged(nameof(RamBrand));
        }
    }

    public string RamModel
    {
        get => _ramModel;
        set
        {
            _ramModel = value;
            OnPropertyChanged(nameof(RamModel));
        }
    }

    public int RamMemorySize
    {
        get => _ramMemorySize;
        set
        {
            _ramMemorySize = value;
            OnPropertyChanged(nameof(RamMemorySize));
        }
    }

    public decimal? RamFrequency
    {
        get => _ramFrequency;
        set
        {
            _ramFrequency = value;
            OnPropertyChanged(nameof(RamFrequency));
        }
    }

    public decimal RamPrice
    {
        get => _ramPrice;
        set
        {
            _ramPrice = value;
            OnPropertyChanged(nameof(RamPrice));
        }
    }

    public string RamType
    {
        get => _ramType;
        set
        {
            _ramType = value;
            OnPropertyChanged(nameof(RamType));
        }
    }

    public Ram()
    {
        _ramBrand = "defaultBrand";
        _ramModel = "defaultModel";
        _ramMemorySize = 0;
        _ramFrequency = null;
        _ramPrice = 0;
        _ramType = "DDR4";
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
