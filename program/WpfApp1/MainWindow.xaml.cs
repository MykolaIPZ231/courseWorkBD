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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private readonly CourseWorkContext _context = new CourseWorkContext();
        private readonly Dictionary<Type, Action> _reloadMethods;

        public MainWindow()
        {
            InitializeComponent();

            _reloadMethods = new Dictionary<Type, Action>
        {
            { typeof(CCase), () => ReloadData<CCase>() },
            { typeof(Cpu), () => ReloadData<Cpu>() },
            { typeof(Gpu), () => ReloadData<Gpu>() },
            { typeof(Mboard), () => ReloadData<Mboard>() },
            { typeof(PowerSup), () => ReloadData<PowerSup>() },
            { typeof(Ram), () => ReloadData<Ram>() },
            { typeof(Storage), () => ReloadData<Storage>() }
        };
        }

        private void ReloadData<T>() where T : class
        {
            outputGrid.ItemsSource = _context.Set<T>().ToList();
        }

        private void ReloadDataFromCurrTable()
        {
            var itemType = outputGrid.ItemsSource?.GetType().GetGenericArguments().FirstOrDefault();
            if (itemType != null && _reloadMethods.ContainsKey(itemType))
            {
                _reloadMethods[itemType].Invoke();
            }
        }

        private void RowEditWrapper(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                outputGrid.RowEditEnding -= RowEditWrapper;

                try
                {
                    outputGrid.CommitEdit(DataGridEditingUnit.Row, true);

                    // Отримуємо тип елемента, який редагується
                    var itemType = e.Row.Item.GetType();

                    // Викликаємо узагальнений метод через рефлексію
                    var method = typeof(MainWindow).GetMethod(nameof(RowEdit), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    var genericMethod = method.MakeGenericMethod(itemType);
                    genericMethod.Invoke(this, new object[] { sender, e });
                }
                finally
                {
                    outputGrid.RowEditEnding += RowEditWrapper;
                }
            }
        }

        private void RowEdit<T>(object sender, DataGridRowEditEndingEventArgs e) where T : class
        {
            if (e.Row.Item is T updatedItem)
            {
                _context.Update(updatedItem);
                _context.SaveChanges();
            }
        }

        private void AddMethod<T>() where T : class, new()
        {
            var newItem = new T();
            _context.Set<T>().Add(newItem);
            _context.SaveChanges();
            ReloadData<T>();
        }

        private void DellMethod<T>() where T : class
        {
            if (outputGrid.SelectedItem is T selectedItem)
            {
                _context.Set<T>().Remove(selectedItem);
                _context.SaveChanges();
                ReloadData<T>();
            }
        }

        private void SearchData<T>(string searchText, Func<T, bool> filter) where T : class
        {
            var items = _context.Set<T>().ToList();
            outputGrid.ItemsSource = items.Where(filter).ToList();
        }

        private void buttonCase_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<CCase>();
        }

        private void cpuButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<Cpu>();
        }

        private void gpuButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<Gpu>();
        }

        private void mBoardButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<Mboard>();
        }

        private void powerSupButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<PowerSup>();
        }

        private void ramButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<Ram>();
        }

        private void storageButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<Storage>();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var itemType = outputGrid.ItemsSource?.GetType().GetGenericArguments().FirstOrDefault();
            if (itemType == typeof(CCase)) AddMethod<CCase>();
            else if (itemType == typeof(Cpu)) AddMethod<Cpu>();
            else if (itemType == typeof(Gpu)) AddMethod<Gpu>();
            else if (itemType == typeof(Mboard)) AddMethod<Mboard>();
            else if (itemType == typeof(PowerSup)) AddMethod<PowerSup>();
            else if (itemType == typeof(Ram)) AddMethod<Ram>();
            else if (itemType == typeof(Storage)) AddMethod<Storage>();
        }

        private void dellButton_Click(object sender, RoutedEventArgs e)
        {
            var itemType = outputGrid.ItemsSource?.GetType().GetGenericArguments().FirstOrDefault();
            if (itemType == typeof(CCase)) DellMethod<CCase>();
            else if (itemType == typeof(Cpu)) DellMethod<Cpu>();
            else if (itemType == typeof(Gpu)) DellMethod<Gpu>();
            else if (itemType == typeof(Mboard)) DellMethod<Mboard>();
            else if (itemType == typeof(PowerSup)) DellMethod<PowerSup>();
            else if (itemType == typeof(Ram)) DellMethod<Ram>();
            else if (itemType == typeof(Storage)) DellMethod<Storage>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            var itemType = outputGrid.ItemsSource?.GetType().GetGenericArguments().FirstOrDefault();
            if (itemType == typeof(CCase))
            {
                SearchData<CCase>(searchText, c =>
                    c.CaseBrand.ToLower().Contains(searchText) ||
                    c.CaseModel.ToLower().Contains(searchText) ||
                    c.CaseFormFactor.ToLower().Contains(searchText));
            }
            else if (itemType == typeof(Cpu))
            {
                SearchData<Cpu>(searchText, c =>
                    c.CpuBrand.ToLower().Contains(searchText) ||
                    c.CpuModel.ToLower().Contains(searchText));
            }
            else if (itemType == typeof(Gpu))
            {
                SearchData<Gpu>(searchText, c =>
                    c.GpuBrand.ToLower().Contains(searchText) ||
                    c.GpuModel.ToLower().Contains(searchText));
            }
            else if (itemType == typeof(Mboard))
            {
                SearchData<Mboard>(searchText, c =>
                    c.MboardBrand.ToLower().Contains(searchText) ||
                    c.MboardModel.ToLower().Contains(searchText));
            }
            else if (itemType == typeof(PowerSup))
            {
                SearchData<PowerSup>(searchText, c =>
                    c.PowerSupBrand.ToLower().Contains(searchText) ||
                    c.PowerSupModel.ToLower().Contains(searchText) ||
                    c.PowerSupEfficincy.ToLower().Contains(searchText));
            }
            else if (itemType == typeof(Ram))
            {
                SearchData<Ram>(searchText, c =>
                    c.RamBrand.ToLower().Contains(searchText) ||
                    c.RamModel.ToLower().Contains(searchText) ||
                    c.RamType.ToLower().Contains(searchText));
            }
            else if (itemType == typeof(Storage))
            {
                SearchData<Storage>(searchText, c =>
                    c.StorageBrand.ToLower().Contains(searchText) ||
                    c.StorageModel.ToLower().Contains(searchText) ||
                    c.StorageType.ToLower().Contains(searchText));
            }

            if (string.IsNullOrEmpty(searchText))
            {
                ReloadDataFromCurrTable();
            }
        }
    }
}