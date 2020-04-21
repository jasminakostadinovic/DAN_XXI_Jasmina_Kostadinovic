using Dan_XXI_Zadatak.Models.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_XXI_Zadatak.Interfaces
{
    interface IMenu
    {
        void CreateMenu(MenuOptions options, string message);
    }
}
