﻿#pragma checksum "..\..\..\Windows\AllClassesWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D7CBA3D769510EA31A867B47DE8186D658A2E7CAC952D3669818839CB43EC5AD"
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
using WpfApp2.Windows;


namespace WpfApp2.Windows {
    
    
    /// <summary>
    /// AllClassesWindow
    /// </summary>
    public partial class AllClassesWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Windows\AllClassesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miAddClass;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Windows\AllClassesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miUpdateClass;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Windows\AllClassesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miDeleteClass;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Windows\AllClassesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Windows\AllClassesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgClass;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/windows/allclasseswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AllClassesWindow.xaml"
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
            this.miAddClass = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\..\Windows\AllClassesWindow.xaml"
            this.miAddClass.Click += new System.Windows.RoutedEventHandler(this.miAddClass_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.miUpdateClass = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\..\Windows\AllClassesWindow.xaml"
            this.miUpdateClass.Click += new System.Windows.RoutedEventHandler(this.miUpdateClass_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.miDeleteClass = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\..\Windows\AllClassesWindow.xaml"
            this.miDeleteClass.Click += new System.Windows.RoutedEventHandler(this.miDeleteClass_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\Windows\AllClassesWindow.xaml"
            this.txtSearch.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtSearch_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dgClass = ((System.Windows.Controls.DataGrid)(target));
            
            #line 33 "..\..\..\Windows\AllClassesWindow.xaml"
            this.dgClass.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgClass_AutoGeneratingColumn);
            
            #line default
            #line hidden
            
            #line 33 "..\..\..\Windows\AllClassesWindow.xaml"
            this.dgClass.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgClass_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
