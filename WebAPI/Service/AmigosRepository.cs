using WebAPI.Models;

namespace WebAPI.Service
{
    public class AmigosRepository
    {
        private AmigoDbContext _context { get; set; }

        public AmigosRepository(AmigoDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Amigo> GetAll()
        {
            return _context.amigo.AsEnumerable();
        }

        public Amigo GetAmigoById(int id)
        {
            return _context.amigo.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Amigo amigo)
        {
            this._context.amigo.Add(amigo);
            this._context.SaveChanges();
        }

        public void Delete(int id)
        {
            var amigo = _context.amigo.FirstOrDefault(x => x.Id == id);

            this._context.amigo.Remove(amigo);
            this._context.SaveChanges();
        }

        public void Update(int id, Amigo amigoAtualizado)
        {
            var amigo = _context.amigo.FirstOrDefault(x => x.Id == id);

            amigo.Nome = amigoAtualizado.Nome;
            amigo.Sobrenome = amigoAtualizado.Sobrenome;
            amigo.Email = amigoAtualizado.Email;
            amigo.Telefone = amigoAtualizado.Telefone;
            amigo.Aniversario = amigoAtualizado.Aniversario;

            _context.amigo.Update(amigo);
            this._context.SaveChanges();
        }
    }
}
