﻿

#pragma checksum "C:\Users\ITALO\Documents\Visual Studio 2013\Projects\YouTube\YouTube\Controls\SearchBox.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7D596881AF0448B7468D21BEE4C42941"
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
    partial class SearchBox : global::Windows.UI.Xaml.Controls.UserControl, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 58 "..\..\Controls\SearchBox.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Button_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 56 "..\..\Controls\SearchBox.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).KeyDown += this.SearchBoxField_KeyDown;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


