﻿#pragma checksum "..\..\..\Windows\AllProfessorsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "59A19DA87F728ECAB4AC7E45672A5B2EB0C4883B214449DA9A3910097538148A"
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
    /// AllProfessorsWindow
    /// </summary>
    public partial class AllProfessorsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Windows\AllProfessorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miAddProfessor;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Windows\AllProfessorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miUpdateProfessor;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Windows\AllProfessorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miDeleteProfessor;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Windows\AllProfessorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Windows\AllProfessorsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgProfessors;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/windows/allprofessorswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AllProfessorsWindow.xaml"
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
            this.miAddProfessor = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\..\Windows\AllProfessorsWindow.xaml"
            this.miAddProfessor.Click += new System.Windows.RoutedEventHandler(this.miAddProfessor_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.miUpdateProfessor = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\..\Windows\AllProfessorsWindow.xaml"
            this.miUpdateProfessor.Click += new System.Windows.RoutedEventHandler(this.miUpdateProfessor_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.miDeleteProfessor = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\..\Windows\AllProfessorsWindow.xaml"
            this.miDeleteProfessor.Click += new System.Windows.RoutedEventHandler(this.miDeleteProfessor_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\Windows\AllProfessorsWindow.xaml"
            this.txtSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSearch_TextChanged);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\Windows\AllProfessorsWindow.xaml"
            this.txtSearch.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtSearch_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dgProfessors = ((System.Windows.Controls.DataGrid)(target));
            
            #line 31 "..\..\..\Windows\AllProfessorsWindow.xaml"
            this.dgProfessors.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgProfessors_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

