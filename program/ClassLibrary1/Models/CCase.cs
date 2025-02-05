using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ClassLibrary1.Models
{
    public partial class CCase : INotifyPropertyChanged
    {
        private string _caseBrand;
        private string _caseModel;
        private string _caseFormFactor;
        private decimal _casePrise;

        public int IdCase { get; set; }

        public string CaseBrand
        {
            get => _caseBrand;
            set
            {
                _caseBrand = value;
                OnPropertyChanged(nameof(CaseBrand));
            }
        }

        public string CaseModel
        {
            get => _caseModel;
            set
            {
                _caseModel = value;
                OnPropertyChanged(nameof(CaseModel));
            }
        }

        public string CaseFormFactor
        {
            get => _caseFormFactor;
            set
            {
                _caseFormFactor = value;
                OnPropertyChanged(nameof(CaseFormFactor));
            }
        }

        public decimal CasePrise
        {
            get => _casePrise;
            set
            {
                _casePrise = value;
                OnPropertyChanged(nameof(CasePrise));
            }
        }
        public CCase()
        {
            _caseBrand = "defaultBrand";
            _caseModel = "defaultModel";
            _caseFormFactor = "ATX";
            _casePrise = 1;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
