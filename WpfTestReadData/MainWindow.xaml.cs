using ModbusUber;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTestReadData.Model;

using UberDLMX;

namespace WpfTestReadData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private ObservableCollection<Graph> details;
        private ReadDataService.ReadDataClient readDataClient = new ReadDataService.ReadDataClient("BasicHttpBinding_IReadData");
        private UberDLMX.DLMX dLMX = new UberDLMX.DLMX();
        private DataTable objdataTableWriteDLMX;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string _societyID = txtHouseID.Text.Trim();
                if (readDataClient != null)
                {
                    DataTable objHouseDetailsdataTable = new DataTable();
                    objHouseDetailsdataTable = readDataClient.GetHouseDetails();
                    //objHouseDetailsdataTable = readDataClient.GetHousdetails(_societyID);
                    //WriteTableStruct();
                    //ReadHousedetails(objHouseDetailsdataTable);

                    var graph = new ObservableCollection<Graph>();
                    foreach (DataRow row in objHouseDetailsdataTable.Rows)
                    {
                        graph.Add(new Graph()
                        {
                            SiD = (string)row["SiD"],
                            HiD = (string)row["HiD"],
                            MiD = (string)row["MiD"],
                            PiD = (Int16)row["Pid"],
                            //metersetting = (string)row["metersetting"],
                            IPAddress = (string)row["IPAddress"],
                            Port = (string)row["Port"],
                        });
                    }
                    houseDetailsGrid.ItemsSource = graph;
                    houseDetailsGrid.AutoGenerateColumns = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                readDataClient = null;
                dLMX = null;
            }

        }

        public void ReadHousedetails(DataTable objReadHousedataTable)
        {
            try
            {
                //var graph = new ObservableCollection<Graph>();   int columnIndex = dataTable.Columns.Count;
                if (objReadHousedataTable != null && objReadHousedataTable.Rows.Count > 0)
                {
                    foreach (DataRow datarowItem in objReadHousedataTable.Rows)
                    {
                        var _soceityID = datarowItem.Field<string>("SiD");
                        var _houseID = datarowItem.Field<string>("HiD");
                        var _meterID = datarowItem.Field<string>("MiD");
                        var _meterType = Convert.ToInt16(datarowItem.Field<Int16>("PiD"));
                        var _meterSettings = datarowItem.Field<string>("metersetting");
                        var _ipAddress = datarowItem.Field<string>("IPAddress");
                        var _port = Convert.ToInt32(datarowItem.Field<string>("Port"));
                        if (_meterType == 3)
                        {
                            Modbus itembus = Newtonsoft.Json.JsonConvert.DeserializeObject<Modbus>(_meterSettings);
                            if (itembus != null && itembus.RiD.Length > 0 && itembus.Address.Length > 0)
                            {
                                var _regType = Convert.ToInt32(itembus.RiD);
                                var _startAddress = Convert.ToInt32(itembus.Address);
                                var _qty = itembus.Quantity;
                                var _deviceID = itembus.DeviceID;

                                int[] readHoldingRegisters = ModbusReading.ReadingRegister(_ipAddress, _port, _startAddress, _regType);//ReadModbus(_ipAddress, _port, _startAddress, _regType);

                                if (readHoldingRegisters != null && readHoldingRegisters.Length > 0)
                                {
                                    objdataTableWriteDLMX.Rows.Add(_soceityID, _houseID, _meterID, _ipAddress, _port, readHoldingRegisters);
                                }
                            }
                        }
                        else
                        {
                            DLMX itemdLMX = Newtonsoft.Json.JsonConvert.DeserializeObject<DLMX>(_meterSettings);
                            if (itemdLMX != null && itemdLMX.Manufacturer.Length > 0 && itemdLMX.Model.Length > 0)
                            {
                                var manufacture = itemdLMX.Manufacturer;
                                var model = itemdLMX.Model;
                                var importExport = Convert.ToInt16(itemdLMX.ImportExport);

                                string[] readDLMX = dLMX.DLMXRead(_ipAddress, _port);//manufacture, model, importExport { "12", "12", "454" };

                                if (readDLMX != null && readDLMX.Length > 0)
                                {
                                    objdataTableWriteDLMX.Rows.Add(_soceityID, _houseID, _meterID, _ipAddress, _port, readDLMX);
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                objdataTableWriteDLMX = null;
            }
        }

        public void WriteTableStruct()
        {
            try
            {
                if (objdataTableWriteDLMX == null)
                {
                    objdataTableWriteDLMX = new DataTable();
                    objdataTableWriteDLMX.TableName = "WrireHouseDetails";
                    objdataTableWriteDLMX.Columns.Add("SiD", typeof(string));
                    objdataTableWriteDLMX.Columns.Add("HiD", typeof(string));
                    objdataTableWriteDLMX.Columns.Add("MiD", typeof(string));
                    objdataTableWriteDLMX.Columns.Add("IPAddress", typeof(string));
                    objdataTableWriteDLMX.Columns.Add("Port", typeof(string));
                    objdataTableWriteDLMX.Columns.Add("Reading", typeof(string));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //public void ReadModbus(string _ipAddress, int _port, int _startingAddress, int _typeOfReading)
        //{
        //    try
        //    {
        //        int[] readHoldingRegisters = ModbusReading.ReadingRegister(_ipAddress, _port, _startingAddress, _typeOfReading);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        //public void ReadDLMX(string _societyID, string _houseID, string _meterID, string _ipAddress, int _port, string _manufacture, string _model, int _importExport)
        //{
        //    try
        //    {
        //        UberDLMX.DLMX dLMX = new UberDLMX.DLMX();
        //        string[] readDLMX = dLMX.DLMXRead(_ipAddress, _port, _manufacture, _model, _importExport);

        //        if(readDLMX !=null && readDLMX.Length > 0)
        //        {                   
        //            dataTablesummary.Columns.Add("SiD", typeof(decimal));
        //            dataTablesummary.Columns.Add("HiD", typeof(decimal));
        //            dataTablesummary.Columns.Add("MiD", typeof(decimal));
        //            dataTablesummary.Columns.Add("IP Address", typeof(decimal));
        //            dataTablesummary.Columns.Add("Port", typeof(decimal));
        //            dataTablesummary.Columns.Add("Reading", typeof(string));                 
        //            dataTablesummary.Rows.Add(_societyID, _houseID, _meterID, _ipAddress, _port, readDLMX[0]);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        #region
        private void dataGridStudent_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void dataGridStudent_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void dataGridStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)//siMaximized)
            {
                WindowState = WindowState.Normal;
            }
        }
        #endregion
    }
}
