namespace Controlnet_Project_Manager.Shared.Model;

public class ExportExcelButton: Button
{
    public string Text { get; set; }
    public Action OnClick { get; set; }
    public string? Icon { get; set; }
    public string FileInput { get; set; }
}