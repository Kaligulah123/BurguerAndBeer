using BurguerAndBeer.Mobile.MVVM.ViewModels;
using Google.Android.Material.Badge;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShellItem = Microsoft.Maui.Controls.ShellItem;

namespace BurguerAndBeer.Mobile
{
    public class TabbarBadgeRenderer : ShellRenderer
    {
        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new BadgeShellBottomNavViewAppearanceTracker(this, shellItem);
        }

        class BadgeShellBottomNavViewAppearanceTracker : ShellBottomNavViewAppearanceTracker
        {          
            private BadgeDrawable? _badgeDrawable;
            public BadgeShellBottomNavViewAppearanceTracker(IShellContext shellContext, ShellItem shellItem) : base(shellContext, shellItem)
            {
                
            }

            public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
            {
                base.SetAppearance(bottomView, appearance);

                if (_badgeDrawable is null)
                {
                    const int cartTabbarItemIndex = 1;

                    _badgeDrawable = bottomView.GetOrCreateBadge(cartTabbarItemIndex);
                    UpdateBadge(CartViewmodel.TotalCartCount);
                    CartViewmodel.TotalCartCountChanged += CartViewmodel_TotalCartCountChanged;
                }               
            }

            private void CartViewmodel_TotalCartCountChanged(object? sender, int newCount) => UpdateBadge(newCount);

            private void UpdateBadge(int count)
            {
                if (count <= 0)
                {
                    _badgeDrawable.SetVisible(false);
                }
                else
                {
                    _badgeDrawable.Number = count;
                    _badgeDrawable.BackgroundColor = Colors.Red.ToPlatform();
                    _badgeDrawable.BadgeTextColor = Colors.White.ToPlatform();
                    _badgeDrawable.SetVisible(true);
                }
            }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);

                CartViewmodel.TotalCartCountChanged -= CartViewmodel_TotalCartCountChanged;               
            }
        }
    }

       

}
