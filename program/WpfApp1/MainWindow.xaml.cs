using ClassLibrary1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private readonly CourseWorkContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new CourseWorkContext();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadDataAsync<CCase>();
        }
        private async void RowEdit(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                outputGrid.RowEditEnding -= RowEdit;
                try
                {
                    outputGrid.CommitEdit(DataGridEditingUnit.Row, true);
                    _context.Entry(e.Row.Item).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                finally
                {
                    outputGrid.RowEditEnding += RowEdit;
                }
            }
        }
        private async Task LoadDataAsync<T>() where T : class
        {
            outputGrid.ItemsSource = await _context.Set<T>().ToListAsync();
        }
        private async Task AddMethodAsync<T>() where T : class, new()
        {
            var newItem = new T();
            _context.Set<T>().Add(newItem);
            await _context.SaveChangesAsync();
            await LoadDataAsync<T>();
        }
        private async Task DellMethodAsync<T>() where T : class
        {
            if (outputGrid.SelectedItem is T selectedItem)
            {
                _context.Set<T>().Remove(selectedItem);
                await _context.SaveChangesAsync();
                await LoadDataAsync<T>();
            }
        }
        private async Task SearchAsync<T>(string searchText, params Func<T, string>[] properties) where T : class
        {
            var query = _context.Set<T>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.ToLower();
                query = query.Where(item => properties.Any(prop => prop(item).ToLower().Contains(searchText)));
            }
            outputGrid.ItemsSource = await query.ToListAsync();
        }
        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchText = SearchTextBox.Text.ToLower();
            if (outputGrid.ItemsSource is List<CCase>)
                await SearchAsync(searchText, (CCase c) => c.CaseModel);
            else if (outputGrid.ItemsSource is List<Cpu>)
                await SearchAsync(searchText, (Cpu c) => c.CpuModel);
            else if (outputGrid.ItemsSource is List<Gpu>)
                await SearchAsync(searchText, (Gpu g) => g.GpuModel);
        }
        private async void buttonCase_Click(object sender, RoutedEventArgs e) => await LoadDataAsync<CCase>();
        private async void cpuButton_Click(object sender, RoutedEventArgs e) => await LoadDataAsync<Cpu>();
        private async void gpuButton_Click(object sender, RoutedEventArgs e) => await LoadDataAsync<Gpu>();
        private async void mBoardButton_Click(object sender, RoutedEventArgs e) => await LoadDataAsync<Mboard>();
        private async void powerSupButton_Click(object sender, RoutedEventArgs e) => await LoadDataAsync<PowerSup>();
        private async void ramButton_Click(object sender, RoutedEventArgs e) => await LoadDataAsync<Ram>();
        private async void storageButton_Click(object sender, RoutedEventArgs e) => await LoadDataAsync<Storage>();
        private async void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (outputGrid.ItemsSource is List<CCase>)
                await AddMethodAsync<CCase>();
            else if (outputGrid.ItemsSource is List<Cpu>)
                await AddMethodAsync<Cpu>();
            else if (outputGrid.ItemsSource is List<Gpu>)
                await AddMethodAsync<Gpu>();
        }

        private async void dellButton_Click(object sender, RoutedEventArgs e)
        {
            if (outputGrid.ItemsSource is List<CCase>)
                await DellMethodAsync<CCase>();
            else if (outputGrid.ItemsSource is List<Cpu>)
                await DellMethodAsync<Cpu>();
            else if (outputGrid.ItemsSource is List<Gpu>)
                await DellMethodAsync<Gpu>();
        }

        protected override void OnClosed(EventArgs e)
        {
            _context.Dispose();
            base.OnClosed(e);
        }
    }
}
