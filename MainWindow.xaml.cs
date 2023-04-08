using Satisfactory_Calculator.Class_Files;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Satisfactory_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*[DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();/**/

        private List<Building> All_Buildings = new List<Building>();
        private List<Fuel> All_Fuel = new List<Fuel>();
        private List<Generator> All_Generators = new List<Generator>();
        private List<Production_Item> All_Production_Items = new List<Production_Item>();
        private List<Extractor> All_Raw_Items = new List<Extractor>();
        private List<Resource_Map> All_Resources = new List<Resource_Map>();
        private List<Vehicle> All_Vehicles = new List<Vehicle>();


        private List<Building> My_Buildings = new List<Building>();
        private List<Generator> My_Generators = new List<Generator>();
        private List<Production_Item> My_Production_Items = new List<Production_Item>();
        private List<Extractor> My_Raw_Items = new List<Extractor>();
        private List<Vehicle> My_Vehicles = new List<Vehicle>();
        private List<Info> My_Info = new List<Info>();

        private Extraction_Buildings extraction_buildings_frame = null;
        private Production_Buildings production_buildings_frame = null;
        private Generators generators_frame = null;
        private Vehicles vehicles_frame = null;

        public MainWindow()
        {
            InitializeComponent();
            Create_Lists();
            Create_Frames();
            Main_Frame.Content = extraction_buildings_frame;
            UpdateListViewInfo();
        }

        private void Btn_Page_Extraction_Buildings(object sender, RoutedEventArgs e)
        {
            Main_Frame.Content = extraction_buildings_frame;
        }

        private void Btn_Page_Production_Buildings(object sender, RoutedEventArgs e)
        {
            //production_buildings_frame.UpdateListViewProductionBuildings(0, All_Production_Items);
            Main_Frame.Content = production_buildings_frame;
        }

        private void Btn_Page_Generators(object sender, RoutedEventArgs e)
        {
            Main_Frame.Content = generators_frame;
        }

        private void Btn_Page_Vehicles(object sender, RoutedEventArgs e)
        {
            Main_Frame.Content = vehicles_frame;
        }

        private void UpdateListViewInfo()
        {
            /*foreach (Generator generator in All_Generators)
            {
                string Name1 = generator.In_Material_1;
                if (Name1 != null)
                {
                    string Img1 = "/Img/Img_Item/" + Name1.Replace(".", "_") + ".png";

                    var newItem1 = new { TBName = "G-> " + Name1, IVImg = Img1 };

                    ListViewInfo.Items.Add(newItem1);
                }
            }*/
        }

        private void Create_Frames()
        {
            extraction_buildings_frame = new Extraction_Buildings(this);
            production_buildings_frame = new Production_Buildings(this);
            generators_frame = new Generators(this);
            vehicles_frame = new Vehicles(this);
        }

        public string GetAllBuildings() { return GetStringJson(1); }
        public string GetAllFuel() { return GetStringJson(2); }
        public string GetAllGenerators() { return GetStringJson(3); }
        public string GetAllProductionItems() { return GetStringJson(4); }
        public string GetAllRawItems() { return GetStringJson(5); }
        public string GetAllResources() { return GetStringJson(6); }
        public string GetAllVehicles() { return GetStringJson(7); }
        public string GetMyBuildings() { return GetStringJson(8); }
        public string GetMyGenerators() { return GetStringJson(9); }
        public string GetMyProductionItems() { return GetStringJson(10); }
        public string GetMyRawItems() { return GetStringJson(11); }
        public string GetMyVehicles() { return GetStringJson(12); }

        private string GetStringJson(int index)
        {
            string strJson = null;

            switch (index)
            {
                case 1:
                    strJson = JsonConvert.SerializeObject(All_Buildings);
                    break;
                case 2:
                    strJson = JsonConvert.SerializeObject(All_Fuel);
                    break;
                case 3:
                    strJson = JsonConvert.SerializeObject(All_Generators);
                    break;
                case 4:
                    strJson = JsonConvert.SerializeObject(All_Production_Items);
                    break;
                case 5:
                    strJson = JsonConvert.SerializeObject(All_Raw_Items);
                    break;
                case 6:
                    strJson = JsonConvert.SerializeObject(All_Resources);
                    break;
                case 7:
                    strJson = JsonConvert.SerializeObject(All_Vehicles);
                    break;
                case 8:
                    strJson = JsonConvert.SerializeObject(My_Buildings);
                    break;
                case 9:
                    strJson = JsonConvert.SerializeObject(My_Generators);
                    break;
                case 10:
                    strJson = JsonConvert.SerializeObject(My_Production_Items);
                    break;
                case 11:
                    strJson = JsonConvert.SerializeObject(My_Raw_Items);
                    break;
                case 12:
                    strJson = JsonConvert.SerializeObject(My_Vehicles);
                    break;
            }
            return strJson;
        }

        /************************************************************************************************ Add Data ************************************************************************************************/

        private void Create_Lists()
        {
            All_Buildings.Clear();
            All_Fuel.Clear();
            All_Generators.Clear();
            All_Production_Items.Clear();
            All_Raw_Items.Clear();
            All_Resources.Clear();
            All_Vehicles.Clear();
            My_Buildings.Clear();
            My_Generators.Clear();
            My_Production_Items.Clear();
            My_Raw_Items.Clear();
            My_Vehicles.Clear();
            My_Info.Clear();

            /****************************************************************** Buildings ******************************************************************/
            Building buildings = null;
            buildings = new Building("Miner Mk.1", "Extraction", null, 5, 5);
            All_Buildings.Add(buildings);
            buildings = new Building("Miner Mk.2", "Extraction", null, 12, 12);
            All_Buildings.Add(buildings);
            buildings = new Building("Miner Mk.3", "Extraction", null, 30, 30);
            All_Buildings.Add(buildings);
            buildings = new Building("Oil Extractor", "Extraction", null, 40, 40);
            All_Buildings.Add(buildings);
            buildings = new Building("Water Extractor", "Extraction", null, 20, 20);
            All_Buildings.Add(buildings);
            buildings = new Building("Resource Well Pressurizer", "Other", null, 150, 150);
            All_Buildings.Add(buildings);
            buildings = new Building("Resource Well Extractor", "Extraction", null, 0, 0);
            All_Buildings.Add(buildings);
            buildings = new Building("Smelter", "Production", null, 4, 4);
            All_Buildings.Add(buildings);
            buildings = new Building("Foundry", "Production", null, 16, 16);
            All_Buildings.Add(buildings);
            buildings = new Building("Constructor", "Production", null, 4, 4);
            All_Buildings.Add(buildings);
            buildings = new Building("Assembler", "Production", null, 15, 15);
            All_Buildings.Add(buildings);
            buildings = new Building("Manufacturer", "Production", null, 55, 55);
            All_Buildings.Add(buildings);
            buildings = new Building("Refinery", "Production", null, 30, 30);
            All_Buildings.Add(buildings);
            buildings = new Building("Packager", "Production", null, 10, 10);
            All_Buildings.Add(buildings);
            buildings = new Building("Blender", "Production", null, 75, 75);
            All_Buildings.Add(buildings);
            buildings = new Building("Particle Accelerator", "Production", "Plutonium Pellet", 250, 750);
            All_Buildings.Add(buildings);
            buildings = new Building("Particle Accelerator", "Production", "Nuclear Pasta", 500, 1500);
            All_Buildings.Add(buildings);
            buildings = new Building("AWESOME Sink", "Other", null, 30, 30);
            All_Buildings.Add(buildings);
            buildings = new Building("Truck Station", "Other", null, 20, 20);
            All_Buildings.Add(buildings);
            buildings = new Building("Drone Port", "Other", null, 100, 100);
            All_Buildings.Add(buildings);
            buildings = new Building("Train Station", "Other", null, 50, 50);
            All_Buildings.Add(buildings);
            buildings = new Building("Freight Platform", "Other", null, 50, 50);
            All_Buildings.Add(buildings);
            buildings = new Building("Fluid Freight Platform", "Other", null, 50, 50);
            All_Buildings.Add(buildings);
            buildings = new Building("Radar Tower", "Other", null, 30, 30);
            All_Buildings.Add(buildings);

            /****************************************************************** Fuel ******************************************************************/
            Fuel fuel = null;
            fuel = new Fuel("Leaves", 15, "Burners");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Leaves", 15, "Vehicles");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Mycelia", 20, "Burners");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Mycelia", 20, "Vehicles");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Flower Petals", 100, "Burners");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Wood", 100, "Burners");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Wood", 100, "Vehicles");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Biomass", 180, "Burners");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Biomass", 180, "Vehicles");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Compacted Coal", 630, "Vehicles");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Compacted Coal", 630, "Coal Generator");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Packaged Oil", 320, "Vehicles");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Packaged Heavy Oil Residue", 400, "Vehicles");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Solid Biofuel", 450, "Vehicles");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Packaged Fuel", 750, "Vehicles");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Packaged Liquid Biofuel", 750, "Vehicles");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Packaged Turbofuel", 2000, "Vehicles");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Uranium Fuel Rod", 750000, "Nuclear Power Plant");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Plutonium Fuel Rod", 1500000, "Nuclear Power Plant");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Battery", 6000, "Drones");
            All_Fuel.Add(fuel);
            fuel = new Fuel("Battery", 6000, "Vehicles");
            All_Fuel.Add(fuel);

            /****************************************************************** Generators ******************************************************************/
            Generator generator = null;
            generator = new Generator("Coal Generation", "Coal Generator", "Coal", 15, "Water", 45, null, 0, 75, 75);
            All_Generators.Add(generator);
            generator = new Generator("Compacted Coal Generation", "Coal Generator", "Compacted Coal", (float)7.143, "Water", 45, null, 0, 75, 75);
            All_Generators.Add(generator);
            generator = new Generator("Petroleum Coal Generation", "Coal Generator", "Petroleum Coal", 25, "Water", 45, null, 0, 75, 75);
            All_Generators.Add(generator);

            generator = new Generator("Fuel Generation", "Fuel Generator", "Fuel", 12, null, 0, null, 0, 150, 150);
            All_Generators.Add(generator);
            generator = new Generator("Turbofuel Generation", "Fuel Generator", "Turbofuel", (float)4.5, null, 0, null, 0, 150, 150);
            All_Generators.Add(generator);
            generator = new Generator("Liquid Biofuel Generation", "Fuel Generator", "Liquid Biofuel", 12, null, 0, null, 0, 150, 150);
            All_Generators.Add(generator);

            generator = new Generator("Impure Generation", "Geothermal Generator", null, 0, null, 0, null, 0, 50, 150);
            All_Generators.Add(generator);
            generator = new Generator("Normal Generation", "Geothermal Generator", null, 0, null, 0, null, 0, 100, 300);
            All_Generators.Add(generator);
            generator = new Generator("Pure Generation", "Geothermal Generator", null, 0, null, 0, null, 0, 200, 600);
            All_Generators.Add(generator);

            generator = new Generator("Uranium Generation", "Nuclear Power Plant", "Uranium Fuel Rod", (float)0.2, "Water", 300, "Uranium Waste", 10, 2500, 2500);
            All_Generators.Add(generator);
            generator = new Generator("Plutonium Generation", "Nuclear Power Plant", "Plutonium Fuel Rod", (float)0.1, "Water", 300, "Plutonium Waste", 1, 2500, 2500);
            All_Generators.Add(generator);

            /****************************************************************** Pruduction Items ******************************************************************/
            Production_Item smelter_items = null;
            smelter_items = new Production_Item("Copper Ingot", "Smelter", "Copper Ore", 30, null, 0, null, 0, null, 0, "Copper Ingot", 30, null, 0);
            All_Production_Items.Add(smelter_items);
            smelter_items = new Production_Item("Iron Ingot", "Smelter", "Iron Ore", 30, null, 0, null, 0, null, 0, "Iron Ingot", 30, null, 0);
            All_Production_Items.Add(smelter_items);
            smelter_items = new Production_Item("Alternate: Pure Aluminum Ingot", "Smelter", "Aluminum Scrap", 60, null, 0, null, 0, null, 0, "Aluminum Ingot", 30, null, 0);
            All_Production_Items.Add(smelter_items);
            smelter_items = new Production_Item("Caterium Ingot", "Smelter", "Caterium Ore", 45, null, 0, null, 0, null, 0, "Caterium Ingot", 15, null, 0);
            All_Production_Items.Add(smelter_items);
            smelter_items = new Production_Item("Red FICSMAS Ornament", "Smelter", "FICSMAS Gift", 5, null, 0, null, 0, null, 0, "Red FICSMAS Ornament", 5, null, 0);
            All_Production_Items.Add(smelter_items);
            smelter_items = new Production_Item("Blue FICSMAS Ornament", "Smelter", "FICSMAS Gift", 5, null, 0, null, 0, null, 0, "Blue FICSMAS Ornament", 10, null, 0);
            All_Production_Items.Add(smelter_items);

            Production_Item foundry_items = null;
            foundry_items = new Production_Item("Steel Ingot", "Foundry", "Iron Ore", 45, "Coal", 45, null, 0, null, 0, "Steel Ingot", 45, null, 0);
            All_Production_Items.Add(foundry_items);
            foundry_items = new Production_Item("Alternate: Coke Steel Ingot", "Foundry", "Iron Ore", 75, "Petroleum Coke", 75, null, 0, null, 0, "Steel Ingot", 100, null, 0);
            All_Production_Items.Add(foundry_items);
            foundry_items = new Production_Item("Alternate: Solid Steel Ingot", "Foundry", "Iron Ingot", 20, "Copper Ore", 20, null, 0, null, 0, "Steel Ingot", 60, null, 0);
            All_Production_Items.Add(foundry_items);
            foundry_items = new Production_Item("Alternate: Compacted Steel Ingot", "Foundry", "Iron Ore", (float)22.5, "Compacted Coal", (float)11.25, null, 0, null, 0, "Steel Ingot", (float)37.5, null, 0);
            All_Production_Items.Add(foundry_items);
            foundry_items = new Production_Item("Alternate: Copper Alloy Ingot", "Foundry", "Copper Ore", 50, "Iron Ore", 25, null, 0, null, 0, "Copper Ingot", 100, null, 0);
            All_Production_Items.Add(foundry_items);
            foundry_items = new Production_Item("Aluminum Ingot", "Foundry", "Aluminum Scrap", 90, "Silica", 75, null, 0, null, 0, "Aluminum Ingot", 60, null, 0);
            All_Production_Items.Add(foundry_items);
            foundry_items = new Production_Item("Alternate: Iron Alloy Ingot", "Foundry", "Iron Ore", 45, "Copper Ore", 45, null, 0, null, 0, "Iron Ingot", 45, null, 0);
            All_Production_Items.Add(foundry_items);
            foundry_items = new Production_Item("Copper FICSMAS Ornament", "Foundry", "Red FICSMAS Ornament", 10, "Copper Ingot", 10, null, 0, null, 0, "Copper FICSMAS Ornament", 5, null, 0);
            All_Production_Items.Add(foundry_items);
            foundry_items = new Production_Item("Iron FICSMAS Ornament", "Foundry", "Blue FICSMAS Ornament", 15, "Iron Ingot", 15, null, 0, null, 0, "Iron FICSMAS Ornament", 5, null, 0);
            All_Production_Items.Add(foundry_items);

            Production_Item constructer_items = null;
            constructer_items = new Production_Item("Cable", "Constructor", "Wire", 60, null, 0, null, 0, null, 0, "Cable", 30, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Wire", "Constructor", "Copper Ingot", 15, null, 0, null, 0, null, 0, "Wire", 30, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Alternate: Iron Wire", "Constructor", "Iron Ingot", (float)12.5, null, 0, null, 0, null, 0, "Wire", (float)25.5, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Alternate: Caterium Wire", "Constructor", "Caterium Ingot", 15, null, 0, null, 0, null, 0, "Wire", 120, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Concrete", "Constructor", "Limestone", 45, null, 0, null, 0, null, 0, "Concrete", 15, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Screw", "Constructor", "Iron Rod", 10, null, 0, null, 0, null, 0, "Screw", 40, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Alternate: Cast Screw", "Constructor", "Iron Ingot", (float)12.5, null, 0, null, 0, null, 0, "Screw", 50, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Alternate: Steel Screw", "Constructor", "Steel Beam", 5, null, 0, null, 0, null, 0, "Screw", 260, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Biomass(Leaves)", "Constructor", "Leaves", 120, null, 0, null, 0, null, 0, "Biomass", 60, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Biomass(Wood)", "Constructor", "Wood", 60, null, 0, null, 0, null, 0, "Biomass", 300, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Biomass(Alien Protein)", "Constructor", "Alien Protein", 15, null, 0, null, 0, null, 0, "Biomass", 1500, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Biomass(Mycelia)", "Constructor", "Mycelia", 15, null, 0, null, 0, null, 0, "Biomass", 150, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("FICSMAS Tree Branch", "Constructor", "FICSMAS Gift", 10, null, 0, null, 0, null, 0, "FICSMAS Tree Branch", 10, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Iron Plate", "Constructor", "Iron Ingot", 30, null, 0, null, 0, null, 0, "Iron Plate", 20, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Iron Rod", "Constructor", "Iron Ingot", 15, null, 0, null, 0, null, 0, "Iron Rod", 15, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Alternate: Steel Rod", "Constructor", "Steel Ingot", 12, null, 0, null, 0, null, 0, "Iron Rod", 48, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Copper Sheet", "Constructor", "Copper Ingot", 20, null, 0, null, 0, null, 0, "Copper Sheet", 10, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Color Cartridge", "Constructor", "Flower Petals", 50, null, 0, null, 0, null, 0, "Color Cartridge", 100, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Empty Canister", "Constructor", "Plastic", 30, null, 0, null, 0, null, 0, "Empty Canister", 60, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Alternate: Steel Canister", "Constructor", "Steel Ingot", 60, null, 0, null, 0, null, 0, "Empty Canister", 40, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Aluminum Casing", "Constructor", "Aluminum Ingot", 90, null, 0, null, 0, null, 0, "Aluminum Casing", 60, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Quartz Crystal", "Constructor", "Raw Quartz", (float)37.5, null, 0, null, 0, null, 0, "Quartz Crystal", (float)22.5, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Steel Beam", "Constructor", "Steel Ingot", 60, null, 0, null, 0, null, 0, "Steel Beam", 15, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Steel Pipe", "Constructor", "Steel Ingot", 30, null, 0, null, 0, null, 0, "Steel Pipe", 20, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Alternate: Charcoal", "Constructor", "Wood", 15, null, 0, null, 0, null, 0, "Coal", 150, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Alternate: Biocoal", "Constructor", "Biomass", (float)37.5, null, 0, null, 0, null, 0, "Coal", 45, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Empty Fluid Tank", "Constructor", "Aluminum Ingot", 60, null, 0, null, 0, null, 0, "Empty Fluid Tank", 60, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Copper Powder", "Constructor", "Copper Ingot", 300, null, 0, null, 0, null, 0, "Copper Powder", 50, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Silica", "Constructor", "Raw Quartz", (float)22.5, null, 0, null, 0, null, 0, "Silica", (float)37.5, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Solid Biofuel", "Constructor", "Biomass", 120, null, 0, null, 0, null, 0, "Solid Biofuel", 60, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Iron Rebar", "Constructor", "Iron Rod", 15, null, 0, null, 0, null, 0, "Iron Rebar", 15, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Quickwire", "Constructor", "Caterium Ore", 12, null, 0, null, 0, null, 0, "Quickwire", 60, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Power Shard (Blue)", "Constructor", "Blue Power Slug", (float)7.5, null, 0, null, 0, null, 0, "Power Shard", (float)7.5, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Power Shard (Yellow)", "Constructor", "Yellow Power Slug", 5, null, 0, null, 0, null, 0, "Power Shard", 10, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Power Shard (Purple)", "Constructor", "Purple Power Slug", (float)2.5, null, 0, null, 0, null, 0, "Power Shard", (float)12.5, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Candy Cane", "Constructor", "FICSMAS Gift", 15, null, 0, null, 0, null, 0, "Candy Cane", 5, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("FICSMAS Bow", "Constructor", "FICSMAS Gift", 10, null, 0, null, 0, null, 0, "FICSMAS Bow", 5, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Actual Snow", "Constructor", "FICSMAS Gift", 25, null, 0, null, 0, null, 0, "Actual Snow", 10, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Snowball", "Constructor", "Actual Snow", 15, null, 0, null, 0, null, 0, "Snowball", 5, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Hog Protein", "Constructor", "Hog Remains", 20, null, 0, null, 0, null, 0, "Alien Protein", 20, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Spitter Protein", "Constructor", "Plasma Spitter Remains", 20, null, 0, null, 0, null, 0, "Alien Protein", 20, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Hatcher Protein", "Constructor", "Hatcher Remains", 20, null, 0, null, 0, null, 0, "Alien Protein", 20, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Stinger Protein", "Constructor", "Stinger Remains", 20, null, 0, null, 0, null, 0, "Alien Protein", 20, null, 0);
            All_Production_Items.Add(constructer_items);
            constructer_items = new Production_Item("Alien DNA Capsule", "Constructor", "Alien Protein", 15, null, 0, null, 0, null, 0, "Alien DNA Capsule", 10, null, 0);
            All_Production_Items.Add(constructer_items);

            Production_Item assembler_items = null;
            assembler_items = new Production_Item("Sweet Fireworks", "Assembler", "FICSMAS Tree Branch", 15, "Candy Cane", (float)7.5, null, 0, null, 0, "Sweet Fireworks", (float)2.5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Fancy Fireworks", "Assembler", "FICSMAS Tree Branch", 10, "FICSMAS Bow", (float)7.5, null, 0, null, 0, "Fancy Fireworks", (float)2.5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Sparkly Fireworks", "Assembler", "FICSMAS Tree Branch", (float)7.5, "Actual Snow", 5, null, 0, null, 0, "Sparkly Fireworks", (float)2.5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("FICSMAS Ornament Bundle", "Assembler", "Copper FICSMAS Ornament", 5, "Iron FICSMAS Ornament", 5, null, 0, null, 0, "FICSMAS Ornament Bundle", 5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("FICSMAS Decoration", "Assembler", "FICSMAS Tree Branch", 15, "FICSMAS Ornament Bundle", 6, null, 0, null, 0, "FICSMAS Decoration", 2, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("FICSMAS Wonder Star", "Assembler", "FICSMAS Decoration", 5, "Candy Cane", 20, null, 0, null, 0, "FICSMAS Wonder Star", 1, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Reinforced Iron Plate", "Assembler", "Iron Plate", 30, "Screw", 60, null, 0, null, 0, "Reinforced Iron Plate", 5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Circuit Board", "Assembler", "Copper Sheet", 15, "Plastic", 30, null, 0, null, 0, "Circuit Board", (float)7.5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Modular Frame", "Assembler", "Reinforced Iron Plate", 3, "Iron Rod", 12, null, 0, null, 0, "Modular Frame", 2, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Rotor", "Assembler", "Iron Rod", 20, "Screw", 100, null, 0, null, 0, "Rotor", 4, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Smart Plating", "Assembler", "Reinforced Iron Plate", 2, "Rotor", 2, null, 0, null, 0, "Smart Plating", 2, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alclad Aluminum Sheet", "Assembler", "Aluminum Ingot", 30, "Copper Ingot", 10, null, 0, null, 0, "Alclad Aluminum Sheet", 6, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Encased Industrial Beam", "Assembler", "Steel Beam", 24, "Concrete", 30, null, 0, null, 0, "Encased Industrial Beam", 6, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Motor", "Assembler", "Rotor", 10, "Stator", 10, null, 0, null, 0, "Motor", 5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Stator", "Assembler", "Steel Pipe", 15, "Wire", 14, null, 0, null, 0, "Stator", 5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Automated Wiring", "Assembler", "Stator", (float)2.5, "Cable", 50, null, 0, null, 0, "Automated Wiring", (float)2.5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("AI Limiter", "Assembler", "Copper Sheet", 25, "Quickwire", 100, null, 0, null, 0, "AI Limiter", 5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Versatile Framework", "Assembler", "Modular Frame", (float)2.5, "Steel Beam", 30, null, 0, null, 0, "Versatile Framework", 5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Assembly Director System", "Assembler", "Adaptive Control Unit", (float)1.5, "Supercomputer", (float)0.75, null, 0, null, 0, "Assembly Director System", (float)0.75, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Heat Sink", "Assembler", "Alclad Aluminum Sheet", (float)37.5, "Copper Sheet", (float)22.5, null, 0, null, 0, "Heat Sink", (float)7.5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Encased Plutonium Cell", "Assembler", "Plutonium Pellet", 10, "Concrete", 20, null, 0, null, 0, "Encased Plutonium Cell", 5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Pressure Conversion Cube", "Assembler", "Fused Modular Frame", 1, "Radio Control Unit", 2, null, 0, null, 0, "Pressure Conversion Cube", 1, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Electromagnetic Control Rod", "Assembler", "Stator", 6, "AI Limiter", 4, null, 0, null, 0, "Electromagnetic Control Rod", 4, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Stun Rebar", "Assembler", "Iron Rebar", 10, "Quickwire", 50, null, 0, null, 0, "Stun Rebar", 10, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Homing Rifle Ammo", "Assembler", "Rifle Ammo", 50, "High-Speed Connector", (float)2.5, null, 0, null, 0, "Homing Rifle Ammo", 25, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Fabric", "Assembler", "Mycelia", 15, "Biomass", 75, null, 0, null, 0, "Fabric", 15, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Gas Nobelisk", "Assembler", "Nobelisk", 5, "Biomass", 50, null, 0, null, 0, "Gas Nobelisk", 5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Shatter Rebar", "Assembler", "Iron Rebar", 10, "Quartz Crystal", 15, null, 0, null, 0, "Shatter Rebar", 5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Pulse Nobelisk", "Assembler", "Nobelisk", 5, "Crystal Oscillator", 1, null, 0, null, 0, "Pulse Nobelisk", 5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Cluster Nobelisk", "Assembler", "Nobelisk", (float)7.5, "Smokeless Powder", 10, null, 0, null, 0, "Cluster Nobelisk", (float)2.5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Black Powder", "Assembler", "Coal", 15, "Sulfur", 15, null, 0, null, 0, "Black Powder", 30, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Nobelisk", "Assembler", "Black Powder", 20, "Steel Pipe", 20, null, 0, null, 0, "Nobelisk", 10, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Rifle Ammo", "Assembler", "Copper Sheet", 15, "Smokeless Powder", 10, null, 0, null, 0, "Rifle Ammo", 75, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Adhered Iron Plate", "Assembler", "Iron Plate", (float)11.25, "Rubber", (float)3.75, null, 0, null, 0, "Reinforced Iron Plate", (float)3.75, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Bolted Frame", "Assembler", "Reinforced Iron Plate", (float)7.5, "Screw", 140, null, 0, null, 0, "Modular Frame", 5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Coated Iron Canister", "Assembler", "Iron Plate", 30, "Copper Sheet", 15, null, 0, null, 0, "Empty Canister", 60, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Coated Iron Plate", "Assembler", "Iron Ingot", 50, "Plastic", 10, null, 0, null, 0, "Iron Plate", 75, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Copper Rotor", "Assembler", "Copper Sheet", (float)22.5, "Screw", 195, null, 0, null, 0, "Rotor", (float)11.25, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Electrode Circuit Board", "Assembler", "Rubber", 30, "Petroleum Coke", 45, null, 0, null, 0, "Circuit Board", 5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Fused Wire", "Assembler", "Copper Ingot", 12, "Caterium Ingot", 3, null, 0, null, 0, "Wire", 90, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Rubber Concrete", "Assembler", "Limestone", 50, "Rubber", 10, null, 0, null, 0, "Concrete", 45, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Steel Coated Plate", "Assembler", "Steel Ingot", (float)7.5, "Plastic", 5, null, 0, null, 0, "Iron Plate", 45, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Compacted Coal", "Assembler", "Coal", 25, "Sulfur", 25, null, 0, null, 0, "Compacted Coal", 25, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Alclad Casing", "Assembler", "Aluminum Ingot", 150, "Copper Ingot", 75, null, 0, null, 0, "Aluminum Casing", (float)112.5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Electric Motor", "Assembler", "Electromagnetic Control Rod", (float)3.75, "Rotor", (float)7.5, null, 0, null, 0, "Motor", (float)7.5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: OC Supercomputer", "Assembler", "Radio Control Unit", 9, "Cooling System", 9, null, 0, null, 0, "Supercomputer", 3, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Plutonium Fuel Unit", "Assembler", "Encased Plutonium Cell", 10, "Pressure Conversion Cube", (float)0.5, null, 0, null, 0, "Plutonium Fuel Rod", (float)0.5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Insulated Cable", "Assembler", "Wire", 45, "Rubber", 30, null, 0, null, 0, "Cable", 100, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Quickwire Cable", "Assembler", "Quickwire", (float)7.5, "Rubber", 5, null, 0, null, 0, "Cable", (float)27.5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Silicon Circuit Board", "Assembler", "Copper Sheet", (float)27.5, "Silica", (float)27.5, null, 0, null, 0, "Circuit Board", (float)12.5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Caterium Circuit Board", "Assembler", "Plastic", (float)12.5, "Quickwire", (float)37.5, null, 0, null, 0, "Circuit Board", (float)8.75, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Crystal Computer", "Assembler", "Circuit Board", (float)7.5, "Crystal Oscillator", (float)2.8125, null, 0, null, 0, "Computer", (float)2.8125, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Fine Concrete", "Assembler", "Silica", (float)7.5, "Limestone", 30, null, 0, null, 0, "Concrete", 25, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Electromagnetic Connection Rod", "Assembler", "Stator", 8, "High-Speed Connector", 4, null, 0, null, 0, "Electromagnetic Control Rod", 8, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Fine Black Powder", "Assembler", "Sulfur", (float)7.5, "Compacted Coal", (float)3.75, null, 0, null, 0, "Black Powder", 15, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Heat Exchanger", "Assembler", "Aluminum Casing", 30, "Rubber", 30, null, 0, null, 0, "Heat Sink", 10, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Steeled Frame", "Assembler", "Reinforced Iron Plate", 2, "Steel Pipe", 10, null, 0, null, 0, "Modular Frame", 3, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Fused Quickwire", "Assembler", "Caterium Ingot", (float)7.5, "Copper Ingot", (float)37.5, null, 0, null, 0, "Quickwire", 90, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Bolted Iron Plate", "Assembler", "Iron Plate", 90, "Screw", 250, null, 0, null, 0, "Reinforced Iron Plate", 15, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Stitched Iron Plate", "Assembler", "Iron Plate", (float)18.75, "Wire", (float)37.5, null, 0, null, 0, "Reinforced Iron Plate", (float)5.625, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Encased Industrial Pipe", "Assembler", "Steel Pipe", 28, "Concrete", 20, null, 0, null, 0, "Encased Industrial Beam", 4, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Steel Rotor", "Assembler", "Steel Pipe", 10, "Wire", 30, null, 0, null, 0, "Rotor", 5, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Cheap Silica", "Assembler", "Raw Quartz", (float)11.25, "Limestone", (float)18.75, null, 0, null, 0, "Silica", (float)26.25, null, 0);
            All_Production_Items.Add(assembler_items);
            assembler_items = new Production_Item("Alternate: Quickwire Stator", "Assembler", "Steel Pipe", 16, "Quickwire", 16, null, 0, null, 0, "Stator", 8, null, 0);
            All_Production_Items.Add(assembler_items);

            Production_Item manufacturer_items = null;
            manufacturer_items = new Production_Item("Radio Control Unit", "Manufacturer", "Aluminum Casing", 40, "Crystal Oscillator", (float)1.25, "Computer", (float)1.25, null, 0, "Radio Control Unit", (float)2.5, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Crystal Oscillator", "Manufacturer", "Quartz Crystal", 18, "Cable", 14, "Reinforced Iron Plate", (float)2.5, null, 0, "Crystal Oscillator", 1, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Computer", "Manufacturer", "Circuit Board", 25, "Cable", (float)22.5, "Plastic", 45, "Screw", 130, "Computer", (float)2.5, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Modular Engine", "Manufacturer", "Motor", 2, "Rubber", 15, "Smart Plating", 2, null, 0, "Modular Engine", 1, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Adaptive Control Unit", "Manufacturer", "Automated Wiring", (float)7.5, "Circuit Board", 5, "Heavy Modular Frame", 1, "Computer", 1, "Adaptive Control Unit", 1, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Heavy Modular Frame", "Manufacturer", "Modular Frame", 10, "Steel Pipe", 30, "Encased Industrial Beam", 10, "Screw", 200, "Heavy Modular Frame", 2, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Supercomputer", "Manufacturer", "Computer", (float)3.75, "AI Limiter", (float)3.75, "High-Speed Connector", (float)5.625, "Plastic", (float)52.5, "Supercomputer", (float)1.875, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("High-Speed Connector", "Manufacturer", "Quickwire", 210, "Cable", (float)37.5, "Circuit Board", (float)3.75, null, 0, "High-Speed Connector", (float)3.75, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Plutonium Fuel Rod", "Manufacturer", "Encased Plutonium Cell", (float)7.5, "Steel Beam", (float)4.5, "Electromagnetic Control Rod", (float)1.5, "Heat Sink", (float)2.5, "Plutonium Fuel Rod", (float)0.25, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Uranium Fuel Rod", "Manufacturer", "Encased Uranium Cell", 20, "Encased Industrial Beam", (float)1.2, "Electromagnetic Control Rod", 2, null, 0, "Uranium Fuel Rod", (float)0.4, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Magnetic Field Generator", "Manufacturer", "Versatile Framework", (float)2.5, "Electromagnetic Control Rod", 1, "Battery", 5, null, 0, "Magnetic Field Generator", 1, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Turbo Motor", "Manufacturer", "Cooling System", (float)7.5, "Radio Control Unit", (float)3.75, "Motor", (float)7.5, "Rubber", 45, "Turbo Motor", (float)1.875, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Thermal Propulsion Rocket", "Manufacturer", "Modular Engine", (float)2.5, "Turbo Motor", 1, "Cooling System", 3, "Fused Modular Frame", 1, "Thermal Propulsion Rocket", 1, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Explosive Rebar", "Manufacturer", "Iron Rebar", 10, "Smokeless Powder", 10, "Steel Pipe", 10, null, 0, "Explosive Rebar", 5, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Nuke Nobelisk", "Manufacturer", "Nobelisk", (float)2.5, "Encased Uranium Cell", 10, "Smokeless Powder", 5, "AI Limiter", 3, "Nuke Nobelisk", (float)0.5, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Turbo Rifle Ammo", "Manufacturer", "Rifle Ammo", 125, "Aluminum Casing", 15, "Packaged Turbofuel", 15, null, 0, "Turbo Rifle Ammo", 250, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Beacon", "Manufacturer", "Iron Plate", (float)22.5, "Iron Rod", (float)7.5, "Wire", (float)112.5, "Cable", 15, "Beacon", (float)7.5, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Gas Filter", "Manufacturer", "Coal", (float)37.5, "Rubber", 15, "Fabric", 15, null, 0, "Gas Filter", (float)7.5, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Iodine Infused Filter", "Manufacturer", "Gas Filter", (float)3.75, "Quickwire", 30, "Aluminum Casing", (float)3.75, null, 0, "Iodine Infused Filter", (float)3.75, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Flexible Framework", "Manufacturer", "Modular Frame", (float)3.75, "Steel Beam", (float)22.5, "Rubber", 30, null, 0, "Versatile Framework", (float)7.5, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Heavy Flexible Frame", "Manufacturer", "Modular Frame", (float)18.75, "Encased Industrial Beam", (float)11.25, "Rubber", 75, "Screw", 390, "Heavy Modular Frame", (float)3.75, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Automated Speed Wiring", "Manufacturer", "Stator", (float)3.75, "Wire", 75, "High-Speed Connector", (float)1.875, null, 0, "Automated Wiring", (float)7.5, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Plastic Smart Plating", "Manufacturer", "Reinforced Iron Plate", (float)2.5, "Rotor", (float)2.5, "Plastic", (float)7.5, null, 0, "Smart Plating", 5, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Automated Miner", "Manufacturer", "Motor", 1, "Steel Pipe", 4, "Iron Rod", 4, "Iron Plate", 2, "Portable Miner", 1, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Classic Battery", "Manufacturer", "Sulfur", 45, "Alclad Aluminum Sheet", (float)52.5, "Plastic", 60, "Wire", 90, "Battery", 30, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Radio Control System", "Manufacturer", "Crystal Oscillator", (float)1.5, "Circuit Board", 15, "Aluminum Casing", 90, "Rubber", 45, "Radio Control Unit", (float)4.5, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Super-State Computer", "Manufacturer", "Computer", (float)3.6, "Electromagnetic Control Rod", (float)2.4, "Battery", 24, "Wire", 54, "Supercomputer", (float)2.4, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Turbo Pressure Motor", "Manufacturer", "Motor", (float)7.5, "Pressure Conversion Cube", (float)1.875, "Packaged Nitrogen Gas", 45, "Stator", 15, "Turbo Motor", (float)3.75, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Crystal Beacon", "Manufacturer", "Steel Beam", 2, "Steel Pipe", 8, "Crystal Oscillator", (float)0.5, null, 0, "Beacon", 10, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Caterium Computer", "Manufacturer", "Circuit Board", (float)26.25, "Quickwire", 105, "Rubber", 45, null, 0, "Computer", (float)3.75, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Insulated Crystal Oscillator", "Manufacturer", "Quartz Crystal", (float)18.75, "Rubber", (float)13.125, "AI Limiter", (float)1.875, null, 0, "Crystal Oscillator", (float)1.875, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Heavy Encased Frame", "Manufacturer", "Modular Frame", (float)7.5, "Encased Industrial Beam", (float)9.375, "Steel Pipe", (float)33.75, "Concrete", (float)20.625, "Heavy Modular Frame", (float)2.8125, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Silicon High-Speed Connector", "Manufacturer", "Quickwire", 90, "Silica", (float)37.5, "Circuit Board", 3, null, 0, "High-Speed Connector", 3, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Rigour Motor", "Manufacturer", "Rotor", (float)3.75, "Stator", (float)3.75, "Crystal Oscillator", (float)1.25, null, 0, "Motor", (float)7.5, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Uranium Fuel Unit", "Manufacturer", "Encased Uranium Cell", 20, "Electromagnetic Control Rod", 2, "Crystal Oscillator", (float)0.6, "Beacon", (float)1.2, "Uranium Fuel Rod", (float)0.6, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Radio Connection Unit", "Manufacturer", "Heat Sink", 15, "High-Speed Connector", (float)7.5, "Quartz Crystal", 45, null, 0, "Radio Control Unit", (float)3.75, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Turbo Electric Motor", "Manufacturer", "Motor", (float)6.5625, "Radio Control Unit", (float)8.4375, "Electromagnetic Control Rod", (float)4.6875, "Rotor", (float)6.5625, "Turbo Motor", (float)2.8125, null, 0);
            All_Production_Items.Add(manufacturer_items);
            manufacturer_items = new Production_Item("Alternate: Infused Uranium Cell", "Manufacturer", "Uranium", 25, "Silica", 15, "Sulfur", 25, "Quickwire", 75, "Encased Uranium Cell", 20, null, 0);
            All_Production_Items.Add(manufacturer_items);

            Production_Item refinery_items = null;
            refinery_items = new Production_Item("Fuel", "Refinery", "Crude Oil", 60, null, 0, null, 0, null, 0, "Fuel", 40, "Polymer Resin", 30);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Petroleum Coke", "Refinery", "Heavy Oil Residue", 40, null, 0, null, 0, null, 0, "Petroleum Coke", 120, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Plastic", "Refinery", "Crude Oil", 30, null, 0, null, 0, null, 0, "Plastic", 20, "Heavy Oil Residue", 10);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Rubber", "Refinery", "Crude Oil", 30, null, 0, null, 0, null, 0, "Rubber", 20, "Heavy Oil Residue", 20);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Residual Fuel", "Refinery", "Heavy Oil Residue", 60, null, 0, null, 0, null, 0, "Fuel", 40, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Residual Plastic", "Refinery", "Polymer Resin", 60, "Water", 20, null, 0, null, 0, "Plastic", 20, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Residual Rubber", "Refinery", "Polymer Resin", 40, "Water", 40, null, 0, null, 0, "Rubber", 20, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Liquid Biofuel", "Refinery", "Solid Biofuel", 90, "Water", 45, null, 0, null, 0, "Liquid Biofuel", 60, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alumina Solution", "Refinery", "Bauxite", 120, "Water", 180, null, 0, null, 0, "Alumina Solution", 120, "Silica", 50);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Aluminum Scrap", "Refinery", "Alumina Solution", 240, "Coal", 120, null, 0, null, 0, "Aluminum Scrap", 360, "Water", 120);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Sulfuric Acid", "Refinery", "Sulfur", 50, "Water", 50, null, 0, null, 0, "Sulfuric Acid", 50, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Smokeless Powder", "Refinery", "Black Powder", 20, "Heavy Oil Residue", 10, null, 0, null, 0, "Smokeless Powder", 20, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Coated Cable", "Refinery", "Wire", (float)37.5, "Heavy Oil Residue", 15, null, 0, null, 0, "Cable", (float)67.5, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Diluted Packaged Fuel", "Refinery", "Heavy Oil Residue", 30, "Packaged Water", 60, null, 0, null, 0, "Packaged Fuel", 60, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Electrode - Aluminum Scrap", "Refinery", "Alumina Solution", 180, "Petroleum Coke", 60, null, 0, null, 0, "Aluminum Scrap", 300, "Water", 105);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Heavy Oil Residue", "Refinery", "Crude Oil", 30, null, 0, null, 0, null, 0, "Heavy Oil Residue", 40, "Polymer Resin", 20);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Polymer Resin", "Refinery", "Crude Oil", 60, null, 0, null, 0, null, 0, "Polymer Resin", 130, "Heavy Oil Residue", 20);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Pure Caterium Ingot", "Refinery", "Caterium Ore", 24, "Water", 24, null, 0, null, 0, "Caterium Ingot", 12, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Pure Copper Ingot", "Refinery", "Copper Ore", 15, "Water", 10, null, 0, null, 0, "Copper Ingot", (float)37.5, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Pure Iron Ingot", "Refinery", "Iron Ore", 35, "Water", 20, null, 0, null, 0, "Iron Ingot", 65, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Pure Quartz Crystal", "Refinery", "Raw Quartz", (float)67.5, "Water", (float)37.5, null, 0, null, 0, "Quartz Crystal", (float)52.5, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Recycled Rubber", "Refinery", "Plastic", 30, "Fuel", 30, null, 0, null, 0, "Rubber", 60, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Steamed Copper Sheet", "Refinery", "Copper Ingot", (float)22.5, "Water", (float)22.5, null, 0, null, 0, "Copper Sheet", (float)22.5, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Turbo Heavy Fuel", "Refinery", "Heavy Oil Residue", (float)37.5, "Compacted Coal", 30, null, 0, null, 0, "Turbofuel", 30, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Wet Concrete", "Refinery", "Limestone", 120, "Water", 100, null, 0, null, 0, "Concrete", 80, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Sloppy Alumina", "Refinery", "Bauxite", 200, "Water", 200, null, 0, null, 0, "Alumina Solution", 240, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Recycled Plastic", "Refinery", "Rubber", 30, "Fuel", 30, null, 0, null, 0, "Plastic", 60, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Turbofuel", "Refinery", "Fuel", (float)22.5, "Compacted Coal", 15, null, 0, null, 0, "Turbofuel", (float)18.75, null, 0);
            All_Production_Items.Add(refinery_items);
            refinery_items = new Production_Item("Alternate: Polyester Fabric", "Refinery", "Polymer Resin", 30, "Water", 30, null, 0, null, 0, "Fabric", 30, null, 0);
            All_Production_Items.Add(refinery_items);

            Production_Item packager_items = null;
            packager_items = new Production_Item("Packaged Fuel", "Packager", "Fuel", 40, "Empty Canister", 40, null, 0, null, 0, "Packaged Fuel", 40, null, 0);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Packaged Liquid Biofuel", "Packager", "Liquid Biofuel", 40, "Empty Canister", 40, null, 0, null, 0, "Packaged Liquid Biofuel", 40, null, 0);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Packaged Oil", "Packager", "Crude Oil", 30, "Empty Canister", 30, null, 0, null, 0, "Packaged Oil", 30, null, 0);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Packaged Heavy Oil Residue", "Packager", "Heavy Oil Residue", 30, "Empty Canister", 30, null, 0, null, 0, "Packaged Heavy Oil Residue", 30, null, 0);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Packaged Water", "Packager", "Water", 60, "Empty Canister", 60, null, 0, null, 0, "Packaged Water", 60, null, 0);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Packaged Alumina Solution", "Packager", "Alumina Solution", 120, "Empty Canister", 120, null, 0, null, 0, "Packaged Alumina Solution", 120, null, 0);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Packaged Turbofuel", "Packager", "Turbofuel", 20, "Empty Canister", 20, null, 0, null, 0, "Packaged Turbofuel", 20, null, 0);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Packaged Sulfuric Acid", "Packager", "Sulfuric Acid", 40, "Empty Canister", 40, null, 0, null, 0, "Packaged Sulfuric Acid", 40, null, 0);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Packaged Nitrogen Gas", "Packager", "Nitrogen Gas", 120, "Empty Fluid Tank", 60, null, 0, null, 0, "Packaged Nitrogen Gas", 60, null, 0);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Packaged Nitric Acid", "Packager", "Nitric Acid", 30, "Empty Fluid Tank", 30, null, 0, null, 0, "Packaged Nitric Acid", 30, null, 0);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Unpackage Liquid Biofuel", "Packager", "Packaged Liquid Biofuel", 60, null, 0, null, 0, null, 0, "Liquid Biofuel", 60, "Empty Canister", 60);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Unpackage Fuel", "Packager", "Packaged Fuel", 60, null, 0, null, 0, null, 0, "Fuel", 60, "Empty Canister", 60);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Unpackage Oil", "Packager", "Packaged Oil", 60, null, 0, null, 0, null, 0, "Crude Oil", 60, "Empty Canister", 60);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Unpackage Heavy Oil Residue", "Packager", "Packaged Heavy Oil Residue", 20, null, 0, null, 0, null, 0, "Heavy Oil Residue", 20, "Empty Canister", 20);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Unpackage Water", "Packager", "Packaged Water", 120, null, 0, null, 0, null, 0, "Water", 120, "Empty Canister", 120);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Unpackage Alumina Solution", "Packager", "Packaged Alumina Solution", 120, null, 0, null, 0, null, 0, "Alumina Solution", 120, "Empty Canister", 120);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Unpackage Turbofuel", "Packager", "Packaged Turbofuel", 20, null, 0, null, 0, null, 0, "Turbofuel", 20, "Empty Canister", 20);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Unpackage Sulfuric Acid", "Packager", "Packaged Sulfuric Acid", 60, null, 0, null, 0, null, 0, "Sulfuric Acid", 60, "Empty Canister", 60);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Unpackage Nitrogen Gas", "Packager", "Packaged Nitrogen Gas", 60, null, 0, null, 0, null, 0, "Nitrogen Gas", 240, "Empty Fluid Tank", 60);
            All_Production_Items.Add(packager_items);
            packager_items = new Production_Item("Unpackage Nitric Acid", "Packager", "Packaged Nitric Acid", 20, null, 0, null, 0, null, 0, "Nitric Acid", 20, "Empty Fluid Tank", 20);
            All_Production_Items.Add(packager_items);

            Production_Item blender_items = null;
            blender_items = new Production_Item("Encased Uranium Cell", "Blender", "Uranium", 50, "Concrete", 15, "Sulfuric Acid", 40, null, 0, "Encased Uranium Cell", 25, "Sulfuric Acid", 10);
            All_Production_Items.Add(blender_items);
            blender_items = new Production_Item("Cooling System", "Blender", "Heat Sink", 12, "Rubber", 12, "Water", 30, "Nitrogen Gas", 150, "Cooling System", 6, null, 0);
            All_Production_Items.Add(blender_items);
            blender_items = new Production_Item("Nitric Acid", "Blender", "Nitrogen Gas", 120, "Water", 30, "Iron Plate", 10, null, 0, "Nitric Acid", 30, null, 0);
            All_Production_Items.Add(blender_items);
            blender_items = new Production_Item("Non-fissile Uranium", "Blender", "Uranium Waste", (float)37.5, "Silica", 25, "Nitric Acid", 15, "Sulfuric Acid", 15, "Non-fissile Uranium", 30, "Water", 15);
            All_Production_Items.Add(blender_items);
            blender_items = new Production_Item("Battery", "Blender", "Sulfuric Acid", 60, "Alumina Solution", 40, "Aluminum Casing", 20, null, 0, "Battery", 20, "Water", 40);
            All_Production_Items.Add(blender_items);
            blender_items = new Production_Item("Fused Modular Frame", "Blender", "Heavy Modular Frame", (float)1.5, "Aluminum Casing", 75, "Nitrogen Gas", (float)37.5, null, 0, "Fused Modular Frame", (float)1.5, null, 0);
            All_Production_Items.Add(blender_items);
            blender_items = new Production_Item("Turbo Rifle Ammo", "Blender", "Rifle Ammo", 125, "Aluminum Casing", 15, "Turbofuel", 15, null, 0, "Turbo Rifle Ammo", 250, null, 0);
            All_Production_Items.Add(blender_items);
            blender_items = new Production_Item("Alternate: Cooling Device", "Blender", "Heat Sink", (float)9.375, "Motor", (float)1.875, "Nitrogen Gas", 45, null, 0, "Cooling System", (float)3.75, null, 0);
            All_Production_Items.Add(blender_items);
            blender_items = new Production_Item("Alternate: Diluted Fuel", "Blender", "Heavy Oil Residue", 50, "Water", 100, null, 0, null, 0, "Fuel", 100, null, 0);
            All_Production_Items.Add(blender_items);
            blender_items = new Production_Item("Alternate: Fertile Uranium", "Blender", "Uranium", 25, "Uranium Waste", 25, "Nitric Acid", 15, "Sulfuric Acid", 25, "Non-fissile Uranium", 100, "Water", 40);
            All_Production_Items.Add(blender_items);
            blender_items = new Production_Item("Alternate: Heat-Fused Frame", "Blender", "Heavy Modular Frame", 3, "Aluminum Ingot", 150, "Nitric Acid", 24, "Fuel", 30, "Fused Modular Frame", 3, null, 0);
            All_Production_Items.Add(blender_items);
            blender_items = new Production_Item("Alternate: Instant Scrap", "Blender", "Bauxite", 150, "Coal", 100, "Sulfuric Acid", 50, "Water", 60, "Aluminum Scrap", 300, "Water", 50);
            All_Production_Items.Add(blender_items);
            blender_items = new Production_Item("Alternate: Turbo Blend Fuel", "Blender", "Fuel", 15, "Heavy Oil Residue", 30, "Sulfur", (float)22.5, "Petroleum Coke", (float)22.5, "Turbofuel", 45, null, 0);
            All_Production_Items.Add(blender_items);

            Production_Item particle_accelerator_items = null;
            particle_accelerator_items = new Production_Item("Plutonium Pellet", "Particle Accelerator", "Non-fissile Uranium", 100, "Uranium Waste", 25, null, 0, null, 0, "Plutonium Pellet", 30, null, 0);
            All_Production_Items.Add(particle_accelerator_items);
            particle_accelerator_items = new Production_Item("Nuclear Pasta", "Particle Accelerator", "Copper Powder", 100, "Pressure Conversion Cube", (float)0.5, null, 0, null, 0, "Nuclear Pasta", (float)0.5, null, 0);
            All_Production_Items.Add(particle_accelerator_items);
            particle_accelerator_items = new Production_Item("Alternate: Instant Plutonium Cell", "Particle Accelerator", "Non-fissile Uranium", 75, "Aluminum Casing", 10, null, 0, null, 0, "Encased Plutonium Cell", 10, null, 0);
            All_Production_Items.Add(particle_accelerator_items);

            /****************************************************************** Raw Items ******************************************************************/
            Extractor miner = null;
            miner = new Extractor("Miner Mk.1", 30, 'M', 'I');
            All_Raw_Items.Add(miner);
            miner = new Extractor("Miner Mk.1", 60, 'M', 'N');
            All_Raw_Items.Add(miner);
            miner = new Extractor("Miner Mk.1", 120, 'M', 'P');
            All_Raw_Items.Add(miner);
            miner = new Extractor("Miner Mk.2", 60, 'M', 'I');
            All_Raw_Items.Add(miner);
            miner = new Extractor("Miner Mk.2", 120, 'M', 'N');
            All_Raw_Items.Add(miner);
            miner = new Extractor("Miner Mk.2", 240, 'M', 'P');
            All_Raw_Items.Add(miner);
            miner = new Extractor("Miner Mk.3", 120, 'M', 'I');
            All_Raw_Items.Add(miner);
            miner = new Extractor("Miner Mk.3", 240, 'M', 'N');
            All_Raw_Items.Add(miner);
            miner = new Extractor("Miner Mk.3", 480, 'M', 'P');
            All_Raw_Items.Add(miner);

            Extractor oil_extractor = null;
            oil_extractor = new Extractor("Oil Extractor", 60, 'O', 'I');
            All_Raw_Items.Add(oil_extractor);
            oil_extractor = new Extractor("Oil Extractor", 120, 'O', 'N');
            All_Raw_Items.Add(oil_extractor);
            oil_extractor = new Extractor("Oil Extractor", 240, 'O', 'P');
            All_Raw_Items.Add(oil_extractor);

            Extractor water_extractor = null;
            water_extractor = new Extractor("Water Extractor", 120, 'W', 'N');
            All_Raw_Items.Add(water_extractor);
                    
            Extractor resource_well_extractor = null;
            resource_well_extractor = new Extractor("Resource Well Extractor", 30, 'R', 'I');
            All_Raw_Items.Add(resource_well_extractor);
            resource_well_extractor = new Extractor("Resource Well Extractor", 60, 'R', 'N');
            All_Raw_Items.Add(resource_well_extractor);
            resource_well_extractor = new Extractor("Resource Well Extractor", 120, 'R', 'P');
            All_Raw_Items.Add(resource_well_extractor);

            /****************************************************************** Resource ******************************************************************/
            Resource_Map resource_nodes = null;
            resource_nodes = new Resource_Map("Limestone", 'M', 'I', 12);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Limestone", 'M', 'N', 47);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Limestone", 'M', 'P', 27);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Iron Ore", 'M', 'I', 33);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Iron Ore", 'M', 'N', 41);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Iron Ore", 'M', 'P', 46);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Copper Ore", 'M', 'I', 9);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Copper Ore", 'M', 'N', 28);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Copper Ore", 'M', 'P', 12);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Caterium Ore", 'M', 'N', 8);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Caterium Ore", 'M', 'P', 8);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Coal", 'M', 'I', 6);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Coal", 'M', 'N', 29);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Coal", 'M', 'P', 15);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Crude Oil", 'O', 'I', 10);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Crude Oil", 'O', 'N', 12);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Crude Oil", 'O', 'P', 8);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Sulfur", 'M', 'I', 1);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Sulfur", 'M', 'N', 7);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Sulfur", 'M', 'P', 3);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Bauxite", 'M', 'I', 5);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Bauxite", 'M', 'N', 6);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Bauxite", 'M', 'P', 6);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Raw Quartz", 'M', 'N', 11);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Raw Quartz", 'M', 'P', 5);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Uranium", 'M', 'I', 1);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("Uranium", 'M', 'N', 3);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("S.A.M Ore", 'M', 'I', 8);
            All_Resources.Add(resource_nodes);
            resource_nodes = new Resource_Map("S.A.M Ore", 'M', 'N', 5);
            All_Resources.Add(resource_nodes);

            Resource_Map resource_wells = null;
            resource_wells = new Resource_Map("Nitrogen Gas", 'R', 'I', 2);
            All_Resources.Add(resource_wells);
            resource_wells = new Resource_Map("Nitrogen Gas", 'R', 'N', 7);
            All_Resources.Add(resource_wells);
            resource_wells = new Resource_Map("Nitrogen Gas", 'R', 'P', 36);
            All_Resources.Add(resource_wells);
            resource_wells = new Resource_Map("Crude Oil", 'R', 'I', 6);
            All_Resources.Add(resource_wells);
            resource_wells = new Resource_Map("Crude Oil", 'R', 'N', 3);
            All_Resources.Add(resource_wells);
            resource_wells = new Resource_Map("Crude Oil", 'R', 'P', 3);
            All_Resources.Add(resource_wells);
            resource_wells = new Resource_Map("Water", 'R', 'I', 7);
            All_Resources.Add(resource_wells);
            resource_wells = new Resource_Map("Water", 'R', 'N', 12);
            All_Resources.Add(resource_wells);
            resource_wells = new Resource_Map("Water", 'R', 'P', 36);
            All_Resources.Add(resource_wells);
            resource_wells = new Resource_Map("Geysers", 'R', 'I', 3);
            All_Resources.Add(resource_wells);
            resource_wells = new Resource_Map("Geysers", 'R', 'N', 9);
            All_Resources.Add(resource_wells);
            resource_wells = new Resource_Map("Geysers", 'R', 'P', 6);
            All_Resources.Add(resource_wells);

            Resource_Map water_source = null;
            water_source = new Resource_Map("River", 'W', 'Q', 15);
            All_Resources.Add(water_source);

            Resource_Map quantity_wells = null;
            quantity_wells = new Resource_Map("Wells", 'R', 'Q', 15);
            All_Resources.Add(quantity_wells);

            /****************************************************************** Vehicles ******************************************************************/
            Vehicle vehicles = null;
            vehicles = new Vehicle("Tractor", "Any", 55, 0, 0, 0);
            All_Vehicles.Add(vehicles);
            vehicles = new Vehicle("Truck", "Any", 75, 0, 0, 0);
            All_Vehicles.Add(vehicles);
            vehicles = new Vehicle("Drone", "Battery", 6000, 24000, 0, 0);
            All_Vehicles.Add(vehicles);
            vehicles = new Vehicle("Electric Locomotive", "Power", 0, 0, 25, 110);
            All_Vehicles.Add(vehicles);

            /****************************************************************** Info ******************************************************************/
            Info info = null;
            info = new Info("Limestone", "Solid");
            My_Info.Add(info);
            info = new Info("Iron Ore", "Solid");
            My_Info.Add(info);
            info = new Info("Copper Ore", "Solid");
            My_Info.Add(info);
            info = new Info("Caterium Ore", "Solid");
            My_Info.Add(info);
            info = new Info("Coal", "Solid");
            My_Info.Add(info);
            info = new Info("Raw Quartz", "Solid");
            My_Info.Add(info);
            info = new Info("Sulfur", "Solid");
            My_Info.Add(info);
            info = new Info("Bauxite", "Solid");
            My_Info.Add(info);
            info = new Info("S.A.M. Ore", "Solid");
            My_Info.Add(info);
            info = new Info("Uranium", "Solid");
            My_Info.Add(info);
            info = new Info("Iron Ingot", "Solid");
            My_Info.Add(info);
            info = new Info("Copper Ingot", "Solid");
            My_Info.Add(info);
            info = new Info("Caterium Ingot", "Solid");
            My_Info.Add(info);
            info = new Info("Steel Ingot", "Solid");
            My_Info.Add(info);
            info = new Info("Aluminum Ingot", "Solid");
            My_Info.Add(info);
            info = new Info("Concrete", "Solid");
            My_Info.Add(info);
            info = new Info("Quartz Crystal", "Solid");
            My_Info.Add(info);
            info = new Info("Silica", "Solid");
            My_Info.Add(info);
            info = new Info("Copper Powder", "Solid");
            My_Info.Add(info);
            info = new Info("Polymer Resin", "Solid");
            My_Info.Add(info);
            info = new Info("Petroleum Coke", "Solid");
            My_Info.Add(info);
            info = new Info("Aluminum Scrap", "Solid");
            My_Info.Add(info);
            info = new Info("Alien Protein", "Solid");
            My_Info.Add(info);
            info = new Info("Alien DNA Capsule", "Solid");
            My_Info.Add(info);
            info = new Info("Water", "Liquid");
            My_Info.Add(info);
            info = new Info("Crude Oil", "Liquid");
            My_Info.Add(info);
            info = new Info("Heavy Oil Residue", "Liquid");
            My_Info.Add(info);
            info = new Info("Fuel", "Liquid");
            My_Info.Add(info);
            info = new Info("Liquid Biofuel", "Liquid");
            My_Info.Add(info);
            info = new Info("Turbofuel", "Liquid");
            My_Info.Add(info);
            info = new Info("Alumina Solution", "Liquid");
            My_Info.Add(info);
            info = new Info("Sulfuric Acid", "Liquid");
            My_Info.Add(info);
            info = new Info("Nitric Acid", "Liquid");
            My_Info.Add(info);
            info = new Info("Nitrogen Gas", "Gas");
            My_Info.Add(info);
            info = new Info("Iron Rod", "Solid");
            My_Info.Add(info);
            info = new Info("Screw", "Solid");
            My_Info.Add(info);
            info = new Info("Iron Plate", "Solid");
            My_Info.Add(info);
            info = new Info("Reinforced Iron Plate", "Solid");
            My_Info.Add(info);
            info = new Info("Copper Sheet", "Solid");
            My_Info.Add(info);
            info = new Info("Alclad Aluminum Sheet", "Solid");
            My_Info.Add(info);
            info = new Info("Aluminum Casing", "Solid");
            My_Info.Add(info);
            info = new Info("Steel Pipe", "Solid");
            My_Info.Add(info);
            info = new Info("Steel Beam", "Solid");
            My_Info.Add(info);
            info = new Info("Encased Industrial Beam", "Solid");
            My_Info.Add(info);
            info = new Info("Modular Frame", "Solid");
            My_Info.Add(info);
            info = new Info("Heavy Modular Frame", "Solid");
            My_Info.Add(info);
            info = new Info("Fused Modular Frame", "Solid");
            My_Info.Add(info);
            info = new Info("Fabric", "Solid");
            My_Info.Add(info);
            info = new Info("Plastic", "Solid");
            My_Info.Add(info);
            info = new Info("Rubber", "Solid");
            My_Info.Add(info);
            info = new Info("Rotor", "Solid");
            My_Info.Add(info);
            info = new Info("Stator", "Solid");
            My_Info.Add(info);
            info = new Info("Battery", "Solid");
            My_Info.Add(info);
            info = new Info("Motor", "Solid");
            My_Info.Add(info);
            info = new Info("Heat Sink", "Solid");
            My_Info.Add(info);
            info = new Info("Cooling System", "Solid");
            My_Info.Add(info);
            info = new Info("Turbo Motor", "Solid");
            My_Info.Add(info);
            info = new Info("Wire", "Solid");
            My_Info.Add(info);
            info = new Info("Cable", "Solid");
            My_Info.Add(info);
            info = new Info("Quickwire", "Solid");
            My_Info.Add(info);
            info = new Info("Circuit Board", "Solid");
            My_Info.Add(info);
            info = new Info("AI Limiter", "Solid");
            My_Info.Add(info);
            info = new Info("High-Speed Connector", "Solid");
            My_Info.Add(info);
            info = new Info("Computer", "Solid");
            My_Info.Add(info);
            info = new Info("Supercomputer", "Solid");
            My_Info.Add(info);
            info = new Info("Quantum Computer", "Solid");
            My_Info.Add(info);
            info = new Info("Radio Control Unit", "Solid");
            My_Info.Add(info);
            info = new Info("Crystal Oscillator", "Solid");
            My_Info.Add(info);
            info = new Info("Superposition Oscillator", "Solid");
            My_Info.Add(info);
            info = new Info("Empty Canister", "Solid");
            My_Info.Add(info);
            info = new Info("Empty Fluid Tank", "Solid");
            My_Info.Add(info);
            info = new Info("Pressure Conversion Cube", "Solid");
            My_Info.Add(info);
            info = new Info("Packaged Water", "Solid");
            My_Info.Add(info);
            info = new Info("Packaged Alumina Solution", "Solid");
            My_Info.Add(info);
            info = new Info("Packaged Sulfuric Acid", "Solid");
            My_Info.Add(info);
            info = new Info("Packaged Nitric Acid", "Solid");
            My_Info.Add(info);
            info = new Info("Packaged Nitrogen Gas", "Solid");
            My_Info.Add(info);
            info = new Info("Leaves", "Solid");
            My_Info.Add(info);
            info = new Info("Mycelia", "Solid");
            My_Info.Add(info);
            info = new Info("Flower Petals", "Solid");
            My_Info.Add(info);
            info = new Info("Wood", "Solid");
            My_Info.Add(info);
            info = new Info("Biomass", "Solid");
            My_Info.Add(info);
            info = new Info("Compacted Coal", "Solid");
            My_Info.Add(info);
            info = new Info("Packaged Oil", "Solid");
            My_Info.Add(info);
            info = new Info("Packaged Heavy Oil Residue", "Solid");
            My_Info.Add(info);
            info = new Info("Solid Biofuel", "Solid");
            My_Info.Add(info);
            info = new Info("Packaged Fuel", "Solid");
            My_Info.Add(info);
            info = new Info("Packaged Liquid Biofuel", "Solid");
            My_Info.Add(info);
            info = new Info("Packaged Turbofuel", "Solid");
            My_Info.Add(info);
            info = new Info("Uranium Fuel Rod", "Solid");
            My_Info.Add(info);
            info = new Info("Plutonium Fuel Rod", "Solid");
            My_Info.Add(info);
            info = new Info("Black Powder", "Solid");
            My_Info.Add(info);
            info = new Info("Smokeless Powder", "Solid");
            My_Info.Add(info);
            info = new Info("Gas Filter", "Solid");
            My_Info.Add(info);
            info = new Info("Color Cartridge", "Solid");
            My_Info.Add(info);
            info = new Info("Beacon", "Solid");
            My_Info.Add(info);
            info = new Info("Iodine Infused Filter", "Solid");
            My_Info.Add(info);
            info = new Info("Iron Rebar", "Solid");
            My_Info.Add(info);
            info = new Info("Stun Rebar", "Solid");
            My_Info.Add(info);
            info = new Info("Shatter Rebar", "Solid");
            My_Info.Add(info);
            info = new Info("Explosive Rebar", "Solid");
            My_Info.Add(info);
            info = new Info("Rifle Ammo", "Solid");
            My_Info.Add(info);
            info = new Info("Homing Rifle Ammo", "Solid");
            My_Info.Add(info);
            info = new Info("Turbo Rifle Ammo", "Solid");
            My_Info.Add(info);
            info = new Info("Nobelisk", "Solid");
            My_Info.Add(info);
            info = new Info("Gas Nobelisk", "Solid");
            My_Info.Add(info);
            info = new Info("Pulse Nobelisk", "Solid");
            My_Info.Add(info);
            info = new Info("Cluster Nobelisk", "Solid");
            My_Info.Add(info);
            info = new Info("Nuke Nobelisk", "Solid");
            My_Info.Add(info);
            info = new Info("Electromagnetic Control Rod", "Solid");
            My_Info.Add(info);
            info = new Info("Encased Uranium Cell", "Solid");
            My_Info.Add(info);
            info = new Info("Non-fissile Uranium", "Solid");
            My_Info.Add(info);
            info = new Info("Plutonium Pellet", "Solid");
            My_Info.Add(info);
            info = new Info("Encased Plutonium Cell", "Solid");
            My_Info.Add(info);
            info = new Info("Uranium Waste", "Solid");
            My_Info.Add(info);
            info = new Info("Plutonium Waste", "Solid");
            My_Info.Add(info);
            info = new Info("Blue Power Slug", "Solid");
            My_Info.Add(info);
            info = new Info("Yellow Power Slug", "Solid");
            My_Info.Add(info);
            info = new Info("Purple Power Slug", "Solid");
            My_Info.Add(info);
            info = new Info("Power Shard", "Solid");
            My_Info.Add(info);
            info = new Info("FICSIT Coupon", "Solid");
            My_Info.Add(info);
            info = new Info("Smart Plating", "Solid");
            My_Info.Add(info);
            info = new Info("Versatile Framework", "Solid");
            My_Info.Add(info);
            info = new Info("Automated Wiring", "Solid");
            My_Info.Add(info);
            info = new Info("Modular Engine", "Solid");
            My_Info.Add(info);
            info = new Info("Adaptive Control Unit", "Solid");
            My_Info.Add(info);
            info = new Info("Assembly Director System", "Solid");
            My_Info.Add(info);
            info = new Info("Magnetic Field Generator", "Solid");
            My_Info.Add(info);
            info = new Info("Thermal Propulsion Rocket", "Solid");
            My_Info.Add(info);
            info = new Info("Nuclear Pasta", "Solid");
            My_Info.Add(info);
            info = new Info("Portable Miner", "Solid");
            My_Info.Add(info);
            info = new Info("FICSMAS Gift", "Solid");
            My_Info.Add(info);
            info = new Info("Candy Cane", "Solid");
            My_Info.Add(info);
            info = new Info("Actual Snow", "Solid");
            My_Info.Add(info);
            info = new Info("Red FICSMAS Ornament", "Solid");
            My_Info.Add(info);
            info = new Info("Blue FICSMAS Ornament", "Solid");
            My_Info.Add(info);
            info = new Info("Copper FICSMAS Ornament", "Solid");
            My_Info.Add(info);
            info = new Info("Iron FICSMAS Ornament", "Solid");
            My_Info.Add(info);
            info = new Info("FICSMAS Ornament Bundle", "Solid");
            My_Info.Add(info);
            info = new Info("FICSMAS Bow", "Solid");
            My_Info.Add(info);
            info = new Info("FICSMAS Tree Branch", "Solid");
            My_Info.Add(info);
            info = new Info("FICSMAS Wonder Star", "Solid");
            My_Info.Add(info);
            info = new Info("FICSMAS Decoration", "Solid");
            My_Info.Add(info);
            info = new Info("Snowball", "Solid");
            My_Info.Add(info);
            info = new Info("Sweet Fireworks", "Solid");
            My_Info.Add(info);
            info = new Info("Fancy Fireworks", "Solid");
            My_Info.Add(info);
            info = new Info("Sparkly Fireworks", "Solid");
            My_Info.Add(info);
        }
    }
}
