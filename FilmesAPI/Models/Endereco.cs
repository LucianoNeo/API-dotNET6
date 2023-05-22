using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O Logradouro do endereço é obrigatório")]
    public string Logradouro { get; set; }
    [Required(ErrorMessage = "O Numero do endereço é obrigatório")]
    public int Numero { get; set; }
    public virtual Cinema Cinema { get; set; } // explicita relação 1 x 1 com cinema

}
