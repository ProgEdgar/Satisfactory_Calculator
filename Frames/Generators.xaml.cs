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
    /// Interaction logic for Generators.xaml
    /// </summary>
    public partial class Generators : Page
    {

        private MainWindow Main = null;
        private List<Generator> All_Generators = new List<Generator>();
        private List<Generator> My_Generators = new List<Generator>();
        public Generators(MainWindow mainWindow)
        {
            InitializeComponent();
            this.Main = mainWindow;
            GetLists();
            AddComboBoxInfo();
        }

        private void AllGeneratorsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListViewAllGenerators();
        }

        private void MyGeneratorsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListViewMyGenerators();
        }

        private void ListViewMyBuildings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewMyGenerators.SelectedItem != null)
            {
                dynamic Item = ListViewMyGenerators.SelectedItem;
                TBPercentage.Text = Item.TBWorking;
            }
            else
            {
                TBPercentage.Text = "";
            }
        }

        private void BtnAddBuilding_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewAllGenerators.SelectedItem != null)
            {
                dynamic Item = ListViewAllGenerators.SelectedItem;

                foreach (Generator generator in All_Generators)
                {
                    if (generator.Id == Item.LVGeneratorId)
                    {
                        Generator myNewGenerator = new Generator(generator);
                        My_Generators.Add(myNewGenerator);
                        AddComboBoxMyInfo();
                        break;
                    }
                }
            }
        }

        private void BtnRemoveBuilding_Click(object sender, RoutedEventArgs e)
        {
            dynamic Divide = CBMyDivided.SelectedItem;
            if (Divide.TBMyDivided == "Yes")
            {
                dynamic Item = ListViewMyGenerators.SelectedItem;
                Generator ItemToRemove = null;
                foreach (Generator generator in My_Generators)
                {
                    if (generator.PersonalId == Item.LVGeneratorPersonalId)
                    {
                        ItemToRemove = generator;
                    }
                }
                if (ItemToRemove != null)
                {
                    My_Generators.Remove(ItemToRemove);
                    AddComboBoxMyInfo();
                }
            }
        }

        private void BtnAddPercentage_Click(object sender, RoutedEventArgs e)
        {
            dynamic Divide = CBMyDivided.SelectedItem;
            if (Divide.TBMyDivided == "Yes")
            {
                int oldPercentage = Int32.Parse(TBPercentage.Text.ToString().Replace("%", ""));
                int newPercentage = oldPercentage + 1;
                ChangeItemPercentage(newPercentage, oldPercentage);
            }
        }

        private void BtnRemovePercentage_Click(object sender, RoutedEventArgs e)
        {
            dynamic Divide = CBMyDivided.SelectedItem;
            if (Divide.TBMyDivided == "Yes")
            {
                int oldPercentage = Int32.Parse(TBPercentage.Text.ToString().Replace("%", ""));
                int newPercentage = oldPercentage - 1;
                ChangeItemPercentage(newPercentage, oldPercentage);
            }
        }


        /*************************************************************** Other Functions ***************************************************************/

        private void ChangeItemPercentage(int newPercentage, int oldPercentage)
        {
            if (CBMyBuilding.SelectedItem != null && ListViewMyGenerators.SelectedItem != null)
            {
                dynamic DivideItem = CBMyDivided.SelectedItem;
                if (newPercentage > 0 && newPercentage <= 100)
                {
                    dynamic Item = ListViewMyGenerators.SelectedItem;

                    int ItemPersonalId = Item.LVGeneratorPersonalId;
                    int ItemPercentage = Int32.Parse(Item.TBWorking.Replace("%", ""));

                    if (ItemPersonalId >= 0 && ItemPercentage >= 0)
                    {
                        bool done = false;
                        foreach (Generator generator in My_Generators)
                        {
                            if (generator.PersonalId == ItemPersonalId && generator.Percentage == oldPercentage && !done)
                            {
                                generator.Percentage = newPercentage;
                                Item.TBWorking = newPercentage + "%";
                                ListViewMyGenerators.SelectedItem = Item;
                            }
                        }
                        TBPercentage.Text = newPercentage + "%";
                    }
                }
            }
        }

        private void AddComboBoxInfo()
        {
            CBBuilding.Items.Clear();

            /*************************************************************** Prepare Info ***************************************************************/
            string imgBuildingPath = "/Img/Img_Building/";

            List<string> AllDBuildings = new List<string>();

            AllDBuildings.Add("All");

            /*************************************************************** ComboBoxes AllBuildings ***************************************************************/
            foreach (Generator generator in All_Generators)
            {
                AllDBuildings.Add(generator.Building);
            }

            List<string> AllBuildings = RemoveDuplicated(AllDBuildings);

            foreach (string building in AllBuildings)
            {
                string Iv_building = (building != null ? imgBuildingPath + building.Replace(".", "_") + ".png" : null);
                string Tb_building = building;

                dynamic item = new ExpandoObject();
                item.IVBuilding = Iv_building;
                item.TBBuilding = Tb_building;
                CBBuilding.Items.Add(item);
            }

            /*************************************************************** Change Index ***************************************************************/

            CBBuilding.SelectedIndex = 0;
        }

        private void AddComboBoxMyInfo()
        {
            CBMyBuilding.Items.Clear();

            /*************************************************************** Prepare Info ***************************************************************/
            string imgBuildingPath = "/Img/Img_Building/";

            List<string> AllMyDBuildings = new List<string>();

            AllMyDBuildings.Add("All");

            /*************************************************************** ComboBoxes MyBuildings ***************************************************************/
            foreach (Generator generator in My_Generators)
            {
                AllMyDBuildings.Add(generator.Building);
            }

            List<string> AllMyBuildings = RemoveDuplicated(AllMyDBuildings);

            foreach (string building in AllMyBuildings)
            {
                string Iv_building = (building != null ? imgBuildingPath + building.Replace(".", "_") + ".png" : null);
                string Tb_building = building;

                dynamic item = new ExpandoObject();

                item.IVMyBuilding = Iv_building;
                item.TBMyBuilding = Tb_building;

                CBMyBuilding.Items.Add(item);
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

            CBMyBuilding.SelectedIndex = 0;
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
            All_Generators.Clear();
            My_Generators.Clear();
            string AllGeneratorsJson = Main.GetAllGenerators();
            if (AllGeneratorsJson != null)
            {
                AllGeneratorsJson = AllGeneratorsJson.Replace(",{", "{").Replace("[", "").Replace("]", "");
                Array AllGeneratorsArray = AllGeneratorsJson.Replace("{", "").Split('}');
                foreach (string item in AllGeneratorsArray)
                {
                    if (item != null && item != "")
                    {
                        string g_item = '{' + item + '}';
                        //Console.WriteLine(p_item);
                        dynamic dynamic_Item = JsonConvert.DeserializeObject<dynamic>(g_item);
                        Generator generator = new Generator(dynamic_Item);
                        All_Generators.Add(generator);
                    }
                }
            }
            string MyGeneratorsJson = Main.GetMyGenerators();
            if (MyGeneratorsJson != null)
            {
                MyGeneratorsJson = MyGeneratorsJson.Replace(",{", "").Replace("[", "").Replace("]", "");
                Array MyGeneratorsArray = MyGeneratorsJson.Replace("{", "").Split('}');
                foreach (string item in MyGeneratorsArray)
                {
                    if (item != null && item != "")
                    {
                        string g_item = '{' + item + '}';
                        Generator generator = JsonConvert.DeserializeObject<Generator>(g_item);
                        My_Generators.Add(generator);
                    }
                }
            }
        }

        private void UpdateListViewAllGenerators()
        {
            if (CBBuilding.SelectedItem == null)
                CBBuilding.SelectedIndex = 0;

            dynamic cb_building = CBBuilding.SelectedItem;

            ListViewAllGenerators.Items.Clear();
            foreach (Generator generator in All_Generators)
            {
                if (generator.Building == cb_building.TBBuilding || cb_building.TBBuilding == "All")
                {
                    CreateListItemView(ListViewAllGenerators, generator, 1);
                }
            }
        }

        private void UpdateListViewMyGenerators()
        {
            if (CBMyBuilding.Items.Count > 0 && CBMyDivided.Items.Count > 0)
            {
                if (CBMyBuilding.SelectedItem == null)
                    CBMyBuilding.SelectedIndex = 0;
                if (CBMyDivided.SelectedItem == null)
                    CBMyDivided.SelectedIndex = 0;

                List<Generator> yesItems = new List<Generator>();

                dynamic cb_building = CBMyBuilding.SelectedItem;

                ListViewMyGenerators.Items.Clear();
                if (My_Generators != null)
                {
                    foreach (Generator generator in My_Generators)
                    {
                        dynamic Divide = CBMyDivided.SelectedItem;
                        bool Exist = false;
                        if (yesItems != null && Divide.TBMyDivided == "No")
                        {
                            foreach (Generator yes_item in yesItems)
                            {
                                if (generator.Id == yes_item.Id && generator.Percentage == yes_item.Percentage)
                                    Exist = true;
                            }
                        }
                        yesItems.Add(generator);

                        if (!Exist)
                        {
                            int Quantity = 1;
                            if (Divide.TBMyDivided == "No")
                            {
                                Quantity = 0;
                                foreach (Generator generator_q in My_Generators)
                                {
                                    if (generator.Id == generator_q.Id && generator.Percentage == generator_q.Percentage)
                                        Quantity++;
                                }
                            }
                            if (generator.Building == cb_building.TBMyBuilding || cb_building.TBMyBuilding == "All")
                                CreateListItemView(ListViewMyGenerators, generator, Quantity);
                        }
                    }
                }
            }
        }

        private void CreateListItemView(ListView listView, Generator generator, int Quantity)
        {
            string imgBuildingPath = "/Img/Img_Building/";
            string imgItemPath = "/Img/Img_Item/";
            string building = generator.Building;
            string produce = generator.Main_Material;
            string require1 = generator.In_Material_1;
            string require2 = generator.In_Material_2;

            string Iv_building = (building != null ? imgBuildingPath + building.Replace(".", "_") + ".png" : null);
            string Iv_produce = (produce != null ? imgItemPath + produce.Replace(".", "_") + ".png" : null);
            string Iv_require1 = (require1 != null ? imgItemPath + require1.Replace(".", "_") + ".png" : null);
            string Iv_require2 = (require2 != null ? imgItemPath + require2.Replace(".", "_") + ".png" : null);

            string Tb_building = Quantity + " * ";
            string Tb_name = generator.Name;
            string Tb_working = generator.Percentage + "%";
            string Tb_produce = (produce != null ? generator.Main_Material_Quantity + " * " : null);
            string Tb_require1 = (require1 != null ? generator.In_Material_Quantity_1 + " * " : null);
            string Tb_require2 = (require2 != null ? generator.In_Material_Quantity_2 + " * " : null);

            string Sp_produce = (produce != null ? "Visible" : "Hidden");
            string Sp_require1 = (require1 != null ? "Visible" : "Hidden");
            string Sp_require2 = (require2 != null ? "Visible" : "Hidden");

            string H_produce = (produce != null ? "auto" : "0");
            string H_require1 = (require1 != null ? "auto" : "0");
            string H_require2 = (require2 != null ? "auto" : "0");

            if (Tb_name != null)
            {
                dynamic newItem = new ExpandoObject();
                newItem.LVObject = generator;
                newItem.LVGeneratorId = generator.Id;
                newItem.LVGeneratorPersonalId = generator.PersonalId;

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
