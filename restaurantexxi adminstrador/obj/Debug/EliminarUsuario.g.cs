﻿#pragma checksum "..\..\EliminarUsuario.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4854378CC591F3EBA9F9E94F803680BEA186389C"
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
    /// EliminarUsuario
    /// </summary>
    public partial class EliminarUsuario : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\EliminarUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal restaurantexxi_adminstrador.EliminarUsuario win_eliminaruser;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\EliminarUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_nombreusuario;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\EliminarUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_rut;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\EliminarUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_delete;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\EliminarUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_atras;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\EliminarUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CONFIRMAR;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\EliminarUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg_eliminar;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\EliminarUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb1;
        
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
            System.Uri resourceLocater = new System.Uri("/restaurantexxi adminstrador;component/eliminarusuario.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EliminarUsuario.xaml"
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
            this.win_eliminaruser = ((restaurantexxi_adminstrador.EliminarUsuario)(target));
            
            #line 9 "..\..\EliminarUsuario.xaml"
            this.win_eliminaruser.Loaded += new System.Windows.RoutedEventHandler(this.Win_eliminaruser_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lb_nombreusuario = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.txt_rut = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\EliminarUsuario.xaml"
            this.txt_rut.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Txt_rut_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 20 "..\..\EliminarUsuario.xaml"
            this.txt_rut.GotFocus += new System.Windows.RoutedEventHandler(this.Txt_rut_GotFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_delete = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\EliminarUsuario.xaml"
            this.btn_delete.Click += new System.Windows.RoutedEventHandler(this.Btn_delete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_atras = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\EliminarUsuario.xaml"
            this.btn_atras.Click += new System.Windows.RoutedEventHandler(this.Btn_atras_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CONFIRMAR = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.dtg_eliminar = ((System.Windows.Controls.DataGrid)(target));
            
            #line 24 "..\..\EliminarUsuario.xaml"
            this.dtg_eliminar.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Dtg_eliminar_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lb1 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

