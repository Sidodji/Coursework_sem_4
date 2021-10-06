﻿#pragma checksum "..\..\..\Views\Registration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7082E889E649217BFE99461048E0B536562C2699C512A11D85709C5F1D587C89"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using WorldOfBook;


namespace WorldOfBook {
    
    
    /// <summary>
    /// Registration
    /// </summary>
    public partial class Registration : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon RegName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameUser;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon RegSurname;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SurnameUser;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon RegUserName;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UsernameUser;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon RegPassword;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordUser;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegistrationButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackToLoginButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WorldOfBook;component/views/registration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Registration.xaml"
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
            this.RegName = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 2:
            this.NameUser = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\Views\Registration.xaml"
            this.NameUser.GotFocus += new System.Windows.RoutedEventHandler(this.RegNameTxt_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RegSurname = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 4:
            this.SurnameUser = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\Views\Registration.xaml"
            this.SurnameUser.GotFocus += new System.Windows.RoutedEventHandler(this.RegSurnameTxt_GotFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RegUserName = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 6:
            this.UsernameUser = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\Views\Registration.xaml"
            this.UsernameUser.GotFocus += new System.Windows.RoutedEventHandler(this.RegUserNameTxt_GotFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RegPassword = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 8:
            this.PasswordUser = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 34 "..\..\..\Views\Registration.xaml"
            this.PasswordUser.GotFocus += new System.Windows.RoutedEventHandler(this.RegPasswordTxt_GotFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.RegistrationButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Views\Registration.xaml"
            this.RegistrationButton.Click += new System.Windows.RoutedEventHandler(this.RegistrationButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BackToLoginButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Views\Registration.xaml"
            this.BackToLoginButton.Click += new System.Windows.RoutedEventHandler(this.BackToLoginButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

