﻿#pragma checksum "..\..\..\Frames\Generators.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FA0492FBE0521C02054D685430F3EC64FE9B4CB03BCDA43994D5BE1553678F6A"
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
    /// Generators
    /// </summary>
    public partial class Generators : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\Frames\Generators.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBBuilding;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Frames\Generators.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewAllGenerators;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\Frames\Generators.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddBuilding;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Frames\Generators.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBMyBuilding;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Frames\Generators.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBMyDivided;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Frames\Generators.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewMyGenerators;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\Frames\Generators.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRemoveBuilding;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\Frames\Generators.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRemovePercentage;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\Frames\Generators.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBPercentage;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\Frames\Generators.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Satisfactory Calculator;component/frames/generators.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Frames\Generators.xaml"
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
            this.CBBuilding = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\Frames\Generators.xaml"
            this.CBBuilding.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AllGeneratorsSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ListViewAllGenerators = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.BtnAddBuilding = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\Frames\Generators.xaml"
            this.BtnAddBuilding.Click += new System.Windows.RoutedEventHandler(this.BtnAddBuilding_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CBMyBuilding = ((System.Windows.Controls.ComboBox)(target));
            
            #line 94 "..\..\..\Frames\Generators.xaml"
            this.CBMyBuilding.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MyGeneratorsSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CBMyDivided = ((System.Windows.Controls.ComboBox)(target));
            
            #line 105 "..\..\..\Frames\Generators.xaml"
            this.CBMyDivided.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MyGeneratorsSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ListViewMyGenerators = ((System.Windows.Controls.ListView)(target));
            
            #line 115 "..\..\..\Frames\Generators.xaml"
            this.ListViewMyGenerators.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListViewMyBuildings_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnRemoveBuilding = ((System.Windows.Controls.Button)(target));
            
            #line 173 "..\..\..\Frames\Generators.xaml"
            this.BtnRemoveBuilding.Click += new System.Windows.RoutedEventHandler(this.BtnRemoveBuilding_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnRemovePercentage = ((System.Windows.Controls.Button)(target));
            
            #line 176 "..\..\..\Frames\Generators.xaml"
            this.BtnRemovePercentage.Click += new System.Windows.RoutedEventHandler(this.BtnRemovePercentage_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TBPercentage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.BtnAddPercentage = ((System.Windows.Controls.Button)(target));
            
            #line 180 "..\..\..\Frames\Generators.xaml"
            this.BtnAddPercentage.Click += new System.Windows.RoutedEventHandler(this.BtnAddPercentage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
