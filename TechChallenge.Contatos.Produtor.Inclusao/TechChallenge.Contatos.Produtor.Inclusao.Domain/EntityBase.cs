namespace TechChallenge.Domain
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;
        }
    }
}
