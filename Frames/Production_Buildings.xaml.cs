using Satisfactory_Calculator.Class_Files;
using System;
using System.Collections.Generic;
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
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Data;
using System.Dynamic;

namespace Satisfactory_Calculator
{
    /// <summary>
    /// Interaction logic for Production_Buildings.xaml
    /// </summary>
    public partial class Production_Buildings : Page
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();/**/

        private MainWindow Main = null;
        private List<Production_Item> All_Production_Items = new List<Production_Item>();
        private List<Production_Item> My_Production_Items = new List<Production_Item>();
        public Production_Buildings(MainWindow mainWindow)
        {
            InitializeComponent();
            this.Main = mainWindow;
            GetLists();
            AddComboBoxInfo();
        }

        private void AllProductionItemsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListViewAllProductionBuildings();
        }

        private void MyProductionItemsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListViewMyProductionBuildings();
        }

        private void ListViewMyProductionBuildings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListViewMyProductionBuildings.SelectedItem != null)
            {
                string[] AllItems = ListViewAllProductionBuildings.SelectedItem.ToString().Replace("{", "").Replace("}", "").Replace(", ", ",").Split(',');

                foreach (string Item in AllItems)
                {
                    string[] splitedItem = Item.Replace(" = ", "=").Split('=');
                    if (splitedItem[0] == "TBWorking")
                    {
                        TBPercentage.Text = splitedItem[1];
                    }
                }
            }
        }

        private void BtnAddBuilding_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewAllProductionBuildings.SelectedItem != null)
            {
                string ListViewAllItems = ListViewAllProductionBuildings.SelectedItem.ToString();

                string[] AllItems = ListViewAllItems.Replace("{", "").Replace("}", "").Replace(", ", ",").Split(',');
                int ItemId = -1;

                foreach (string Item in AllItems)
                {
                    string[] splitedItem = Item.Replace(" = ", "=").Split('=');
                    if (splitedItem[0] == "LVProductionItemId")
                    {
                        ItemId = int.Parse(splitedItem[1]);
                        foreach (Production_Item production_Item in All_Production_Items)
                        {
                            if(production_Item.Id == ItemId)
                            {
                                My_Production_Items.Add(production_Item);
                                AddComboBoxMyInfo();
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void BtnRemoveBuilding_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddPercentage_Click(object sender, RoutedEventArgs e)
        {
            int oldPercentage = Int32.Parse(TBPercentage.Text.ToString().Replace("%", ""));
            int newPercentage = oldPercentage + 1;
            ChangeItemPercentage(newPercentage, oldPercentage);
        }

        private void BtnRemovePercentage_Click(object sender, RoutedEventArgs e)
        {
            int oldPercentage = Int32.Parse(TBPercentage.Text.ToString().Replace("%", ""));
            int newPercentage = oldPercentage - 1;
            ChangeItemPercentage(newPercentage, oldPercentage);
        }

        private void ChangeItemPercentage(int newPercentage, int oldPercentage)
        {
            if (CBMyBuilding.SelectedItem != null && ListViewMyProductionBuildings.SelectedItem != null)
            {
                string Divide = CBMyDivided.SelectedItem.ToString().Replace("{ ", "").Replace(" }", "").Replace(", ", ",").Replace(" = ", "=").Split('=')[1];
                if (newPercentage > 0 && newPercentage <= 100)
                {
                    dynamic item = ListViewMyProductionBuildings.SelectedItem;
                    Array item_params = item.ToString().Replace("{ ", "").Replace(" }", "").Replace(", ", ",").Replace(" = ", "=").Split(',');
                    int ItemId = -1;
                    int ItemPercentage = -1;
                    foreach (string param in item_params)
                    {
                        if (param != null)
                        {
                            string param1 = param.Split('=')[0];
                            string param2 = param.Split('=')[1];
                            if (param1 == "LVProductionItemId")
                            {
                                ItemId = Int32.Parse(param2);
                            }
                            if (param1 == "TBWorking")
                            {
                                ItemPercentage = Int32.Parse(param2.Replace("%",""));
                            }
                        }
                    }
                    if(ItemId >= 0 && ItemPercentage >= 0)
                    {
                        bool done = false;
                        foreach(Production_Item production_Item in My_Production_Items)
                        {
                            string strItem = null;
                            if(production_Item.Id == ItemId && production_Item.Percentage == oldPercentage && !done)
                            {
                                production_Item.Percentage = newPercentage;
                            }
                            foreach (string param in item_params)
                            {
                                if (param != null)
                                {
                                    string newStr = param;
                                    string param1 = param.Split('=')[0];
                                    string param2 = param.Split('=')[1];
                                    if (param1 == "TBWorking")
                                    {
                                        ItemPercentage = Int32.Parse(param2.Replace("%", ""));
                                        item.TBWorking = newPercentage + "%";
                                        //newStr = param1 + "=" + newPercentage + "%";
                                    }
                                    if(strItem == null)
                                    {
                                        strItem = newStr;
                                    }
                                    else
                                    {
                                        strItem = strItem + "," + newStr;
                                    }
                                }
                            }
                            strItem = ( "{" + strItem + "}" ).Replace("=",":");
                            ListViewMyProductionBuildings.SelectedItem = item;
                            if (Divide == "Yes")
                            {
                                done = true;
                                break;
                            }
                        }
                        TBPercentage.Text = newPercentage + "%";
                    }
                }
            }
        }

        private void AddComboBoxInfo ()
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
            foreach (Production_Item production_Item in All_Production_Items)
            {
                AllDBuildings.Add(production_Item.Building);
                AllDItems.Add(production_Item.Main_Material);
                if (production_Item.Extra_Material != null)
                    AllDItems.Add(production_Item.Extra_Material);
            }

            List<string> AllBuildings = RemoveDuplicated(AllDBuildings);
            List<string> AllItems = RemoveDuplicated(AllDItems);

            foreach (string building in AllBuildings)
            {
                string Iv_building = (building != null ? imgBuildingPath + building.Replace(".", "_") + ".png" : null);
                string Tb_building = building;

                dynamic item = new
                {
                    IVBuilding = Iv_building,
                    TBBuilding = Tb_building
                };
                CBBuilding.Items.Add(item);
            }

            foreach (string production_item in AllItems)
            {
                string Iv_item = (production_item != null ? imgItemPath + production_item.Replace(".", "_") + ".png" : null);
                string Tb_item = production_item;

                dynamic item = new
                {
                    IVItem = Iv_item,
                    TBItem = Tb_item
                };
                CBItem.Items.Add(item);
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
            foreach (Production_Item production_Item in My_Production_Items)
            {
                AllMyDBuildings.Add(production_Item.Building);
                AllMyDItems.Add(production_Item.Main_Material);
                if (production_Item.Extra_Material != null)
                    AllMyDItems.Add(production_Item.Extra_Material);
            }

            List<string> AllMyBuildings = RemoveDuplicated(AllMyDBuildings);
            List<string> AllMyItems = RemoveDuplicated(AllMyDItems);

            foreach (string building in AllMyBuildings)
            {
                string Iv_building = (building != null ? imgBuildingPath + building.Replace(".", "_") + ".png" : null);
                string Tb_building = building;

                dynamic item = new
                {
                    IVMyBuilding = Iv_building,
                    TBMyBuilding = Tb_building
                };
                CBMyBuilding.Items.Add(item);
            }

            foreach (string production_item in AllMyItems)
            {
                string Iv_item = (production_item != null ? imgItemPath + production_item.Replace(".", "_") + ".png" : null);
                string Tb_item = production_item;

                dynamic item = new
                {
                    IVMyItem = Iv_item,
                    TBMyItem = Tb_item
                };
                CBMyItem.Items.Add(item);
            }
            if (CBMyDivided.Items.Count <= 0)
            {
                CBMyDivided.Items.Clear();
                dynamic yes_item = new
                {
                    TBMyDivided = "Yes",
                };
                dynamic no_item = new
                {
                    TBMyDivided = "No",
                };
                CBMyDivided.Items.Add(yes_item);
                CBMyDivided.Items.Add(no_item);
                CBMyDivided.SelectedIndex = 0;
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
                    if(NoDuplicates != null)
                    {
                        bool Exists = false;
                        foreach (string notDuplicated in NoDuplicates)
                        {
                            if (notDuplicated == duplicated)
                                Exists = true;
                        }
                        if(!Exists && duplicated != null)
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
            All_Production_Items.Clear();
            My_Production_Items.Clear();
            string AllProductionItemsJson = Main.GetAllProductionItems();
            if (AllProductionItemsJson != null) 
            {
                AllProductionItemsJson = AllProductionItemsJson.Replace(",{", "{").Replace("[", "").Replace("]", "");
                Array AllProductionItemsArray = AllProductionItemsJson.Replace("{", "").Split('}');
                foreach (string item in AllProductionItemsArray)
                {
                    if (item != null)
                    {
                        string p_item = '{' + item + '}';
                        //Console.WriteLine(p_item);
                        Production_Item production_Item = JsonConvert.DeserializeObject<Production_Item>(p_item);
                        All_Production_Items.Add(production_Item);
                    }
                }
            }
            string MyProductionItemsJson = Main.GetMyProductionItems();
            if (MyProductionItemsJson != null)
            {
                MyProductionItemsJson = MyProductionItemsJson.Replace(",{", "").Replace("[", "").Replace("]", "");
                Array MyProductionItemsArray = MyProductionItemsJson.Replace("{", "").Split('}');
                foreach (string item in MyProductionItemsArray)
                {
                    if (item != null)
                    {
                        string p_item = '{' + item + '}';
                        Production_Item production_Item = JsonConvert.DeserializeObject<Production_Item>(p_item);
                        My_Production_Items.Add(production_Item);
                    }
                }
            }
        }

        private void UpdateListViewAllProductionBuildings()
        {
            if (CBBuilding.SelectedItem == null)
                CBBuilding.SelectedIndex = 0;
            if (CBItem.SelectedItem == null)
                CBItem.SelectedIndex = 0;

            string cb_building = CBBuilding.SelectedItem.ToString().Replace("{ ", "").Replace(" }", "").Replace(", ", ",").Replace(" = ", "=").Split(',')[1].Split('=')[1];
            string cb_item = CBItem.SelectedItem.ToString().Replace("{ ", "").Replace(" }", "").Replace(", ", ",").Replace(" = ", "=").Split(',')[1].Split('=')[1];

            ListViewAllProductionBuildings.Items.Clear();
            foreach (Production_Item production_Item in All_Production_Items)
            {
                if (production_Item.Building == cb_building || cb_building == "All")
                {
                    if (production_Item.Main_Material == cb_item || production_Item.Extra_Material == cb_item || cb_item == "All")
                        CreateListItemView(ListViewAllProductionBuildings, production_Item, 1);
                }
            }
        }

        private void UpdateListViewMyProductionBuildings()
        {
            if (CBMyBuilding.Items.Count > 0 && CBMyItem.Items.Count > 0 && CBMyDivided.Items.Count > 0) {
                if (CBMyBuilding.SelectedItem == null)
                    CBMyBuilding.SelectedIndex = 0;
                if (CBMyItem.SelectedItem == null)
                    CBMyItem.SelectedIndex = 0;
                if (CBMyDivided.SelectedItem == null)
                    CBMyDivided.SelectedIndex = 0;

                List<Production_Item> yesItems = new List<Production_Item>();

                string cb_building = CBMyBuilding.SelectedItem.ToString().Replace("{ ", "").Replace(" }", "").Replace(", ", ",").Replace(" = ", "=").Split(',')[1].Split('=')[1];
                string cb_item = CBMyItem.SelectedItem.ToString().Replace("{ ", "").Replace(" }", "").Replace(", ", ",").Replace(" = ", "=").Split(',')[1].Split('=')[1];

                ListViewMyProductionBuildings.Items.Clear();
                if (My_Production_Items != null)
                {
                    foreach (Production_Item production_Item in My_Production_Items)
                    {
                        string Divide = CBMyDivided.SelectedItem.ToString().Replace("{ ", "").Replace(" }", "").Replace(", ", ",").Replace(" = ", "=").Split('=')[1];
                        bool Exist = false;
                        if (yesItems != null && Divide == "No")
                        {
                            foreach (Production_Item yes_item in yesItems)
                            {
                                if (production_Item.Id == yes_item.Id && production_Item.Percentage == yes_item.Percentage)
                                    Exist = true;
                            }
                        }
                        yesItems.Add(production_Item);
                        
                        if (!Exist)
                        {
                            int Quantity = 1;
                            if (Divide == "No")
                            {
                                Quantity = 0;
                                foreach (Production_Item production_Item_q in My_Production_Items)
                                {
                                    if (production_Item.Id == production_Item_q.Id && production_Item.Percentage == production_Item_q.Percentage)
                                        Quantity++;
                                }
                            }
                            if (production_Item.Building == cb_building || cb_building == "All")
                                if (production_Item.Main_Material == cb_item || production_Item.Extra_Material == cb_item || cb_item == "All")
                                    CreateListItemView(ListViewMyProductionBuildings, production_Item, Quantity);
                        }
                    }
                }
            }
        }

        private void CreateListItemView (ListView listView, Production_Item production_Item, int Quantity)
        {
            string imgBuildingPath = "/Img/Img_Building/";
            string imgItemPath = "/Img/Img_Item/";
            string building = production_Item.Building;
            string produce1 = production_Item.Main_Material;
            string produce2 = production_Item.Extra_Material;
            string require1 = production_Item.In_Material_1;
            string require2 = production_Item.In_Material_2;
            string require3 = production_Item.In_Material_3;
            string require4 = production_Item.In_Material_4;

            string Iv_building = (building != null ? imgBuildingPath + building.Replace(".", "_") + ".png" : null);
            string Iv_produce1 = (produce1 != null ? imgItemPath + produce1.Replace(".", "_") + ".png" : null);
            string Iv_produce2 = (produce2 != null ? imgItemPath + produce2.Replace(".", "_") + ".png" : null);
            string Iv_require1 = (require1 != null ? imgItemPath + require1.Replace(".", "_") + ".png" : null);
            string Iv_require2 = (require2 != null ? imgItemPath + require2.Replace(".", "_") + ".png" : null);
            string Iv_require3 = (require3 != null ? imgItemPath + require3.Replace(".", "_") + ".png" : null);
            string Iv_require4 = (require4 != null ? imgItemPath + require4.Replace(".", "_") + ".png" : null);

            string Tb_building = (produce1 != null ? Quantity + " * " : null);
            string Tb_name = production_Item.Item_Production_Name;
            string Tb_working = production_Item.Percentage+"%";
            string Tb_produce1 = (produce1 != null ? production_Item.Main_Material_Quantity + " * " : null);
            string Tb_produce2 = (produce2 != null ? production_Item.Extra_Material_Quantity + " * " : null);
            string Tb_require1 = (require1 != null ? production_Item.In_Material_Quantity_1 + " * " : null);
            string Tb_require2 = (require2 != null ? production_Item.In_Material_Quantity_2 + " * " : null);
            string Tb_require3 = (require3 != null ? production_Item.In_Material_Quantity_3 + " * " : null);
            string Tb_require4 = (require4 != null ? production_Item.In_Material_Quantity_4 + " * " : null);

            string Sp_produce1 = (produce1 != null ? "Visible" : "Hidden");
            string Sp_produce2 = (produce2 != null ? "Visible" : "Hidden");
            string Sp_require1 = (require1 != null ? "Visible" : "Hidden");
            string Sp_require2 = (require2 != null ? "Visible" : "Hidden");
            string Sp_require3 = (require3 != null ? "Visible" : "Hidden");
            string Sp_require4 = (require4 != null ? "Visible" : "Hidden");

            string H_produce1 = (produce1 != null ? "auto" : "0");
            string H_produce2 = (produce2 != null ? "auto" : "0");
            string H_require1 = (require1 != null ? "auto" : "0");
            string H_require2 = (require2 != null ? "auto" : "0");
            string H_require3 = (require3 != null ? "auto" : "0");
            string H_require4 = (require4 != null ? "auto" : "0");

            if (Tb_name != null)
            {
                dynamic newItem = new
                {
                    LVObject = production_Item,
                    LVProductionItemId = production_Item.Id,

                    IVBuilding = Iv_building,
                    IVProduce1 = Iv_produce1,
                    IVProduce2 = Iv_produce2,
                    IVRequire1 = Iv_require1,
                    IVRequire2 = Iv_require2,
                    IVRequire3 = Iv_require3,
                    IVRequire4 = Iv_require4,

                    TBBuilding = Tb_building,
                    TBName = Tb_name,
                    TBWorking = Tb_working,
                    TBProduce1 = Tb_produce1,
                    TBProduce2 = Tb_produce2,
                    TBRequire1 = Tb_require1,
                    TBRequire2 = Tb_require2,
                    TBRequire3 = Tb_require3,
                    TBRequire4 = Tb_require4,

                    SPProduce1 = Sp_produce1,
                    SPProduce2 = Sp_produce2,
                    SPRequire1 = Sp_require1,
                    SPRequire2 = Sp_require2,
                    SPRequire3 = Sp_require3,
                    SPRequire4 = Sp_require4,

                    HProduce1 = H_produce1,
                    HProduce2 = H_produce2,
                    HRequire1 = H_require1,
                    HRequire2 = H_require2,
                    HRequire3 = H_require3,
                    HRequire4 = H_require4
                };
                /*dynamic newItem = new ExpandoObject();
                newItem.LVObject = production_Item;
                newItem.LVProductionItemId = production_Item.Id;

                newItem.IVBuilding = Iv_building;
                newItem.IVProduce1 = Iv_produce1;
                newItem.IVProduce2 = Iv_produce2;
                newItem.IVRequire1 = Iv_require1;
                newItem.IVRequire2 = Iv_require2;
                newItem.IVRequire3 = Iv_require3;
                newItem.IVRequire4 = Iv_require4;

                newItem.TBBuilding = Tb_building;
                newItem.TBName = Tb_name;
                newItem.TBWorking = Tb_working;
                newItem.TBProduce1 = Tb_produce1;
                newItem.TBProduce2 = Tb_produce2;
                newItem.TBRequire1 = Tb_require1;
                newItem.TBRequire2 = Tb_require2;
                newItem.TBRequire3 = Tb_require3;
                newItem.TBRequire4 = Tb_require4;

                newItem.SPProduce1 = Sp_produce1;
                newItem.SPProduce2 = Sp_produce2;
                newItem.SPRequire1 = Sp_require1;
                newItem.SPRequire2 = Sp_require2;
                newItem.SPRequire3 = Sp_require3;
                newItem.SPRequire4 = Sp_require4;

                newItem.HProduce1 = H_produce1;
                newItem.HProduce2 = H_produce2;
                newItem.HRequire1 = H_require1;
                newItem.HRequire2 = H_require2;
                newItem.HRequire3 = H_require3;
                newItem.HRequire4 = H_require4;

                listView.Items.Add(newItem);*/
            }
        }
    }
}
