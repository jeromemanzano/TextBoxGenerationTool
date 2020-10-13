using Xamarin.Forms;

namespace TextBoxGenerationTool.Models
{
    internal class TextInfoModel
    {
        public Color TextColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
        public int BorderSize { get; set; }
        public int ShadowSize { get; set; }
        public int FontSize { get; set; }
        public string SelectedFont { get; set; }
        public string InputText { get; set; }
    }
}
