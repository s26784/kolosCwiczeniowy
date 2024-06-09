namespace kolosJD.Entities;

public class Utwor
{
    public int IdUtwor { get; set; }
    public string NazwaUtworu { get; set; }
    public float CzasTrwania { get; set; }
    public int? IdAlbum { get; set; }
    
    public virtual Album Album { get; set; }
    
    public ICollection<WykonawcaUtworu> WykonawcyUtworow { get; set; } = new List<WykonawcaUtworu>();
    
}