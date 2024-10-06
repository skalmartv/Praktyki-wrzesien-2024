namespace Praktyki2024.Stronainternetowa.Models
{
    public class Strona2ViewModel
    {
        public int Pod11 { get; set; }
        public int Pod21 { get; set; }
        public int Pod31 { get; set; }
        public int Pod41 { get; set; }
        public int Pod51 { get; set; }

        public Strona2ViewModel(int pod11, int pod21, int pod31, int pod41, int pod51)
        {
            this.Pod11 = pod11;
            this.Pod21 = pod21;
            this.Pod31 = pod31;
            this.Pod41 = pod41;
            this.Pod51 = pod51;
        }
    }
}