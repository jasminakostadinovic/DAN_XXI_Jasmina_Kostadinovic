using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_XXI_Zadatak.Models.Menus
{
    class MenuOptions
    {
        public List<string> Options { get; set; }

        public override string ToString()
        {
            var text = string.Empty;
            var counter = 1;
            if (Options.Any())
            {
                foreach (var option in Options)
                {
                    text += string.Format($"{counter}. {option}\n");
                    counter++;
                }
                return text;
            }
            return text;
        }
    }
}
