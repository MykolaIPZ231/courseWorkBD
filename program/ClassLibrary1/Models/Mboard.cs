using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ClassLibrary1.Models;

public partial class Mboard : INotifyPropertyChanged
{
    private string _mboardBrand;
    private string _mboardModel;
    private string _mboardSocket;
    private string _mboardChipset;
    private string _mboardFormFactor;
    private decimal _mboardPrice;

    public int IdMboard { get; set; }

    public string MboardBrand
    {
        get => _mboardBrand;
        set
        {
            _mboardBrand = value;
            OnPropertyChanged(nameof(MboardBrand));
        }
    }

    public string MboardModel
    {
        get => _mboardModel;
        set
        {
            _mboardModel = value;
            OnPropertyChanged(nameof(MboardModel));
        }
    }

    public string MboardSocket
    {
        get => _mboardSocket;
        set
        {
            _mboardSocket = value;
            OnPropertyChanged(nameof(MboardSocket));
        }
    }

    public string MboardChipset
    {
        get => _mboardChipset;
        set
        {
            _mboardChipset = value;
            OnPropertyChanged(nameof(MboardChipset));
        }
    }

    public string MboardFormFactor
    {
        get => _mboardFormFactor;
        set
        {
            _mboardFormFactor = value;
            OnPropertyChanged(nameof(MboardFormFactor));
        }
    }

    public decimal MboardPrice
    {
        get => _mboardPrice;
        set
        {
            _mboardPrice = value;
            OnPropertyChanged(nameof(MboardPrice));
        }
    }

    public Mboard()
    {
        _mboardBrand = "defaultBrand";
        _mboardModel = "defaultModel";
        _mboardSocket = "defaultSocket";
        _mboardChipset = "defaultChipset";
        _mboardFormFactor = "ATX";
        _mboardPrice = 0;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
