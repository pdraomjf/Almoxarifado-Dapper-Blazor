using AlmoxarifadoFront.DTO.Validators;

namespace AlmoxarifadoFront.DTO
{
    public class ProdutoDTO : ModeloDTO<ProdutoDTO>
    {
        public string? Nome { get; set; } = "";
        public int? Quantidade { get; set; }
        public string Tipo { get; set; } = "";
        public string Categoria { get; set; } = "";
        public override void ConfigValidator(out Validator<ProdutoDTO> validator, out ProdutoDTO obj)
        {
            validator = new ProdutoValidator();
            obj = this;
        }
    }
}
