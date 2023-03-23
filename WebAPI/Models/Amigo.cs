namespace WebAPI.Models
{
    public class Amigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime Aniversario { get; set; }
    }
}
