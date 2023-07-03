namespace API.Dtos;

public class CatalogoProdServAddUpdateDto
{
    public int Id { get; set; }
    public string Division { get; set; } = null!;
    public string Grupo { get; set; } = null!;
    public string Clase { get; set; } = null!;
}
