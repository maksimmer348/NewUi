using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace NewUi
{
    public enum CycleColor
    {
        Red,
        Green,
        Blue,
        Olive,
        Yellow,
        Purpule
    }

    public class UiController
    {
        private Random rnd = new Random();
        public List<Control> ProgramUiElements = new();
        public List<Control> ProgramsListUiElements = new();
        
        public List<Control> CycleUiElements = new();
        public List<Control> CycleUiElementsChangeColor = new();
        private Queue<Color> cycleColorList = new();
        
        //private Color currentCycleColor;
        /// <summary>
        /// элменты задействованые при создании и изменении тестовой программы
        /// </summary>
        /// <param name="controls">список элементов</param>
        public void ProgramUiElementListAdd(params Control[] controls)
        {
            foreach (var control in controls)
            {
                ProgramUiElements.Add(control);
            }
        }

        /// <summary>
        /// элменты задействованые при создании и изменении списка тестовых программ
        /// </summary>
        /// <param name="controls">список элементов</param>
        public void ProgramsListUiElementListAdd(params Control[] controls)
        {
            foreach (var control in controls)
            {
                ProgramsListUiElements.Add(control);
            }
        }

        /// <summary>
        /// элементы задействованые при редактировнии цикла
        /// </summary>
        /// <param name="controls"></param>
        public void NoneCycleUiElementListAdd(params Control[] controls)
        {
            foreach (var control in controls)
            {
                CycleUiElements.Add(control);
            }
        }

        /// <summary>
        /// элементы меняющие цвет при редактировнии цикла
        /// </summary>
        /// <param name="controls"></param>
        public void CycleUiElementChangeColorListAdd(params Control[] controls)
        {
            foreach (var control in controls)
            {
                CycleUiElementsChangeColor.Add(control);
            }
        }

        /// <summary>
        /// перекллючение режимов отображения элементов управления 
        /// </summary>
        /// <param name="mode">режим редактировния программа/список программ</param>
        public void UiModeEditProgramOrProgramList(ModeEdit mode)
        {
            //режим редактивроания программы
            foreach (var programUiElement in ProgramUiElements)
            {
                programUiElement.Enabled = mode switch
                {
                    ModeEdit.Program => true,
                    ModeEdit.ProgramsList => false,
                    _ => programUiElement.Enabled
                };
            }

            foreach (var programsListUiElement in ProgramsListUiElements)
            {
                programsListUiElement.Enabled = mode switch
                {
                    ModeEdit.Program => false,
                    ModeEdit.ProgramsList => true,
                    _ => programsListUiElement.Enabled
                };
            }
        }

        public void UiModeEditProgramOrCycle(ModeEdit mode)
        {
            //режим редактирования
            foreach (var cycleUiElement in CycleUiElements)
            {
                if (mode == ModeEdit.Program)
                {
                    cycleUiElement.Enabled = false;
                }

                else if (mode == ModeEdit.Cycle)
                {
                    cycleUiElement.Enabled = true;
                }

                else
                {
                    cycleUiElement.Enabled = cycleUiElement.Enabled;
                }
            }

            //режим редактивроания программы
            foreach (var programUiElement in ProgramUiElements)
            {
                if (mode == ModeEdit.Program)
                {
                    programUiElement.Enabled = true;
                }

                else if (mode == ModeEdit.Cycle)
                {
                    programUiElement.Enabled = false;
                }

                else
                {
                    programUiElement.Enabled = programUiElement.Enabled;
                }
            }
        }

        public byte[] ColorCycleToByte()
        {
            if (!cycleColorList.Any())
            {
                if (rnd.Next(0,3) == 0)
                {
                    //
                    cycleColorList.Enqueue(Color.FromArgb(255,243,214,188));
                    cycleColorList.Enqueue(Color.FromArgb(255,243,214,188));
                    //
                    cycleColorList.Enqueue(Color.FromArgb(255,192,181, 224));
                    cycleColorList.Enqueue(Color.FromArgb(5,162,151, 224));
                    cycleColorList.Enqueue(Color.FromArgb(255,243,214,188));
                    cycleColorList.Enqueue(Color.FromArgb(255,178,143,143));	
                    cycleColorList.Enqueue(Color.FromArgb(255,133,188,143));	
                    
                    cycleColorList.Enqueue(Color.FromArgb(255,112,181, 224));
                    cycleColorList.Enqueue(Color.FromArgb(255,162,117,128));
                    cycleColorList.Enqueue(Color.FromArgb(255,85,158,160));	
                    cycleColorList.Enqueue(Color.FromArgb(255,109,136,153));
                    cycleColorList.Enqueue(Color.FromArgb(255,243,212, 173));
                }
                
                if (rnd.Next(0,3) == 1)
                {
                    cycleColorList.Enqueue(Color.FromArgb(255,243,214,188));
                    //
                    cycleColorList.Enqueue(Color.FromArgb(255,243,214,188));
                    cycleColorList.Enqueue(Color.FromArgb(255,243,214,188));
                    //
                    cycleColorList.Enqueue(Color.FromArgb(255,178,143,143));	
                    cycleColorList.Enqueue(Color.FromArgb(255,133,188,143));
                    cycleColorList.Enqueue(Color.FromArgb(255,85,158,160));	
                    cycleColorList.Enqueue(Color.FromArgb(255,109,136,153));
                    cycleColorList.Enqueue(Color.FromArgb(255,243,212, 173));
                    cycleColorList.Enqueue(Color.FromArgb(255,192,181, 224));
                    cycleColorList.Enqueue(Color.FromArgb(5,162,151, 224));
                    cycleColorList.Enqueue(Color.FromArgb(255,112,181, 224));
                    cycleColorList.Enqueue(Color.FromArgb(255,162,117,128));
                }
                else
                {
                    //
                    cycleColorList.Enqueue(Color.FromArgb(255,243,214,188));
                    cycleColorList.Enqueue(Color.FromArgb(255,243,214,188));
                    //
                    cycleColorList.Enqueue(Color.FromArgb(255,112,181, 224));
                    cycleColorList.Enqueue(Color.FromArgb(255,162,117,128));
                    cycleColorList.Enqueue(Color.FromArgb(255,85,158,160));	
                    cycleColorList.Enqueue(Color.FromArgb(255,109,136,153));
                    cycleColorList.Enqueue(Color.FromArgb(255,243,212, 173));
                    cycleColorList.Enqueue(Color.FromArgb(255,192,181, 224));
                    cycleColorList.Enqueue(Color.FromArgb(5,162,151, 224));
                    cycleColorList.Enqueue(Color.FromArgb(255,243,214,188));
                    cycleColorList.Enqueue(Color.FromArgb(255,178,143,143));	
                    cycleColorList.Enqueue(Color.FromArgb(255,133,188,143));	
                   
                }
            }
            Color color = cycleColorList.Dequeue();
            byte[] byteColor = {color.A,color.R, color.G, color.B}; 
           return byteColor;
        }
        
        public Color ColorCycleToRGB(byte[] arrayRGB, bool additionalAlpha = false)
        {
            Color color = default;
            if (!additionalAlpha)
            {
                color= Color.FromArgb(arrayRGB[0],arrayRGB[1],arrayRGB[2],arrayRGB[3]);
            }
            else
            {
                color = Color.FromArgb(arrayRGB[0],arrayRGB[1]+10,arrayRGB[2]+30,arrayRGB[3]+30);
            }

            return color;
        }
       //  /// <summary>
       //  /// 
       //  /// </summary>
       //  /// <param name="color"></param>
       public void ChangeColorCycle(Color color)
        {
            for (int i = 0; i < CycleUiElementsChangeColor.Count; i++)
            {
                CycleUiElementsChangeColor[i].BackColor = color;
              
            }
        }

       //      foreach (var uiColor in CycleUiElementsChangeColor)
       //      {
       //          uiColor.BackColor = color switch
       //          {
       //              CycleColor.Red => Color.FromArgb(alphaChannel,188,143,143),	
       //              CycleColor.Green => Color.FromArgb(alphaChannel,143,188,143),	
       //              CycleColor.Blue => Color.FromArgb(alphaChannel,95,158,160),	
       //              CycleColor.Olive => Color.FromArgb(alphaChannel,119,136,153),
       //              CycleColor.Yellow => Color.FromArgb(alphaChannel,255,222, 173),
       //              CycleColor.Purpule => Color.FromArgb(alphaChannel,202,181, 224),
       //              _ => uiColor.BackColor
       //          }; 
       //          currentCycleColor = uiColor.BackColor;
       //      }
       //      return currentCycleColor;
       //  }
       //
       //  public void ChangeColorCycleModules(Control control, int cycleNum ,int rowCycleIndex, int alpha = 255)
       //  {
       //      Color color = default;
       //      if (cycleNum < 1)
       //      {
       //          cycleNum = 6;
       //      }
       //
       //      if (cycleNum > 6)
       //      {
       //          cycleNum = 1;
       //      }
       //
       //      switch (cycleNum)
       //      {
       //          case 1:
       //             color = ChangeColorCycle(CycleColor.Blue, alpha);
       //              break;
       //          case 2:
       //              color =ChangeColorCycle(CycleColor.Green, alpha);
       //              break;
       //          case 3:
       //              color =ChangeColorCycle(CycleColor.Olive, alpha);
       //              break;
       //          case 4:
       //              color = ChangeColorCycle(CycleColor.Purpule, alpha);
       //              break;
       //          case 5:
       //              color = ChangeColorCycle(CycleColor.Red, alpha);
       //              break;
       //          case 6:
       //              color = ChangeColorCycle(CycleColor.Yellow, alpha);
       //              break;
       //      }
       //      
           
    }
}