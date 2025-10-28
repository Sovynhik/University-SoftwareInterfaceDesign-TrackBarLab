using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace TrackBarLab
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        // Свойство для Minimum (get/set для двухстороннего обмена)
        /// <summary>
        /// Свойство для настройки минимального значения TrackBar
        /// </summary>
        public int TrackMinimum
        {
            get { return (int)nudMinimum.Value; }
            set { nudMinimum.Value = value; }
        }

        // Свойство для Maximum (get/set для двухстороннего обмена)
        /// <summary>
        /// Свойство для настройки максимального значения TrackBar
        /// </summary>
        public int TrackMaximum
        {
            get { return (int)nudMaximum.Value; }
            set { nudMaximum.Value = value; }
        }

        // Свойство для Value (get/set для двухстороннего обмена)
        /// <summary>
        /// Свойство для настройки текущего значения TrackBar
        /// </summary>
        public int TrackValue
        {
            get { return (int)nudValue.Value; }
            set { nudValue.Value = value; }
        }

        // Свойство для Orientation (get/set для двухстороннего обмена)
        /// <summary>
        /// Свойство для настройки ориентации TrackBar (горизонтальная/вертикальная)
        /// </summary>
        public Orientation TrackOrientation
        {
            get { return rbHorizontal.Checked ? Orientation.Horizontal : Orientation.Vertical; }
            set
            {
                rbHorizontal.Checked = (value == Orientation.Horizontal);
                rbVertical.Checked = (value == Orientation.Vertical);
            }
        }

        // Свойство для TickFrequency (get/set для двухстороннего обмена)
        /// <summary>
        /// Свойство для настройки частоты тиков TrackBar
        /// </summary>
        public int TrackTickFrequency
        {
            get { return (int)nudTickFrequency.Value; }
            set { nudTickFrequency.Value = value; }
        }

        // Обработчик события Load формы (опционально, для инициализации)
        private void FormConfig_Load(object sender, EventArgs e)
        {
            // Здесь можно добавить валидацию, например, чтобы Value было между Min и Max
        }
    }
}