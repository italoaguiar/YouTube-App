﻿

#pragma checksum "C:\Users\ITALO\Documents\Visual Studio 2013\Projects\YouTube\YouTube\Controls\UserMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0EDF888FBC44BC5FB0612B9F974C8EDE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YouTube.Controls
{
    partial class UserMenu : global::Windows.UI.Xaml.Controls.UserControl, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 18 "..\..\Controls\UserMenu.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.LoginButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 29 "..\..\Controls\UserMenu.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.MenuFlyoutItem_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


