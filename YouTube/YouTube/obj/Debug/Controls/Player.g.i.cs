﻿

#pragma checksum "C:\Users\ITALO\Documents\Visual Studio 2013\Projects\YouTube\YouTube\Controls\Player.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "957E02820E8B1135DACFCDE54B0D7034"
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
    partial class Player : global::Windows.UI.Xaml.Controls.UserControl
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Canvas PlayCanvas; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Canvas PauseCanvas; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Primitives.ToggleButton PlayPause; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Primitives.ToggleButton Volume; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button Settings; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Primitives.ToggleButton FullScreen; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///Controls/Player.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            PlayCanvas = (global::Windows.UI.Xaml.Controls.Canvas)this.FindName("PlayCanvas");
            PauseCanvas = (global::Windows.UI.Xaml.Controls.Canvas)this.FindName("PauseCanvas");
            PlayPause = (global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)this.FindName("PlayPause");
            Volume = (global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)this.FindName("Volume");
            Settings = (global::Windows.UI.Xaml.Controls.Button)this.FindName("Settings");
            FullScreen = (global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)this.FindName("FullScreen");
        }
    }
}



