namespace MyStock.Domain.Exceptions
{
    /// <summary>
    /// Excepción que se lanza cuando una entidad no es encontrada
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message) { }

        public EntityNotFoundException(string entityName, int id)
            : base($"{entityName} con ID {id} no fue encontrado") { }
    }

    /// <summary>
    /// Excepción que se lanza cuando hay un error de negocio
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }

    /// <summary>
    /// Excepción que se lanza cuando no hay suficiente stock
    /// </summary>
    public class InsufficientStockException : BusinessException
    {
        public InsufficientStockException(string message) : base(message) { }

        public InsufficientStockException(int available, int requested)
            : base($"Stock insuficiente. Disponible: {available}, Solicitado: {requested}") { }
    }

    /// <summary>
    /// Excepción que se lanza cuando hay un conflicto de duplicados
    /// </summary>
    public class DuplicateEntityException : BusinessException
    {
        public DuplicateEntityException(string message) : base(message) { }
    }
}
