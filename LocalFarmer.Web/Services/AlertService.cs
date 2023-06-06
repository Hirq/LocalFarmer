namespace LocalFarmer.Web.Services
{
    public class AlertService
    {
        public bool IsSuccessAlert { get; set; }
        public string SuccessText { get; set; }

        public void SetSuccessAlert(string text)
        {
            IsSuccessAlert = true;
            SuccessText = text;
        }
    }
}
