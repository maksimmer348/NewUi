using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NewUi
{
    public enum ModeEdit
    {
        Program,
        ProgramsList
    }

    public class UiController
    {
        public List<Control> ProgramUiElements = new();
        public List<Control> ProgramsListUiElements = new();

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
        /// перекллючение режимов элементов управления 
        /// </summary>
        /// <param name="mode">режим редактировния программа/список программ</param>
        public void ProgramOrProgramsListUiMode(ModeEdit mode)
        {
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
                    ModeEdit.ProgramsList => true,
                    ModeEdit.Program => false,
                    _ => programsListUiElement.Enabled
                };
            }
        }
    }
}

