namespace CelsoGuitarsAuthentication.Infra.Entidade
{
    public abstract class Entidade<T>
    {
        public virtual T ID { get; set; }
    }
}
