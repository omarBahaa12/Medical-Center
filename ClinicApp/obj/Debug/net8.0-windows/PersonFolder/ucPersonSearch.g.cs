﻿#pragma checksum "..\..\..\..\PersonFolder\ucPersonSearch.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0280822E8C5B9DE4B0116470114FC2FFFAC8F34E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using UI.PersonFolder;


namespace UI.PersonFolder {
    
    
    /// <summary>
    /// ucPersonSearch
    /// </summary>
    public partial class ucPersonSearch : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\PersonFolder\ucPersonSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Cbox_SearchBy;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\PersonFolder\ucPersonSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tb_Search;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\PersonFolder\ucPersonSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Search;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UI;component/personfolder/ucpersonsearch.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\PersonFolder\ucPersonSearch.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\PersonFolder\ucPersonSearch.xaml"
            ((UI.PersonFolder.ucPersonSearch)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Cbox_SearchBy = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\..\PersonFolder\ucPersonSearch.xaml"
            this.Cbox_SearchBy.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Cbox_SearchBy_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Tb_Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\..\PersonFolder\ucPersonSearch.xaml"
            this.Tb_Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Tb_Search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Btn_Search = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\PersonFolder\ucPersonSearch.xaml"
            this.Btn_Search.Click += new System.Windows.RoutedEventHandler(this.Btn_Search_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

