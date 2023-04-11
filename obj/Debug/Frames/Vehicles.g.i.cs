﻿#pragma checksum "..\..\..\Frames\Vehicles.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2F20573A180DE9CD21653737F390A74C663FAC2742BF867689987E16774EF94D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Satisfactory_Calculator;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Satisfactory_Calculator {
    
    
    /// <summary>
    /// Vehicles
    /// </summary>
    public partial class Vehicles : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\Frames\Vehicles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBVehicle;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Frames\Vehicles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewAllVehicles;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\Frames\Vehicles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddVehicle;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Frames\Vehicles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBMyVehicle;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Frames\Vehicles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBMyDivided;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Frames\Vehicles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewMyVehicles;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\Frames\Vehicles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRemoveVehicle;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\Frames\Vehicles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRemovePercentage;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\Frames\Vehicles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBPercentage;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\Frames\Vehicles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddPercentage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Satisfactory Calculator;component/frames/vehicles.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Frames\Vehicles.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CBVehicle = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\Frames\Vehicles.xaml"
            this.CBVehicle.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AllVehiclesSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ListViewAllVehicles = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.BtnAddVehicle = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\Frames\Vehicles.xaml"
            this.BtnAddVehicle.Click += new System.Windows.RoutedEventHandler(this.BtnAddVehicle_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CBMyVehicle = ((System.Windows.Controls.ComboBox)(target));
            
            #line 94 "..\..\..\Frames\Vehicles.xaml"
            this.CBMyVehicle.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MyVehiclesSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CBMyDivided = ((System.Windows.Controls.ComboBox)(target));
            
            #line 105 "..\..\..\Frames\Vehicles.xaml"
            this.CBMyDivided.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MyVehiclesSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ListViewMyVehicles = ((System.Windows.Controls.ListView)(target));
            
            #line 115 "..\..\..\Frames\Vehicles.xaml"
            this.ListViewMyVehicles.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListViewMyVehicles_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnRemoveVehicle = ((System.Windows.Controls.Button)(target));
            
            #line 173 "..\..\..\Frames\Vehicles.xaml"
            this.BtnRemoveVehicle.Click += new System.Windows.RoutedEventHandler(this.BtnRemoveVehicle_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnRemovePercentage = ((System.Windows.Controls.Button)(target));
            
            #line 176 "..\..\..\Frames\Vehicles.xaml"
            this.BtnRemovePercentage.Click += new System.Windows.RoutedEventHandler(this.BtnRemovePercentage_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TBPercentage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.BtnAddPercentage = ((System.Windows.Controls.Button)(target));
            
            #line 180 "..\..\..\Frames\Vehicles.xaml"
            this.BtnAddPercentage.Click += new System.Windows.RoutedEventHandler(this.BtnAddPercentage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

