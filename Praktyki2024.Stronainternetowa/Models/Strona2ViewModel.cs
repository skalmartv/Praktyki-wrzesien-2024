namespace Praktyki2024.Stronainternetowa.Models
{
    public class Strona2ViewModel
    {
        public string Pod11 { get; set; }
        public string Pod21 { get; set; }
        public string Pod31 { get; set; }
        public string Pod41 { get; set; }
        public string Pod51 { get; set; }

        public Strona2ViewModel(string pod11, string pod21, string pod31, string pod41, string pod51)
        {
            this.Pod11 = pod11;
            this.Pod21 = pod21;
            this.Pod31 = pod31;
            this.Pod41 = pod41;
            this.Pod51 = pod51;
        }
    }
}