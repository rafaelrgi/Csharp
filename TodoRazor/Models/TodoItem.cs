using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Todo;

public class TodoItem
{
  [Key]
  public int Id { get; set; }

  [DisplayName("Concluída?")]
  public bool Done { get; set; }

  [DisplayName("Tarefa")]
  [Required(ErrorMessage = "Informe o campo")]
  [StringLength(64, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres", MinimumLength = 4)]
  public string Title { get; set; }
}
