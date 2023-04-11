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
    /// Interaction logic for Extraction_Buildings.xaml
    /// </summary>
    public partial class Extraction_Buildings : Page
    {
        private MainWindow Main = null;
        private List<Resource_Map> All_Resources_Map = new List<Resource_Map>();
        private List<Resource_Map> My_Resources_Map = new List<Resource_Map>();
        private List<Extractor> All_Extractors = new List<Extractor>();
        public Extraction_Buildings(MainWindow mainWindow)
        {
            InitializeComponent();
            this.Main = mainWindow;
            GetLists();
            AddComboBoxInfo();
        }

        private void AllExtractionItemsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListViewAllExtractionBuildings();
        }

        private void MyExtractionItemsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListViewMyExtractionBuildings();
        }

        private void ListViewMyExtractionBuildings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewMyExtractionBuildings.SelectedItem != null)
            {
                dynamic Item = ListViewMyExtractionBuildings.SelectedItem;
                TBPercentage.Text = Item.TBWorking;
            }
            else
            {
                TBPercentage.Text = "";
            }
        }

        private void BtnAddBuilding_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewAllExtractionBuildings.SelectedItem != null)
            {
                dynamic Item = ListViewAllExtractionBuildings.SelectedItem;

                foreach (Resource_Map resource_Map in All_Resources_Map)
                {
                    if (resource_Map.Id == Item.LVResourceMapId)
                    {
                        Resource_Map myNewResourceMap = new Resource_Map(resource_Map);
                        myNewResourceMap.Extractor_Code = Item.TBBuildingCode;
                        My_Resources_Map.Add(myNewResourceMap);
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
                dynamic Item = ListViewMyExtractionBuildings.SelectedItem;
                Resource_Map ItemToRemove = null;
                foreach (Resource_Map resource_Map in My_Resources_Map)
                {
                    if (resource_Map.PersonalId == Item.LVResourceMapPersonalId)
                    {
                        ItemToRemove = resource_Map;
                    }
                }
                if (ItemToRemove != null)
                {
                    My_Resources_Map.Remove(ItemToRemove);
                    AddComboBoxMyInfo();
                }
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


        /*************************************************************** Other Functions ***************************************************************/

        private void ChangeItemPercentage(int newPercentage, int oldPercentage)
        {
            if (CBMyBuilding.SelectedItem != null && ListViewMyExtractionBuildings.SelectedItem != null)
            {
                dynamic DivideItem = CBMyDivided.SelectedItem;
                if (newPercentage > 0 && newPercentage <= 100)
                {
                    dynamic Item = ListViewMyExtractionBuildings.SelectedItem;

                    int ItemPersonalId = Item.LVResourceMapPersonalId;
                    int ItemPercentage = Int32.Parse(Item.TBWorking.Replace("%", ""));

                    if (ItemPersonalId >= 0 && ItemPercentage >= 0)
                    {
                        bool done = false;
                        foreach (Resource_Map resource_Map in My_Resources_Map)
                        {
                            if (resource_Map.PersonalId == ItemPersonalId && resource_Map.Percentage == oldPercentage && !done)
                            {
                                resource_Map.Percentage = newPercentage;
                                Item.TBWorking = newPercentage + "%";
                                ListViewMyExtractionBuildings.SelectedItem = Item;
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
            CBItem.Items.Clear();

            /*************************************************************** Prepare Info ***************************************************************/
            string imgBuildingPath = "/Img/Img_Building/";
            string imgItemPath = "/Img/Img_Item/";

            List<string> AllDBuildings = new List<string>();
            List<string> AllDItems = new List<string>();

            AllDBuildings.Add("All");
            AllDItems.Add("All");

            /*************************************************************** ComboBoxes AllBuildings ***************************************************************/
            foreach (Resource_Map resource_Map in All_Resources_Map)
            {
                string building = null;
                foreach(Extractor extractor in All_Extractors)
                {
                    if(resource_Map.Type == extractor.Type)
                    {
                        building = extractor.Building;
                        AllDBuildings.Add(building);
                    }
                    if (resource_Map.Type != 'G')
                    {
                        AllDItems.Add(resource_Map.Resource);
                    }
                }
            }

            List<string> AllBuildings = RemoveDuplicated(AllDBuildings);
            List<string> AllItems = RemoveDuplicated(AllDItems);

            foreach (string building in AllBuildings)
            {
                string Iv_building = (building != null ? imgBuildingPath + building.Replace(".", "_") + ".png" : null);
                string Tb_building = building;
                string Tb_building_code = null;
                char type_building = ' ';
                foreach (Extractor extractor in All_Extractors)
                {
                    if (building == extractor.Building)
                    {
                        type_building = extractor.Type;
                        Tb_building_code = extractor.Building_Code;
                        break;
                    }
                }

                dynamic item = new ExpandoObject();
                item.IVBuilding = Iv_building;
                item.TBBuilding = Tb_building;
                item.TBBuildingCode = Tb_building_code;
                item.TBTypeBuilding = type_building;
                CBBuilding.Items.Add(item);
            }

            foreach (string production_item in AllItems)
            {
                string Iv_item = (production_item != null ? imgItemPath + production_item.Replace(".", "_") + ".png" : null);
                string Tb_item = production_item;

                dynamic item = new ExpandoObject();
                item.IVItem = Iv_item;
                item.TBItem = Tb_item;
                CBItem.Items.Add(item);
            }
            if (CBPurity.Items.Count <= 0)
            {
                CBPurity.Items.Clear();

                dynamic all_item = new ExpandoObject();
                all_item.TBPurity = "All";
                all_item.TBTypePurity = 'A';
                dynamic impure_item = new ExpandoObject();
                impure_item.TBPurity = "Impure";
                impure_item.TBTypePurity = 'I';
                dynamic normal_item = new ExpandoObject();
                normal_item.TBPurity = "Normal";
                normal_item.TBTypePurity = 'N';
                dynamic pure_item = new ExpandoObject();
                pure_item.TBPurity = "Pure";
                pure_item.TBTypePurity = 'P';

                CBPurity.Items.Add(all_item);
                CBPurity.Items.Add(impure_item);
                CBPurity.Items.Add(normal_item);
                CBPurity.Items.Add(pure_item);

                CBPurity.SelectedIndex = 0;
            }


            /*************************************************************** Change Index ***************************************************************/

            CBBuilding.SelectedIndex = 0;
            CBItem.SelectedIndex = 0;
        }

        private void AddComboBoxMyInfo()
        {
            CBMyBuilding.Items.Clear();
            CBMyItem.Items.Clear();

            /*************************************************************** Prepare Info ***************************************************************/
            string imgBuildingPath = "/Img/Img_Building/";
            string imgItemPath = "/Img/Img_Item/";

            List<string> AllMyDBuildings = new List<string>();
            List<string> AllMyDItems = new List<string>();

            AllMyDBuildings.Add("All");
            AllMyDItems.Add("All");

            /*************************************************************** ComboBoxes MyBuildings ***************************************************************/
            foreach (Resource_Map resource_Map in My_Resources_Map)
            {
                string building = null;
                foreach (Extractor extractor in All_Extractors)
                {
                    if (resource_Map.Type == extractor.Type && resource_Map.Extractor_Code == extractor.Building_Code)
                    {
                        building = extractor.Building;
                        break;
                    }
                }
                AllMyDBuildings.Add(building);
                AllMyDItems.Add(resource_Map.Resource);
            }

            List<string> AllMyBuildings = RemoveDuplicated(AllMyDBuildings);
            List<string> AllMyItems = RemoveDuplicated(AllMyDItems);

            foreach (string building in AllMyBuildings)
            {
                string Iv_building = (building != null ? imgBuildingPath + building.Replace(".", "_") + ".png" : null);
                string Tb_building = building;
                string Tb_building_code = null;

                dynamic item = new ExpandoObject();

                item.IVMyBuilding = Iv_building;
                item.TBMyBuilding = Tb_building;
                item.TBMyTypeBuilding = ' ';
                foreach (Extractor extractor in All_Extractors)
                {
                    if (building == extractor.Building)
                    {
                        Tb_building_code = extractor.Building_Code;
                        item.TBMyTypeBuilding = extractor.Type;
                    }
                }
                item.TBMyBuildingCode = Tb_building_code;

                CBMyBuilding.Items.Add(item);
            }

            foreach (string production_item in AllMyItems)
            {
                string Iv_item = (production_item != null ? imgItemPath + production_item.Replace(".", "_") + ".png" : null);
                string Tb_item = production_item;

                dynamic item = new ExpandoObject();

                item.IVMyItem = Iv_item;
                item.TBMyItem = Tb_item;

                CBMyItem.Items.Add(item);
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
            if (CBMyPurity.Items.Count <= 0)
            {
                CBMyPurity.Items.Clear();

                dynamic all_item = new ExpandoObject();
                all_item.TBMyPurity = "All";
                all_item.TBMyTypePurity = 'A';
                dynamic impure_item = new ExpandoObject();
                impure_item.TBMyPurity = "Impure";
                impure_item.TBMyTypePurity = 'I';
                dynamic normal_item = new ExpandoObject();
                normal_item.TBMyPurity = "Normal";
                normal_item.TBMyTypePurity = 'N';
                dynamic pure_item = new ExpandoObject();
                pure_item.TBMyPurity = "Pure";
                pure_item.TBMyTypePurity = 'P';

                CBMyPurity.Items.Add(all_item);
                CBMyPurity.Items.Add(impure_item);
                CBMyPurity.Items.Add(normal_item);
                CBMyPurity.Items.Add(pure_item);

                CBMyPurity.SelectedIndex = 0;
            }

            /*************************************************************** Change Index ***************************************************************/

            CBMyBuilding.SelectedIndex = 0;
            CBMyItem.SelectedIndex = 0;
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
            All_Extractors.Clear();
            All_Resources_Map.Clear();
            My_Resources_Map.Clear();
            string AllResourcesMapJson = Main.GetAllResourcesMap();
            if (AllResourcesMapJson != null)
            {
                AllResourcesMapJson = AllResourcesMapJson.Replace(",{", "{").Replace("[", "").Replace("]", "");
                Array AllResourcesMapArray = AllResourcesMapJson.Replace("{", "").Split('}');
                foreach (string item in AllResourcesMapArray)
                {
                    if (item != null && item != "")
                    {
                        string p_item = '{' + item + '}';
                        //Console.WriteLine(p_item);
                        dynamic dynamic_Item = JsonConvert.DeserializeObject<dynamic>(p_item);
                        Resource_Map resource_Map = new Resource_Map(dynamic_Item);
                        All_Resources_Map.Add(resource_Map);
                    }
                }
            }
            string MyResourcesMapJson = Main.GetMyResourcesMap();
            if (MyResourcesMapJson != null)
            {
                MyResourcesMapJson = MyResourcesMapJson.Replace(",{", "{").Replace("[", "").Replace("]", "");
                Array MyResourcesMapArray = MyResourcesMapJson.Replace("{", "").Split('}');
                foreach (string item in MyResourcesMapArray)
                {
                    if (item != null && item != "")
                    {
                        string p_item = '{' + item + '}';
                        //Console.WriteLine(p_item);
                        dynamic dynamic_Item = JsonConvert.DeserializeObject<dynamic>(p_item);
                        Resource_Map resource_Map = new Resource_Map(dynamic_Item);
                        My_Resources_Map.Add(resource_Map);
                    }
                }
            }
            string AllExtractorsJson = Main.GetAllExtractors();
            if (AllExtractorsJson != null)
            {
                AllExtractorsJson = AllExtractorsJson.Replace(",{", "{").Replace("[", "").Replace("]", "");
                Array AllExtractorsArray = AllExtractorsJson.Replace("{", "").Split('}');
                foreach (string item in AllExtractorsArray)
                {
                    if (item != null && item != "")
                    {
                        string p_item = '{' + item + '}';
                        //Console.WriteLine(p_item);
                        dynamic dynamic_Item = JsonConvert.DeserializeObject<dynamic>(p_item);
                        Extractor extractor = new Extractor(dynamic_Item);
                        All_Extractors.Add(extractor);
                    }
                }
            }
        }

        private void UpdateListViewAllExtractionBuildings()
        {
            if (CBBuilding.SelectedItem == null)
                CBBuilding.SelectedIndex = 0;
            if (CBItem.SelectedItem == null)
                CBItem.SelectedIndex = 0;
            if (CBPurity.SelectedItem == null)
                CBPurity.SelectedIndex = 0;

            dynamic cb_building = CBBuilding.SelectedItem;
            dynamic cb_item = CBItem.SelectedItem;
            dynamic cb_purity = CBPurity.SelectedItem;

            ListViewAllExtractionBuildings.Items.Clear();
            foreach (Resource_Map resource_Map in All_Resources_Map)
            {
                if ((resource_Map.Type == cb_building.TBTypeBuilding || cb_building.TBBuilding == "All") && resource_Map.Type != 'G')
                {
                    if (resource_Map.Resource == cb_item.TBItem || cb_item.TBItem == "All")
                    {
                        if (resource_Map.Purity == cb_purity.TBTypePurity || cb_purity.TBTypePurity == 'A')
                        {
                            foreach(Extractor extractor in All_Extractors)
                            {
                                if (extractor.Building_Code == cb_building.TBBuildingCode || cb_building.TBBuilding == "All")
                                {
                                    if (extractor.Type == resource_Map.Type && extractor.Purity == resource_Map.Purity)
                                        CreateListItemView(ListViewAllExtractionBuildings, resource_Map, 1, extractor.Building_Code);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void UpdateListViewMyExtractionBuildings()
        {
            if (CBMyBuilding.Items.Count > 0 && CBMyItem.Items.Count > 0 && CBMyDivided.Items.Count > 0 && CBMyPurity.Items.Count > 0)
            {
                if (CBMyBuilding.SelectedItem == null)
                    CBMyBuilding.SelectedIndex = 0;
                if (CBMyItem.SelectedItem == null)
                    CBMyItem.SelectedIndex = 0;
                if (CBMyDivided.SelectedItem == null)
                    CBMyDivided.SelectedIndex = 0;
                if (CBMyPurity.SelectedItem == null)
                    CBMyPurity.SelectedIndex = 0;

                List<Resource_Map> yesItems = new List<Resource_Map>();

                dynamic cb_building = CBMyBuilding.SelectedItem;
                dynamic cb_item = CBMyItem.SelectedItem;
                dynamic cb_purity = CBMyPurity.SelectedItem;

                ListViewMyExtractionBuildings.Items.Clear();
                if (My_Resources_Map != null)
                {
                    foreach (Resource_Map resource_Map in My_Resources_Map)
                    {
                        dynamic Divide = CBMyDivided.SelectedItem;
                        bool Exist = false;
                        if (yesItems != null && Divide.TBMyDivided == "No")
                        {
                            foreach (Resource_Map yes_item in yesItems)
                            {
                                if (resource_Map.Id == yes_item.Id && resource_Map.Percentage == yes_item.Percentage && resource_Map.Extractor_Code == yes_item.Extractor_Code && resource_Map.Purity == yes_item.Purity)
                                    Exist = true;
                            }
                        }
                        yesItems.Add(resource_Map);

                        if (!Exist)
                        {
                            int Quantity = 1;
                            if (Divide.TBMyDivided == "No")
                            {
                                Quantity = 0;
                                foreach (Resource_Map resource_Map_q in My_Resources_Map)
                                {
                                    if (resource_Map.Id == resource_Map_q.Id && resource_Map.Percentage == resource_Map_q.Percentage && resource_Map.Extractor_Code == resource_Map_q.Extractor_Code && resource_Map.Purity == resource_Map_q.Purity)
                                        Quantity++;
                                }
                            }
                            if (resource_Map.Type == cb_building.TBMyTypeBuilding || cb_building.TBMyBuilding == "All")
                            {
                                if (resource_Map.Resource == cb_item.TBMyItem || cb_item.TBMyItem == "All")
                                {
                                    if (resource_Map.Purity == cb_purity.TBMyTypePurity || cb_purity.TBMyTypePurity == 'A')
                                    {
                                        foreach (Extractor extractor in All_Extractors)
                                        {
                                            if (extractor.Building_Code == cb_building.TBMyBuildingCode || cb_building.TBMyBuilding == "All")
                                            {
                                                if (extractor.Type == resource_Map.Type)
                                                {
                                                    if (resource_Map.Extractor_Code == null)
                                                    {
                                                        resource_Map.Extractor_Code = extractor.Building_Code;
                                                        CreateListItemView(ListViewMyExtractionBuildings, resource_Map, Quantity, extractor.Building_Code);
                                                    }
                                                    else
                                                    {
                                                        if (extractor.Building_Code == resource_Map.Extractor_Code)
                                                        {
                                                            CreateListItemView(ListViewMyExtractionBuildings, resource_Map, Quantity, extractor.Building_Code);
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CreateListItemView(ListView listView, Resource_Map resource_Map, int Quantity, string building_code)
        {
            string imgBuildingPath = "/Img/Img_Building/";
            string imgItemPath = "/Img/Img_Item/";
            string building = null;
            int produce_quantity = 0;
            foreach (Extractor extractor in All_Extractors)
            {
                if(extractor.Type == resource_Map.Type && extractor.Building_Code == building_code && extractor.Purity == resource_Map.Purity)
                {
                    building = extractor.Building;
                    produce_quantity = extractor.Item_Quantity;
                    break;
                }
            }
            char type_building = resource_Map.Type;
            string produce = resource_Map.Resource;
            string purity = null;
            char type_purity = resource_Map.Purity;
            switch (resource_Map.Purity)
            {
                case 'I':
                    purity = "Impure";
                    break;
                case 'N':
                    purity = "Normal";
                    break;
                case 'P':
                    purity = "Pure";
                    break;
            }

            string Iv_building = (building != null ? imgBuildingPath + building.Replace(".", "_") + ".png" : null);
            string Iv_produce = (produce != null ? imgItemPath + produce.Replace(".", "_") + ".png" : null);

            string Tb_building = (produce != null ? Quantity + " * " : null);
            string Tb_building_code = building_code;
            char Tb_type_building = type_building;
            string Tb_name = produce;
            //string Tb_name = production_Item.Id+" == "+production_Item.PersonalId;
            string Tb_working = resource_Map.Percentage + "%";
            string Tb_produce = (produce != null ? produce_quantity + " * " : null);
            string Tb_purity = (produce != null ? purity : null);
            char Tb_type_purity = type_purity;

            string Sp_produce = (produce != null ? "Visible" : "Hidden");

            string H_produce = (produce != null ? "auto" : "0");

            if (Tb_name != null)
            {
                dynamic newItem = new ExpandoObject();
                newItem.LVObject = resource_Map;
                newItem.LVResourceMapId = resource_Map.Id;
                newItem.LVResourceMapPersonalId = resource_Map.PersonalId;

                newItem.IVBuilding = Iv_building;
                newItem.IVProduce = Iv_produce;

                newItem.TBBuilding = Tb_building;
                newItem.TBBuildingCode = Tb_building_code;
                newItem.TBTypeBuilding = Tb_type_building;
                newItem.TBName = Tb_name;
                newItem.TBWorking = Tb_working;
                newItem.TBProduce = Tb_produce;
                newItem.TBPurity = Tb_purity;
                newItem.TBTypePurity = Tb_type_purity;

                newItem.SPProduce = Sp_produce;

                newItem.HProduce = H_produce;

                listView.Items.Add(newItem);
            }
        }
    }
}
