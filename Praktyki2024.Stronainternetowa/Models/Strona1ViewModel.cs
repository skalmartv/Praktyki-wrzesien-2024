namespace Praktyki2024.Stronainternetowa.Models
{
    public class Strona1ViewModel
    {
        public string Pod1 { get; set; }
        public string Pod2 { get; set; }
        public float Pod3 { get; set; }
        public bool Pod4 { get; set; }
        public float Pod5 { get; set; }

        public Strona1ViewModel(string pod1, string pod2, float pod3, bool pod4, float pod5)
        {
            this.Pod1 = pod1;
            this.Pod2 = pod2;
            this.Pod3 = pod3;
            this.Pod4 = pod4;
            this.Pod5 = pod5;
        }
    }
}