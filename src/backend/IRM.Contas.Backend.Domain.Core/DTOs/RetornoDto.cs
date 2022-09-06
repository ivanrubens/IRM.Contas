using System.Collections.Generic;

namespace IRM.Contas.Backend.Domain.Core.DTOs
{
    public class RetornoDto<T>
    {
        public bool Sucesso { get; set; }
        public T Resultado { get; set; }
        public List<ErroDto> Erros { get; set; }
        public RetornoDto()
        {
            Sucesso = true;
            Erros = new List<ErroDto>();
        }
    }
}
