﻿#pragma checksum "..\..\..\Windows\AllStudentsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "58E088027224F481B005EC13860BD78BCEEBF09CAB1B47BAB8A966B10EA3651F"
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
    /// AllStudentsWindow
    /// </summary>
    public partial class AllStudentsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Windows\AllStudentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miAddStudent;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Windows\AllStudentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miUpdateStudent;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Windows\AllStudentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miDeleteStudent;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Windows\AllStudentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSearch;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Windows\AllStudentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Windows\AllStudentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgStudents;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/windows/allstudentswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AllStudentsWindow.xaml"
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
            this.miAddStudent = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\..\Windows\AllStudentsWindow.xaml"
            this.miAddStudent.Click += new System.Windows.RoutedEventHandler(this.miAddStudent_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.miUpdateStudent = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\..\Windows\AllStudentsWindow.xaml"
            this.miUpdateStudent.Click += new System.Windows.RoutedEventHandler(this.miUpdateStudent_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.miDeleteStudent = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\..\Windows\AllStudentsWindow.xaml"
            this.miDeleteStudent.Click += new System.Windows.RoutedEventHandler(this.miDeleteStudent_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblSearch = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\Windows\AllStudentsWindow.xaml"
            this.txtSearch.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtSearch_KeyUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dgStudents = ((System.Windows.Controls.DataGrid)(target));
            
            #line 31 "..\..\..\Windows\AllStudentsWindow.xaml"
            this.dgStudents.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgStudents_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
