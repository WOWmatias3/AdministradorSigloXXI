﻿#pragma checksum "..\..\ListarPedidos.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9F46403B4F187F6762F7990DA7E33460F9E837AB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

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
using restaurantexxi_adminstrador;


namespace restaurantexxi_adminstrador {
    
    
    /// <summary>
    /// ListarPedidos
    /// </summary>
    public partial class ListarPedidos : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ListarPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_nombreusuario;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ListarPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdb_aceptadas;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ListarPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdb_anulada;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ListarPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdb_este_mes;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ListarPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdb_ingrediente;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ListarPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdb_bebestible;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ListarPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_listar;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ListarPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg_listas;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ListarPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_limpiar;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ListarPedidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb1;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ListarPedidos.xaml"
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
            System.Uri resourceLocater = new System.Uri("/restaurantexxi adminstrador;component/listarpedidos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ListarPedidos.xaml"
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
            this.rdb_aceptadas = ((System.Windows.Controls.RadioButton)(target));
            
            #line 15 "..\..\ListarPedidos.xaml"
            this.rdb_aceptadas.Checked += new System.Windows.RoutedEventHandler(this.Rdb_aceptadas_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rdb_anulada = ((System.Windows.Controls.RadioButton)(target));
            
            #line 16 "..\..\ListarPedidos.xaml"
            this.rdb_anulada.Checked += new System.Windows.RoutedEventHandler(this.Rdb_anulada_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rdb_este_mes = ((System.Windows.Controls.RadioButton)(target));
            
            #line 17 "..\..\ListarPedidos.xaml"
            this.rdb_este_mes.Checked += new System.Windows.RoutedEventHandler(this.Rdb_este_mes_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rdb_ingrediente = ((System.Windows.Controls.RadioButton)(target));
            
            #line 20 "..\..\ListarPedidos.xaml"
            this.rdb_ingrediente.Checked += new System.Windows.RoutedEventHandler(this.Rdb_ingrediente_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.rdb_bebestible = ((System.Windows.Controls.RadioButton)(target));
            
            #line 21 "..\..\ListarPedidos.xaml"
            this.rdb_bebestible.Checked += new System.Windows.RoutedEventHandler(this.Rdb_bebestible_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_listar = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\ListarPedidos.xaml"
            this.btn_listar.Click += new System.Windows.RoutedEventHandler(this.Btn_listar_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dtg_listas = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.btn_limpiar = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\ListarPedidos.xaml"
            this.btn_limpiar.Click += new System.Windows.RoutedEventHandler(this.Btn_limpiar_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.lb1 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.btn_atras = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\ListarPedidos.xaml"
            this.btn_atras.Click += new System.Windows.RoutedEventHandler(this.Btn_atras_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
