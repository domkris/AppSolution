﻿#pragma checksum "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1C717FB02A99F76E57C7E5CFBF4652A9017B85F5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MainApp.UserControls.AdministrateUserControls;
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


namespace MainApp.UserControls.AdministrateUserControls {
    
    
    /// <summary>
    /// ApplicationsUserControl
    /// </summary>
    public partial class ApplicationsUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock selectedCategory;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboTitles;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxName;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEdit;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxNewApplication;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreate;
        
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
            System.Uri resourceLocater = new System.Uri("/MainApp;component/usercontrols/administrateusercontrols/applicationsusercontrol." +
                    "xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
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
            this.selectedCategory = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.comboTitles = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
            this.comboTitles.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboTitles_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
            this.btnEdit.Click += new System.Windows.RoutedEventHandler(this.BtnEdit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.BtnSave_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.BtnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtBoxNewApplication = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnCreate = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\UserControls\AdministrateUserControls\ApplicationsUserControl.xaml"
            this.btnCreate.Click += new System.Windows.RoutedEventHandler(this.BtnCreate_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

