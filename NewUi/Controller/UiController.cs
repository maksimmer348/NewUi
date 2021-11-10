using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace NewUi
{
    public class UiController
    {
        public List<Control> ProgramUiElements = new();
        public List<Control> ProgramsListUiElements = new();
        public List<Control> CycleUiElements = new();

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
    }
}