using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Culculator
{
    internal class CulcAll
    {
        

        public string currentCulculations = "";
        public void RenderCulculations()
        {
            MainWindow mainWindow = new MainWindow();
            OptionalWindow optionalWindow = new OptionalWindow();
            mainWindow.textPanel.Text = currentCulculations;
            optionalWindow.textPanel.Text = currentCulculations;  
        }

        public void UpdateRender(string newData) {
            if (newData != "clear")
                currentCulculations += newData;
            else
                currentCulculations = "";
            Console.WriteLine(currentCulculations);
            RenderCulculations();
        }

    }
}
