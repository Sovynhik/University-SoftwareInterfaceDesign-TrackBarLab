using System;
using System.Windows.Forms;

namespace TrackBarLab
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        // Обработчик события клика на кнопке "Настройки"
        // Открывает модальное окно конфигурации и применяет изменения, если OK
        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            // Создание экземпляра модальной формы
            FormConfig config = new FormConfig();

            // Загрузка текущих значений TrackBar в свойства модальной формы (двухсторонний обмен)
            config.TrackMinimum = tbMainTrackBar.Minimum;
            config.TrackMaximum = tbMainTrackBar.Maximum;
            config.TrackValue = tbMainTrackBar.Value;
            config.TrackOrientation = tbMainTrackBar.Orientation;
            config.TrackTickFrequency = tbMainTrackBar.TickFrequency;

            // Показ модального окна
            if (config.ShowDialog() == DialogResult.OK)
            {
                // Применение настроек из модальной формы к TrackBar (прямое присваивание без if/switch)
                tbMainTrackBar.Minimum = config.TrackMinimum;
                tbMainTrackBar.Maximum = config.TrackMaximum;
                tbMainTrackBar.Value = config.TrackValue;
                tbMainTrackBar.Orientation = config.TrackOrientation;
                tbMainTrackBar.TickFrequency = config.TrackTickFrequency;
            }
        }
    }
}