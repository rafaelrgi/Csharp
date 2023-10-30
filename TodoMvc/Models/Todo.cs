using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoMvc.Models;

public class Todo
{
  [Key]
  public int Id { get; set; }

  [DisplayName("Título")]
  [Required(ErrorMessage = "Campo obrigatório")]
  public string Title { get; set; } = "";

  [DisplayName("Concluída?")]
  public bool Done { get; set; }

  [DisplayName("Criada em")]
  public DateTime CreatedAt { get; set; } = DateTime.Now;

  [DisplayName("Alterada em")]
  public DateTime UpdatedAt { get; set; } = DateTime.Now;

  [DisplayName("Proprietário")]
  public string User { get; set; } = "";
}
