﻿#pragma checksum "..\..\..\CreateCard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D1BF26C006282C1C61A4574734165CB060303FCE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LeitnerBoxNew;
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


namespace LeitnerBoxNew {
    
    
    /// <summary>
    /// CreateCard
    /// </summary>
    public partial class CreateCard : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\CreateCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbQuestion;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\CreateCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbAnswer;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\CreateCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblErrorMessage;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\CreateCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\CreateCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBoxSave;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LeitnerBoxNew;V1.0.0.0;component/createcard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CreateCard.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbQuestion = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\CreateCard.xaml"
            this.tbQuestion.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbQuestion_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbAnswer = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\CreateCard.xaml"
            this.tbAnswer.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbAnswer_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblErrorMessage = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\CreateCard.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\CreateCard.xaml"
            this.btnCancel.MouseMove += new System.Windows.Input.MouseEventHandler(this.btnCancel_MouseMove);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\CreateCard.xaml"
            this.btnCancel.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btnCancel_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnBoxSave = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\CreateCard.xaml"
            this.btnBoxSave.Click += new System.Windows.RoutedEventHandler(this.btnBoxSave_Click);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\CreateCard.xaml"
            this.btnBoxSave.MouseMove += new System.Windows.Input.MouseEventHandler(this.btnBoxSave_MouseMove);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\CreateCard.xaml"
            this.btnBoxSave.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btnBoxSave_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

