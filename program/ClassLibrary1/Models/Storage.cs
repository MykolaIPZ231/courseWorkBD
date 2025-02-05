using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ClassLibrary1.Models;

public partial class Storage : INotifyPropertyChanged
{
    private string _storageBrand;
    private string _storageModel;
    private string _storageType;
    private int _storageCapacity;
    private decimal _storagePrice;

    public int IdStorage { get; set; }

    public string StorageBrand
    {
        get => _storageBrand;
        set
        {
            _storageBrand = value;
            OnPropertyChanged(nameof(StorageBrand));
        }
    }

    public string StorageModel
    {
        get => _storageModel;
        set
        {
            _storageModel = value;
            OnPropertyChanged(nameof(StorageModel));
        }
    }

    public string StorageType
    {
        get => _storageType;
        set
        {
            _storageType = value;
            OnPropertyChanged(nameof(StorageType));
        }
    }

    public int StorageCapacity
    {
        get => _storageCapacity;
        set
        {
            _storageCapacity = value;
            OnPropertyChanged(nameof(StorageCapacity));
        }
    }

    public decimal StoragePrice
    {
        get => _storagePrice;
        set
        {
            _storagePrice = value;
            OnPropertyChanged(nameof(StoragePrice));
        }
    }

    public Storage()
    {
        _storageBrand = "defaultBrand";
        _storageModel = "defaultModel";
        _storageType = "SSD";
        _storageCapacity = 0;
        _storagePrice = 0;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
