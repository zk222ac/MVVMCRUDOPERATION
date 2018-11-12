using System;
using MVVMCRUDOperation.Model;
using MVVMCRUDOperation.View;

namespace MVVMCRUDOperation.ViewModel
{
    class Page1Vm
    {
        public RelayCommand GoMainPageCommand { get; set; }
        public FrameNavigate FrameNavigate { get; set; }
        public Singleton Singleton;
        public string Country { get; set; }
        public string City { get; set; }

        public string Image { get; set; }
        public Page1Vm()
        {
            GoMainPageCommand = new RelayCommand(DoGoMainPage);
            FrameNavigate = new FrameNavigate();
            Singleton = Singleton.GetInstance();
            //Retrieve the object instance from the Global Instance
             Country = Singleton.GetCountry();
             City = Singleton.GetCity();
             Image = Singleton.GetImageUrl();
             
        }
        public void DoGoMainPage()
        {
            // Redirect Page1 to MainPage
            Type type = typeof(MainPage);
            FrameNavigate.ActivateFrameNavigation(type);
            
        }
    }
}
