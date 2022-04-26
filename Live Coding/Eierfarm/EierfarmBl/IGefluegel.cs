
namespace EierfarmBl
{
    public interface IGefluegel
    {
        string Eier { get; set; }
        double Gewicht { get; set; }

        void EiLegen();
    }
}