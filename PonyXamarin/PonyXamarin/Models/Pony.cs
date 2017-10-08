
namespace PonyXamarin.Models
{
    public class Pony
    {
        public Pony() {
            this.PonyStyle = new PonyStyle();
        }

        public string Name { get; set; }
        public PonyStyle PonyStyle { get; set; }
    }
}
