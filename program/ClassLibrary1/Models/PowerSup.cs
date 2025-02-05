using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ClassLibrary1.Models;

public partial class PowerSup : INotifyPropertyChanged
{
    private string _powerSupBrand;
    private string _powerSupModel;
    private int _powerSupPowerWatt;
    private string _powerSupEfficiency;
    private decimal _powerSupPrice;

    public int IdPowerSup { get; set; }

    public string PowerSupBrand
    {
        get => _powerSupBrand;
        set
        {
            _powerSupBrand = value;
            OnPropertyChanged(nameof(PowerSupBrand));
        }
    }

    public string PowerSupModel
    {
        get => _powerSupModel;
        set
        {
            _powerSupModel = value;
            OnPropertyChanged(nameof(PowerSupModel));
        }
    }

    public int PowerSupPowerWatt
    {
        get => _powerSupPowerWatt;
        set
        {
            _powerSupPowerWatt = value;
            OnPropertyChanged(nameof(PowerSupPowerWatt));
        }
    }

    public string PowerSupEfficincy
    {
        get => _powerSupEfficiency;
        set
        {
            _powerSupEfficiency = value;
            OnPropertyChanged(nameof(PowerSupEfficincy));
        }
    }

    public decimal PowerSupPrice
    {
        get => _powerSupPrice;
        set
        {
            _powerSupPrice = value;
            OnPropertyChanged(nameof(PowerSupPrice));
        }
    }

    public PowerSup()
    {
        _powerSupBrand = "defaultBrand";
        _powerSupModel = "defaultModel";
        _powerSupPowerWatt = 0;
        _powerSupEfficiency = "80 Plus";
        _powerSupPrice = 0;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
