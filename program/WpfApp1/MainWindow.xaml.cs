using ClassLibrary1.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1;
using System.Reflection;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        CourseWorkContext context = new CourseWorkContext();

        private Type currentType;

        private List<Button> loadButtons;

        private readonly Dictionary<string, Type> _typeMapping = new Dictionary<string, Type>
        {
            { "CCase", typeof(CCase) },
            { "Cpu", typeof(Cpu) },
            { "Gpu", typeof(Gpu) },
            { "Mboard", typeof(Mboard) },
            { "PowerSup", typeof(PowerSup) },
            { "Ram", typeof(Ram) },
            { "Storage", typeof(Storage) }
        };
        private readonly Dictionary<Type, Func<string, Delegate>> _searchPredicates = new Dictionary<Type, Func<string, Delegate>>
        {
            { typeof(CCase), searchText => (Func<CCase, bool>)(c =>
                c.CaseBrand.ToLower().Contains(searchText) ||
                c.CaseModel.ToLower().Contains(searchText) ||
                c.CaseFormFactor.ToLower().Contains(searchText)) },
            { typeof(Cpu), searchText => (Func<Cpu, bool>)(c =>
                c.CpuBrand.ToLower().Contains(searchText) ||
                c.CpuModel.ToLower().Contains(searchText)) },
            { typeof(Gpu), searchText => (Func<Gpu, bool>)(c =>
                c.GpuBrand.ToLower().Contains(searchText) ||
                c.GpuModel.ToLower().Contains(searchText)) },
            { typeof(Mboard), searchText => (Func<Mboard, bool>)(c =>
                c.MboardBrand.ToLower().Contains(searchText) ||
                c.MboardModel.ToLower().Contains(searchText)) },
            { typeof(PowerSup), searchText => (Func<PowerSup, bool>)(c =>
                c.PowerSupBrand.ToLower().Contains(searchText) ||
                c.PowerSupModel.ToLower().Contains(searchText) ||
                c.PowerSupEfficincy.ToLower().Contains(searchText)) },
            { typeof(Ram), searchText => (Func<Ram, bool>)(c =>
                c.RamBrand.ToLower().Contains(searchText) ||
                c.RamModel.ToLower().Contains(searchText) ||
                c.RamType.ToLower().Contains(searchText)) },
            { typeof(Storage), searchText => (Func<Storage, bool>)(c =>
                c.StorageBrand.ToLower().Contains(searchText) ||
                c.StorageModel.ToLower().Contains(searchText) ||
                c.StorageType.ToLower().Contains(searchText)) }
        };

        public MainWindow()
        {
            InitializeComponent();
            InitializeLoadButtons();
        }

        private void InitializeLoadButtons()
        {
            loadButtons = new List<Button> { buttonCase, cpuButton, gpuButton, mBoardButton, powerSupButton, ramButton, storageButton };

            buttonCase.Tag = "CCase";
            cpuButton.Tag = "Cpu";
            gpuButton.Tag = "Gpu";
            mBoardButton.Tag = "Mboard";
            powerSupButton.Tag = "PowerSup";
            ramButton.Tag = "Ram";
            storageButton.Tag = "Storage";

            foreach (var btn in loadButtons)
            {
                btn.Click += LoadDataButton_Click;
            }
        }

        private void LoadData<T>() where T : class
        {
            outputGrid.ItemsSource = context.Set<T>().ToList();
            currentType = typeof(T);
        }

        private void LoadDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton && clickedButton.Tag is string tag)
            {
                if (_typeMapping.TryGetValue(tag, out var type))
                {
                    var method = this.GetType().GetMethod("LoadData", BindingFlags.NonPublic | BindingFlags.Instance);
                    var genericMethod = method.MakeGenericMethod(type);
                    genericMethod.Invoke(this, null);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            if (currentType == null)
            {
                return;
            }

            var method = this.GetType().GetMethod("LoadData", BindingFlags.NonPublic | BindingFlags.Instance);
            var genericMethod = method.MakeGenericMethod(currentType);

            if (string.IsNullOrEmpty(searchText))
            {
                genericMethod.Invoke(this, new object[] { null });
            }
            else
            {
                if (_searchPredicates.TryGetValue(currentType, out var predicateFactory))
                {
                    var predicate = predicateFactory(searchText);
                    genericMethod.Invoke(this, new object[] { predicate });
                }
            }
        }

        private void RowEdit(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                outputGrid.RowEditEnding -= RowEdit;

                try
                {
                    outputGrid.CommitEdit(DataGridEditingUnit.Row, true);

                    if (e.Row.Item is CCase updatedCase)
                    {
                        context.Update(updatedCase);
                    }
                    else if (e.Row.Item is Cpu updatedCpu)
                    {
                        context.Update(updatedCpu);
                    }
                    else if (e.Row.Item is Gpu updatedGpu)
                    {
                        context.Update(updatedGpu);
                    }
                    else if (e.Row.Item is Mboard updatedMboard)
                    {
                        context.Update(updatedMboard);
                    }
                    else if (e.Row.Item is PowerSup updatedPowerSup)
                    {
                        context.Update(updatedPowerSup);
                    }
                    else if (e.Row.Item is Ram updatedRam)
                    {
                        context.Update(updatedRam);
                    }
                    else if (e.Row.Item is Storage updatedStorage)
                    {
                        context.Update(updatedStorage);
                    }

                    context.SaveChanges();
                }
                finally
                {
                    outputGrid.RowEditEnding += RowEdit;
                }
            }
        }

        private void DellMethod<T>() where T : class
        {
            if (outputGrid.SelectedItem is T selectedItem && outputGrid.ItemsSource is List<T> items)
            {
                outputGrid.ItemsSource = AddDellClass.DellRow(items, selectedItem, context);
            }
        }

        private void AddMethod<T>() where T : class, new()
        {
            if (outputGrid.ItemsSource is List<T> items)
            {
                var newItem = new T();
                context.Set<T>().Add(newItem);
                context.SaveChanges();

                LoadData<T>();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentType == typeof(CCase))
            {
                AddMethod<CCase>();
            }
            else if (currentType == typeof(Cpu))
            {
                AddMethod<Cpu>();
            }
            else if (currentType == typeof(Gpu))
            {
                AddMethod<Gpu>();
            }
            else if (currentType == typeof(Mboard))
            {
                AddMethod<Mboard>();
            }
            else if (currentType == typeof(PowerSup))
            {
                AddMethod<PowerSup>();
            }
            else if (currentType == typeof(Ram))
            {
                AddMethod<Ram>();
            }
            else if (currentType == typeof(Storage))
            {
                AddMethod<Storage>();
            }
        }

        private void dellButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentType == typeof(CCase))
            {
                DellMethod<CCase>();
            }
            else if (currentType == typeof(Cpu))
            {
                DellMethod<Cpu>();
            }
            else if (currentType == typeof(Gpu))
            {
                DellMethod<Gpu>();
            }
            else if (currentType == typeof(Mboard))
            {
                DellMethod<Mboard>();
            }
            else if (currentType == typeof(PowerSup))
            {
                DellMethod<PowerSup>();
            }
            else if (currentType == typeof(Ram))
            {
                DellMethod<Ram>();
            }
            else if (currentType == typeof(Storage))
            {
                DellMethod<Storage>();
            }
        }
    }
}