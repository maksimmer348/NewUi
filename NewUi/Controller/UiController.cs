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
        
        public List<Control> ProgramUiElements = new();
        public List<Control> ProgramsListUiElements = new();
        
        public List<Control> CycleUiElements = new();
        public List<Control> CycleUiElementsChangeColor = new();
        Queue<Color> colors = new Queue<Color>();

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
       public Color ChangeColorCycle(CycleColor color, int alphaChannel)
        {
            foreach (var uiColor in CycleUiElementsChangeColor)
            {
                uiColor.BackColor = color switch
                {
                    CycleColor.Red => Color.FromArgb(alphaChannel,188,143,143),	
                    CycleColor.Green => Color.FromArgb(alphaChannel,143,188,143),	
                    CycleColor.Blue => Color.FromArgb(alphaChannel,95,158,160),	
                    CycleColor.Olive => Color.FromArgb(alphaChannel,119,136,153),
                    CycleColor.Yellow => Color.FromArgb(alphaChannel,255,222, 173),
                    CycleColor.Purpule => Color.FromArgb(alphaChannel,202,181, 224),
                    _ => uiColor.BackColor
                }; 
                currentCycleColor = uiColor.BackColor;
            }
            return currentCycleColor;
        }

        public void ChangeColorCycleModules(Control control, int cycleNum ,int rowCycleIndex, int alpha = 255)
        {
           
                   color.Enqueue(); = ChangeColorCycle(CycleColor.Blue, alpha);
               
                    color =ChangeColorCycle(CycleColor.Green, alpha);
                    break;
                case 3:
                    color =ChangeColorCycle(CycleColor.Olive, alpha);
                    break;
                case 4:
                    color = ChangeColorCycle(CycleColor.Purpule, alpha);
                    break;
                case 5:
                    color = ChangeColorCycle(CycleColor.Red, alpha);
                    break;
                case 6:
                    color = ChangeColorCycle(CycleColor.Yellow, alpha);
                    break;
            }
            
            ((DataGridView)control).Rows[rowCycleIndex].DefaultCellStyle.BackColor = color;
        }

    }
}