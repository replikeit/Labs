﻿#pragma checksum "..\..\..\..\Core\View\AddCinemaPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CD80D023F2751A1242B141125DA5668273B1EBCC4A6AF1AD1EA58C9E39EC59F8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using lab6.Core.View;


namespace lab6.Core.View {
    
    
    /// <summary>
    /// AddCinemaPage
    /// </summary>
    public partial class AddCinemaPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\Core\View\AddCinemaPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddCinemaButton;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Core\View\AddCinemaPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CinemaNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Core\View\AddCinemaPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StreetCinemaTextBox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Core\View\AddCinemaPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GoBackButton;
        
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
            System.Uri resourceLocater = new System.Uri("/lab6;component/core/view/addcinemapage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Core\View\AddCinemaPage.xaml"
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
            this.AddCinemaButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Core\View\AddCinemaPage.xaml"
            this.AddCinemaButton.Click += new System.Windows.RoutedEventHandler(this.AddCinemaButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CinemaNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.StreetCinemaTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.GoBackButton = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\Core\View\AddCinemaPage.xaml"
            this.GoBackButton.Click += new System.Windows.RoutedEventHandler(this.GoBackButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
