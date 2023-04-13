using Newtonsoft.Json;
using Satisfactory_Calculator.Class_Files;
using System;
using System.Collections.Generic;
using System.Dynamic;
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

namespace Satisfactory_Calculator
{
    /// <summary>
    /// Interaction logic for Vehicles.xaml
    /// </summary>
    public partial class Vehicles : Page
    {
        private MainWindow Main = null;
        private List<Vehicle> All_Vehicles = new List<Vehicle>();
        private List<Vehicle> My_Vehicles = new List<Vehicle>();
        public Vehicles(MainWindow mainWindow)
        {
            InitializeComponent();
            this.Main = mainWindow;
            GetLists();
            AddComboBoxInfo();
        }

        private void AllVehiclesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListViewAllVehicles();
        }

        private void MyVehiclesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListViewMyVehicles();
        }

        private void BtnAddVehicle_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewAllVehicles.SelectedItem != null)
            {
                dynamic Item = ListViewAllVehicles.SelectedItem;

                foreach (Vehicle vehicle in All_Vehicles)
                {
                    if (vehicle.Id == Item.LVVehicleId)
                    {
                        Vehicle myNewVehicle = new Vehicle(vehicle);
                        My_Vehicles.Add(myNewVehicle);
                        AddComboBoxMyInfo();
                        break;
                    }
                }
            }
        }

        private void BtnRemoveVehicle_Click(object sender, RoutedEventArgs e)
        {
            dynamic Divide = CBMyDivided.SelectedItem;
            if (Divide.TBMyDivided == "Yes")
            {
                dynamic Item = ListViewMyVehicles.SelectedItem;
                Vehicle ItemToRemove = null;
                foreach (Vehicle vehicle in My_Vehicles)
                {
                    if (vehicle.PersonalId == Item.LVVehiclePersonalId)
                    {
                        ItemToRemove = vehicle;
                    }
                }
                if (ItemToRemove != null)
                {
                    My_Vehicles.Remove(ItemToRemove);
                    AddComboBoxMyInfo();
                }
            }
        }


        /*************************************************************** Other Functions ***************************************************************/


        private void AddComboBoxInfo()
        {
            CBVehicle.Items.Clear();

            /*************************************************************** Prepare Info ***************************************************************/
            string imgBuildingPath = "/Img/Img_Building/";

            List<string> AllDVehicles = new List<string>();

            AllDVehicles.Add("All");

            /*************************************************************** ComboBoxes AllBuildings ***************************************************************/
            foreach (Vehicle vehicle in All_Vehicles)
            {
                AllDVehicles.Add(vehicle.Vehicle_Name);
            }

            List<string> AllBuildings = RemoveDuplicated(AllDVehicles);

            foreach (string building in AllBuildings)
            {
                string Iv_building = (building != null ? imgBuildingPath + building.Replace(".", "_") + ".png" : null);
                string Tb_building = building;

                dynamic item = new ExpandoObject();
                item.IVBuilding = Iv_building;
                item.TBBuilding = Tb_building;
                CBVehicle.Items.Add(item);
            }

            /*************************************************************** Change Index ***************************************************************/

            CBVehicle.SelectedIndex = 0;
        }

        private void AddComboBoxMyInfo()
        {
            CBMyVehicle.Items.Clear();

            /*************************************************************** Prepare Info ***************************************************************/
            string imgBuildingPath = "/Img/Img_Building/";

            List<string> AllMyDBuildings = new List<string>();

            AllMyDBuildings.Add("All");

            /*************************************************************** ComboBoxes MyBuildings ***************************************************************/
            foreach (Vehicle vehicle in My_Vehicles)
            {
                AllMyDBuildings.Add(vehicle.Building);
            }

            List<string> AllMyBuildings = RemoveDuplicated(AllMyDBuildings);

            foreach (string building in AllMyBuildings)
            {
                string Iv_building = (building != null ? imgBuildingPath + building.Replace(".", "_") + ".png" : null);
                string Tb_building = building;

                dynamic item = new ExpandoObject();

                item.IVMyBuilding = Iv_building;
                item.TBMyBuilding = Tb_building;

                CBMyVehicle.Items.Add(item);
            }
            if (CBMyDivided.Items.Count <= 0)
            {
                CBMyDivided.Items.Clear();

                dynamic yes_item = new ExpandoObject();
                yes_item.TBMyDivided = "Yes";
                dynamic no_item = new ExpandoObject();
                no_item.TBMyDivided = "No";

                CBMyDivided.Items.Add(yes_item);
                CBMyDivided.Items.Add(no_item);

                CBMyDivided.SelectedIndex = 0;
            }

            /*************************************************************** Change Index ***************************************************************/

            CBMyVehicle.SelectedIndex = 0;
        }

        private List<string> RemoveDuplicated(List<string> AllStrings)
        {
            List<string> NoDuplicates = new List<string>();
            if (AllStrings != null)
            {
                foreach (string duplicated in AllStrings)
                {
                    if (NoDuplicates != null)
                    {
                        bool Exists = false;
                        foreach (string notDuplicated in NoDuplicates)
                        {
                            if (notDuplicated == duplicated)
                                Exists = true;
                        }
                        if (!Exists && duplicated != null)
                            NoDuplicates.Add(duplicated);
                    }
                    else
                    {
                        if (duplicated != null)
                            NoDuplicates.Add(duplicated);
                    }
                }
            }
            return NoDuplicates;
        }

        private void GetLists()
        {
            All_Vehicles.Clear();
            My_Vehicles.Clear();
            string AllVehiclesJson = Main.GetAllVehicles();
            if (AllVehiclesJson != null)
            {
                AllVehiclesJson = AllVehiclesJson.Replace(",{", "{").Replace("[", "").Replace("]", "");
                Array AllVehiclesArray = AllVehiclesJson.Replace("{", "").Split('}');
                foreach (string item in AllVehiclesArray)
                {
                    if (item != null && item != "")
                    {
                        string g_item = '{' + item + '}';
                        //Console.WriteLine(p_item);
                        dynamic dynamic_Item = JsonConvert.DeserializeObject<dynamic>(g_item);
                        Vehicle vehicle = new Vehicle(dynamic_Item);
                        All_Vehicles.Add(vehicle);
                    }
                }
            }
            string MyVehiclesJson = Main.GetMyVehicles();
            if (MyVehiclesJson != null)
            {
                MyVehiclesJson = MyVehiclesJson.Replace(",{", "").Replace("[", "").Replace("]", "");
                Array MyVehiclesArray = MyVehiclesJson.Replace("{", "").Split('}');
                foreach (string item in MyVehiclesArray)
                {
                    if (item != null && item != "")
                    {
                        string g_item = '{' + item + '}';
                        Vehicle vehicle = JsonConvert.DeserializeObject<Vehicle>(g_item);
                        My_Vehicles.Add(vehicle);
                    }
                }
            }
        }

        private void UpdateListViewAllVehicles()
        {
            if (CBVehicle.SelectedItem == null)
                CBVehicle.SelectedIndex = 0;

            dynamic cb_building = CBVehicle.SelectedItem;

            ListViewAllVehicles.Items.Clear();
            foreach (Vehicle vehicle in All_Vehicles)
            {
                if (vehicle.Vehicle_Name == cb_building.TBBuilding || cb_building.TBBuilding == "All")
                {
                    CreateListItemView(ListViewAllVehicles, vehicle, 1);
                }
            }
        }

        private void UpdateListViewMyVehicles()
        {
            if (CBMyVehicle.Items.Count > 0 && CBMyDivided.Items.Count > 0)
            {
                if (CBMyVehicle.SelectedItem == null)
                    CBMyVehicle.SelectedIndex = 0;
                if (CBMyDivided.SelectedItem == null)
                    CBMyDivided.SelectedIndex = 0;

                List<Vehicle> yesItems = new List<Vehicle>();

                dynamic cb_building = CBMyVehicle.SelectedItem;

                ListViewMyVehicles.Items.Clear();
                if (My_Vehicles != null)
                {
                    foreach (Vehicle vehicle in My_Vehicles)
                    {
                        dynamic Divide = CBMyDivided.SelectedItem;
                        bool Exist = false;
                        if (yesItems != null && Divide.TBMyDivided == "No")
                        {
                            foreach (Vehicle yes_item in yesItems)
                            {
                                if (vehicle.Id == yes_item.Id)
                                    Exist = true;
                            }
                        }
                        yesItems.Add(vehicle);

                        if (!Exist)
                        {
                            int Quantity = 1;
                            if (Divide.TBMyDivided == "No")
                            {
                                Quantity = 0;
                                foreach (Vehicle vehicle_q in My_Vehicles)
                                {
                                    if (vehicle.Id == vehicle_q.Id)
                                        Quantity++;
                                }
                            }
                            if (vehicle.Vehicle_Name == cb_building.TBMyBuilding || cb_building.TBMyBuilding == "All")
                                CreateListItemView(ListViewMyVehicles, vehicle, Quantity);
                        }
                    }
                }
            }
        }

        private void CreateListItemView(ListView listView, Vehicle vehicle, int Quantity)
        {
            string imgBuildingPath = "/Img/Img_Building/";
            string imgItemPath = "/Img/Img_Item/";
            string building = vehicle.Building;
            string produce = vehicle.Main_Material;
            string require1 = vehicle.In_Material_1;
            string require2 = vehicle.In_Material_2;

            string Iv_building = (building != null ? imgBuildingPath + building.Replace(".", "_") + ".png" : null);
            string Iv_produce = (produce != null ? imgItemPath + produce.Replace(".", "_") + ".png" : null);
            string Iv_require1 = (require1 != null ? imgItemPath + require1.Replace(".", "_") + ".png" : null);
            string Iv_require2 = (require2 != null ? imgItemPath + require2.Replace(".", "_") + ".png" : null);

            string Tb_building = Quantity + " * ";
            string Tb_name = vehicle.Name;
            string Tb_working = vehicle.Percentage + "%";
            string Tb_produce = (produce != null ? vehicle.Main_Material_Quantity + " * " : null);
            string Tb_require1 = (require1 != null ? vehicle.In_Material_Quantity_1 + " * " : null);
            string Tb_require2 = (require2 != null ? vehicle.In_Material_Quantity_2 + " * " : null);

            string Sp_produce = (produce != null ? "Visible" : "Hidden");
            string Sp_require1 = (require1 != null ? "Visible" : "Hidden");
            string Sp_require2 = (require2 != null ? "Visible" : "Hidden");

            string H_produce = (produce != null ? "auto" : "0");
            string H_require1 = (require1 != null ? "auto" : "0");
            string H_require2 = (require2 != null ? "auto" : "0");

            if (Tb_name != null)
            {
                dynamic newItem = new ExpandoObject();
                newItem.LVObject = vehicle;
                newItem.LVVehicleId = vehicle.Id;
                newItem.LVVehiclePersonalId = vehicle.PersonalId;

                newItem.IVBuilding = Iv_building;
                newItem.IVProduce = Iv_produce;
                newItem.IVRequire1 = Iv_require1;
                newItem.IVRequire2 = Iv_require2;

                newItem.TBBuilding = Tb_building;
                newItem.TBName = Tb_name;
                newItem.TBWorking = Tb_working;
                newItem.TBProduce = Tb_produce;
                newItem.TBRequire1 = Tb_require1;
                newItem.TBRequire2 = Tb_require2;

                newItem.SPProduce = Sp_produce;
                newItem.SPRequire1 = Sp_require1;
                newItem.SPRequire2 = Sp_require2;

                newItem.HProduce = H_produce;
                newItem.HRequire1 = H_require1;
                newItem.HRequire2 = H_require2;

                listView.Items.Add(newItem);
            }
        }
    }
}