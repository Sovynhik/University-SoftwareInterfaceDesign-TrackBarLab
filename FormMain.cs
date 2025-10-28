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

                // Динамическая подстройка размера формы в зависимости от ориентации
                AdjustFormSize();
            }
        }

        // Метод для динамической подстройки размера формы и расположения компонентов
        private void AdjustFormSize()
        {
            const int margin = 24; // Общий отступ (12 с каждой стороны)
            const int buttonHeight = 50; // Высота кнопки + отступ
            const int trackBarWidth = 45; // Фиксированная ширина для вертикального TrackBar

            if (tbMainTrackBar.Orientation == Orientation.Horizontal)
            {
                // Горизонтальная ориентация: форма широкая, TrackBar сверху по центру
                this.ClientSize = new System.Drawing.Size(
                    Math.Max(400, this.ClientSize.Width), // Минимальная ширина
                    100 + buttonHeight); // Фиксированная высота

                tbMainTrackBar.Size = new System.Drawing.Size(this.ClientSize.Width - margin, trackBarWidth);
                tbMainTrackBar.Location = new System.Drawing.Point(margin / 2, 12); // По центру по горизонтали

                btnOpenConfig.Location = new System.Drawing.Point(margin / 2, this.ClientSize.Height - buttonHeight + 12);
                btnOpenConfig.Width = this.ClientSize.Width - margin;
            }
            else // Orientation.Vertical
            {
                // Вертикальная ориентация: форма высокая, TrackBar по центру
                this.ClientSize = new System.Drawing.Size(
                    100 + margin, // Узкая ширина
                    Math.Max(400, this.ClientSize.Height)); // Минимальная высота

                tbMainTrackBar.Size = new System.Drawing.Size(trackBarWidth, this.ClientSize.Height - buttonHeight - margin);

                // Центрирование по горизонтали и вертикали
                int centerX = (this.ClientSize.Width - tbMainTrackBar.Width) / 2;
                int centerY = (this.ClientSize.Height - buttonHeight - tbMainTrackBar.Height) / 2;
                tbMainTrackBar.Location = new System.Drawing.Point(centerX, centerY);

                // Кнопка внизу по центру
                btnOpenConfig.Width = this.ClientSize.Width - margin;
                btnOpenConfig.Location = new System.Drawing.Point(margin / 2, this.ClientSize.Height - buttonHeight + 12);
            }
        }

        // Обработчик изменения размера формы (опционально, если пользователь может менять размер)
        private void FormMain_Resize(object sender, EventArgs e)
        {
            AdjustFormSize();
        }
    }
}