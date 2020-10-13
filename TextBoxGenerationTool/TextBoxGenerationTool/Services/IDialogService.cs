using System.Threading.Tasks;

namespace TextBoxGenerationTool.Services
{
    public interface IDialogService
    {
        Task DisplayAlert(string title, string message, string cancel);
    }
}
