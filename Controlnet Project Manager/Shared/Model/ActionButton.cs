namespace Controlnet_Project_Manager.Shared.Model;

public class ActionButton : Button
{
    public Action OnClick { get; set; }
    public string Text { get; set; }
    public string? Icon { get; set; }
}