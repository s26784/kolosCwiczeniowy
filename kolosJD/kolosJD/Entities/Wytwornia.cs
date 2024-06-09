namespace kolosJD.Entities;

public class Wytwornia
{
    public int IdWytwornia { get; set; }
    
    public string Nazwa { get; set; }
    
    public ICollection<Album> Albumy { get; set; } = new List<Album>();
}