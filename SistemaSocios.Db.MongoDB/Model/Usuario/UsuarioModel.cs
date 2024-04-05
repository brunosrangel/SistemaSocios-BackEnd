using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Usuario")]
public class UsuarioModel : DocModel
{
    public string NomeUsuario { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Profissao { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime DataIniciacao { get; set; }
    public DateTime DataUltimaObrigacao { get; set; }

    // Chaves estrangeiras sem relação direta
    public Guid EscolaridadeId { get; set; } 
    public Guid PerfilId { get; set; } 
    public Guid EntidadeId { get; set; } 

    // Chaves estrangeiras com relação direta
    public Guid JurosMensalidadeId { get; set; } 
    public Guid ValorMensalidadeId { get; set; } 
    public Guid MensalidadeId { get; set; } 
    public Guid EnderecoId { get; set; } 
    public Guid TelefoneId { get; set; }
    public Guid RedeSocialId { get; set; }

    // Propriedade de navegação
    public virtual List<TelefoneUsuarioModel> Telefones { get; set; }
    public virtual List<ValorMensalidadeModel> ValorMensalidades { get; set; }
    public virtual List<JurosMensalidadeModel> JurosMensalidades { get; set; }
    public virtual List<HistoricoMensalidadesModel> HistoricosMensalidades { get; set; }
    public virtual List<EnderecoUsuarioModel> Enderecos { get; set; }
    public virtual List<RedeSocialModel> RedesSociais { get; set; }

    // Propriedade de navegação sem relação direta
    public virtual EscolaridadeUsuarioModel Escolaridade { get; set; }
    public virtual perfilModel Perfil { get; set; }
    public virtual EntidadeModel Entidade { get; set; }


}
