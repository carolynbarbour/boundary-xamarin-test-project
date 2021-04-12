using System;
using MvvmCross;
using MvvmCross.Plugin.Sidebar;
using MvvmCross.Plugin.Sidebar.Views;
using MvvmCross.ViewModels;
using UIKit;

namespace code_test.iOS.Views.Base
{
    public class BaseMenuViewController<TViewModel> : BaseViewController<TViewModel>, IMvxSidebarMenu where TViewModel : class, IMvxViewModel
    {
        public virtual UIImage MenuButtonImage => UIImage.FromBundle("menu");

        public virtual bool AnimateMenu => true;
        public virtual float DarkOverlayAlpha => 0;
        public virtual bool HasDarkOverlay => false;
        public virtual bool HasShadowing => false;
        public virtual float ShadowOpacity => 0.5f;
        public virtual float ShadowRadius => 4.0f;
        public virtual UIColor ShadowColor => UIColor.Black;
        public virtual bool DisablePanGesture => false;
        public virtual bool ReopenOnRotate => true;

        private int MaxMenuWidth = 300;
        private int MinSpaceRightOfTheMenu = 55;

        public int MenuWidth => UserInterfaceIdiomIsPhone ?
            int.Parse(UIScreen.MainScreen.Bounds.Width.ToString()) - MinSpaceRightOfTheMenu : MaxMenuWidth;

        private bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.LeftBarButtonItem = new UIBarButtonItem(MenuButtonImage, UIBarButtonItemStyle.Plain, HandleMenu);
        }

        void HandleMenu(object sender, EventArgs e)
        {
            var sideMenu = Mvx.IoCProvider.Resolve<IMvxSidebarViewController>();
            if(((MvxSidebarViewController)sideMenu).LeftSidebarController.IsOpen)
            {
                sideMenu?.CloseMenu();
            }
            else
            {
                sideMenu?.Open(MvxPanelEnum.Left);
            }
        }

        public virtual void MenuWillOpen()
        { 
        }

        public virtual void MenuDidOpen()
        {
        }

        public virtual void MenuWillClose()
        {
        }

        public virtual void MenuDidClose()
        {
        }
    }
}