﻿#pragma checksum "..\..\EliminarInsumo.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FF6E0C75A23FD46B06F700486E0FAB9AD7C8FF70"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using AplicacionBar;
using MahApps.Metro.Controls;
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


namespace AplicacionBar {
    
    
    /// <summary>
    /// prueba4
    /// </summary>
    public partial class prueba4 : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\EliminarInsumo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_nombreusuario;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\EliminarInsumo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbt_ing;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\EliminarInsumo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbt_bebi;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\EliminarInsumo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg_eli;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\EliminarInsumo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_id_eli_ing;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\EliminarInsumo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_id_eli;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\EliminarInsumo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_eli;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\EliminarInsumo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_id_eli_bebi;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\EliminarInsumo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_1;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\EliminarInsumo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_atras;
        
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
            System.Uri resourceLocater = new System.Uri("/restaurantexxi adminstrador;component/eliminarinsumo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EliminarInsumo.xaml"
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
            this.lb_nombreusuario = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.rbt_ing = ((System.Windows.Controls.RadioButton)(target));
            
            #line 13 "..\..\EliminarInsumo.xaml"
            this.rbt_ing.Checked += new System.Windows.RoutedEventHandler(this.rbt_ing_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rbt_bebi = ((System.Windows.Controls.RadioButton)(target));
            
            #line 14 "..\..\EliminarInsumo.xaml"
            this.rbt_bebi.Checked += new System.Windows.RoutedEventHandler(this.rbt_bebi_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dtg_eli = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\EliminarInsumo.xaml"
            this.dtg_eli.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Dtg_eli_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txt_id_eli_ing = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\EliminarInsumo.xaml"
            this.txt_id_eli_ing.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_id_eli_ing_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lbl_id_eli = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btn_eli = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\EliminarInsumo.xaml"
            this.btn_eli.Click += new System.Windows.RoutedEventHandler(this.btn_eli_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txt_id_eli_bebi = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\EliminarInsumo.xaml"
            this.txt_id_eli_bebi.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_id_eli_bebi_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lbl_1 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.btn_atras = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\EliminarInsumo.xaml"
            this.btn_atras.Click += new System.Windows.RoutedEventHandler(this.Btn_atras_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

