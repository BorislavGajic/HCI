﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "779357C58F862C22E8A944F4106BC71D483074F7"
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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Resurs;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView Stablo;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas imgPanel;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image mapa;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pomoc;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.Resurs = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\MainWindow.xaml"
            this.Resurs.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 17 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 18 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 19 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Stablo = ((System.Windows.Controls.TreeView)(target));
            
            #line 20 "..\..\MainWindow.xaml"
            this.Stablo.AddHandler(System.Windows.Controls.TreeViewItem.SelectedEvent, new System.Windows.RoutedEventHandler(this.TreeViewItem_OnItemSelected));
            
            #line default
            #line hidden
            
            #line 20 "..\..\MainWindow.xaml"
            this.Stablo.SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.Stablo_SelectedItemChanged);
            
            #line default
            #line hidden
            
            #line 20 "..\..\MainWindow.xaml"
            this.Stablo.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TreeView_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 20 "..\..\MainWindow.xaml"
            this.Stablo.MouseMove += new System.Windows.Input.MouseEventHandler(this.TreeView_MouseMove);
            
            #line default
            #line hidden
            return;
            case 6:
            this.imgPanel = ((System.Windows.Controls.Canvas)(target));
            
            #line 29 "..\..\MainWindow.xaml"
            this.imgPanel.Drop += new System.Windows.DragEventHandler(this.Panel_Drop);
            
            #line default
            #line hidden
            
            #line 29 "..\..\MainWindow.xaml"
            this.imgPanel.DragEnter += new System.Windows.DragEventHandler(this.Panel_DragEnter);
            
            #line default
            #line hidden
            
            #line 29 "..\..\MainWindow.xaml"
            this.imgPanel.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Panel_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 29 "..\..\MainWindow.xaml"
            this.imgPanel.MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Panel_PreviewMouseRightButtonDown);
            
            #line default
            #line hidden
            
            #line 29 "..\..\MainWindow.xaml"
            this.imgPanel.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ImgPanel_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.mapa = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.pomoc = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\MainWindow.xaml"
            this.pomoc.Click += new System.Windows.RoutedEventHandler(this.About_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 34 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_4);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

