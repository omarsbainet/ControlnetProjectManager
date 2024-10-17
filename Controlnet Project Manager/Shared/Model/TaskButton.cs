namespace Controlnet_Project_Manager.Shared.Model
{
    public class TaskButton : Button
    {
        public Func<Task> OnClick { get; set; }
        public string Text { get; set; }
        public string? Icon { get; set; }
    }
}
