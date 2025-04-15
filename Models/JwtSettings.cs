namespace ProdutosComAutenticacaoJWT.Models;
internal class JwtSettings
{
    public string? Segredo { get; set; }
    public int TempoExpiracao { get; set; }
    public string? Emissor { get; set; }
    public string? Audiencia { get; set; }

}