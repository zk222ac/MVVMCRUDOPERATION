using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MVVMCRUDOperation.Model
{
    class FrameNavigate
    {
        // How to enable navigation between Pages A---->B in the ViewModel
        public void ActivateFrameNavigation(Type type)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(type);
            Window.Current.Content = frame;
            Window.Current.Activate();
        }
    }
}
