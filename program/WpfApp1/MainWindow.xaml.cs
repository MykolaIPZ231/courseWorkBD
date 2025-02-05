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
        CourseWorkContext context = new CourseWorkContext();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void ReloadDataFromCurrTable()
        {
            if (outputGrid.ItemsSource is List<CCase>)
            {
                ReloadData<CCase>();
            }
            else if (outputGrid.ItemsSource is List<Cpu>)
            {
                ReloadData<Cpu>();
            }
            else if (outputGrid.ItemsSource is List<Gpu>)
            {
                ReloadData<Gpu>();
            }
            else if (outputGrid.ItemsSource is List<Mboard>)
            {
                ReloadData<Mboard>();
            }
            else if (outputGrid.ItemsSource is List<PowerSup>)
            {
                ReloadData<PowerSup>();
            }
            else if (outputGrid.ItemsSource is List<Ram>)
            {
                ReloadData<Ram>();
            }
            else if (outputGrid.ItemsSource is List<Storage>)
            {
                ReloadData<Storage>();
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

        private void ReloadData<T>() where T : class
        {
            outputGrid.ItemsSource = AddDellClass.ReloadCurrentData<T>(context);
        }
        private void DellMethod<T>() where T : class
        {
            if(outputGrid.SelectedItem is T selectedItem && outputGrid.ItemsSource is List<T> items)
            {
                outputGrid.ItemsSource = AddDellClass.DellRow(items, selectedItem, context);
            }
        }
        private void AddMethod<T>() where T : class, new()
        {
            if(outputGrid.ItemsSource is List<T> items)
            {
                var newItem = new T();
                context.Set<T>().Add(newItem);
                context.SaveChanges();

                ReloadData<T>();
            }
        }

        private void buttonCase_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<CCase>();
            List<CCase> Ccase = context.CCases.ToList();
            outputGrid.ItemsSource = Ccase;
        }

        private void cpuButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<Cpu>();
            List<Cpu> cpu = context.Cpus.ToList();
            outputGrid.ItemsSource = cpu;
        }

        private void gpuButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<Gpu>();
            List<Gpu> gpu = context.Gpus.ToList();
            outputGrid.ItemsSource = gpu;
        }

        private void mBoardButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<Mboard>();
            List<Mboard> mBoard = context.Mboards.ToList();
            outputGrid.ItemsSource = mBoard;
        }

        private void powerSupButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<PowerSup>();
            List<PowerSup> powerSup = context.PowerSups.ToList();
            outputGrid.ItemsSource = powerSup;
        }

        private void ramButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<Ram>();
            List<Ram> ram = context.Rams.ToList();
            outputGrid.ItemsSource = ram;
        }

        private void storageButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadData<Storage>();
            List<Storage> storage = context.Storages.ToList();
            outputGrid.ItemsSource = storage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            if (outputGrid.ItemsSource is List<CCase> cases)
            {
                outputGrid.ItemsSource = cases.Where(c =>
                    c.CaseBrand.ToLower().Contains(searchText) ||
                    c.CaseModel.ToLower().Contains(searchText) ||
                    c.CaseFormFactor.ToLower().Contains(searchText)
                    ).ToList();
            }
            else if(outputGrid.ItemsSource is List<Cpu> cpu)
            {
                outputGrid.ItemsSource = cpu.Where(c =>
                    c.CpuBrand.ToLower().Contains(searchText) ||
                    c.CpuModel.ToLower().Contains(searchText)
                ).ToList();
            }
            else if(outputGrid.ItemsSource is List<Gpu> gpu)
            {
                outputGrid.ItemsSource = gpu.Where(c =>
                    c.GpuBrand.ToLower().Contains(searchText) ||
                    c.GpuModel.ToLower().Contains(searchText)
                ).ToList();
            }
            else if(outputGrid.ItemsSource is List<Mboard> mBoard)
            {
                outputGrid.ItemsSource = mBoard.Where(c =>
                    c.MboardBrand.ToLower().Contains(searchText) ||
                    c.MboardModel.ToLower().Contains(searchText)
                ).ToList();
            }
            else if(outputGrid.ItemsSource is List<PowerSup> powerSup)
            {
                outputGrid.ItemsSource = powerSup.Where(c =>
                    c.PowerSupModel.ToLower().Contains(searchText) ||
                    c.PowerSupBrand.ToLower().Contains(searchText) ||
                    c.PowerSupEfficincy.ToLower().Contains(searchText)
                ).ToList();
            }
            else if(outputGrid.ItemsSource is List<Ram> ram)
            {
                outputGrid.ItemsSource = ram.Where(c => 
                    c.RamModel.ToLower().Contains(searchText) ||
                    c.RamBrand.ToLower().Contains(searchText) ||
                    c.RamType.ToLower().Contains(searchText)
                ).ToList();
            }
            else if(outputGrid.ItemsSource is List<Storage> storage)
            {
                outputGrid.ItemsSource = storage.Where(c =>
                    c.StorageBrand.ToLower().Contains(searchText) ||
                    c.StorageModel.ToLower().Contains(searchText) ||
                    c.StorageType.ToLower().Contains(searchText)
                    ).ToList();
            }

            if (string.IsNullOrEmpty(searchText))
            {
                if(outputGrid.ItemsSource is List<CCase>)
                {
                    buttonCase_Click(null, null);
                }
                else if(outputGrid.ItemsSource is List<Cpu>)
                {
                    cpuButton_Click(null, null);
                }
                else if(outputGrid.ItemsSource is List<Gpu>)
                {
                    gpuButton_Click(null, null);
                }
                else if(outputGrid.ItemsSource is List<Mboard>)
                {
                    mBoardButton_Click(null, null);
                }
                else if(outputGrid.ItemsSource is List<PowerSup>)
                {
                    powerSupButton_Click(null, null);
                }
                else if(outputGrid.ItemsSource is List<Ram>)
                {
                    ramButton_Click(null, null);
                }
                else if(outputGrid.ItemsSource is List<Storage>)
                {
                    storageButton_Click(null, null);
                }
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (outputGrid.ItemsSource is List<CCase>)
            {
                AddMethod<CCase>();
            }
            else if (outputGrid.ItemsSource is List<Cpu>)
            {
                AddMethod<Cpu>();
            }
            else if( outputGrid.ItemsSource is List<Gpu>)
            {
                AddMethod<Gpu>();
            }
            else if (outputGrid.ItemsSource is List<Mboard>)
            {
                AddMethod<Mboard>();
            }
            else if (outputGrid.ItemsSource is List<PowerSup>)
            {
                AddMethod<PowerSup>();
            }
            else if (outputGrid.ItemsSource is List<Ram>)
            {
                AddMethod<Ram>();
            }
            else if (outputGrid.ItemsSource is List<Storage>)
            {
                AddMethod<Storage>();
            }
        }

        private void dellButton_Click(object sender, RoutedEventArgs e)
        {
            if (outputGrid.ItemsSource is List<CCase>)
            {
                DellMethod<CCase>();
            }
            else if ( outputGrid.ItemsSource is List<Cpu>)
            {
                DellMethod<Cpu>(); 
            }
            else if (outputGrid.ItemsSource is List<Gpu>)
            {
                DellMethod<Gpu>();
            }
            else if (outputGrid.ItemsSource is List<Mboard>)
            {
                DellMethod<Mboard>();
            }
            else if (outputGrid.ItemsSource is List<PowerSup>)
            {
                DellMethod<PowerSup>();
            }
            else if (outputGrid.ItemsSource is List<Ram>)
            {
                DellMethod<Ram>();
            }
            else if (outputGrid.ItemsSource is List<Storage>)
            {
                DellMethod<Storage>();
            }
        }
    }
}