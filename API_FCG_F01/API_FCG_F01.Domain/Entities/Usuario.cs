using System.Net.Mail;

namespace API_FCG_F01.Domain.Entities
{
    /// <summary>
    /// Classe que representa um usuário do sistema.
    /// </summary>
    //public sealed class Usuario : EntityBase
    //{
    //    public string Nome { get; private set; }
    //    public string? Email { get; private set; }
    //    public string Senha { get; private set; }
    //    public bool IsAdministrador { get; private set; }
    //    public bool Ativo { get; private set; }
    //    public BibliotecaJogos? Biblioteca { get; private set; }

    //    private Usuario() { }

    //    public Usuario(string nome, string? email, string senhaHash, bool isAdministrador)
    //    {            
    //        Nome = nome ?? throw new ArgumentNullException(nameof(nome));
    //        Email = email ?? throw new ArgumentNullException( nameof(email));
    //        Senha = senhaHash ?? throw new ArgumentNullException(nameof(senhaHash));
    //        IsAdministrador = isAdministrador;
    //        Ativo = true;
    //        DataCriacao = DateTimeOffset.UtcNow;
    //    }

    //    public void Ativar() => Ativo = true;
    //    public void Desativar() => Ativo = false;
    //    public void AlterarNome(string novoNome) => Nome = novoNome ?? throw new ArgumentNullException(nameof(novoNome));
    //    public void AlterarEmail(string? novoEmail) => Email = novoEmail;
    //    public void AlterarSenhaHash(string novoHash) => Senha = novoHash ?? throw new ArgumentNullException(nameof(novoHash));        
    //}

    /// <summary>
    /// Classe que representa um usuário do sistema.
    /// </summary>
    public sealed class Usuario : EntityBase
    {
        public string Nome { get; private set; }
        public string? Email { get; private set; }
        public string Senha { get; private set; }
        public bool IsAdministrador { get; private set; }
        public bool Ativo { get; private set; }
        public BibliotecaJogos? Biblioteca { get; private set; }

        private Usuario() { }

        public Usuario(string nome, string? email, string senhaHash, bool isAdministrador)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Senha = senhaHash ?? throw new ArgumentNullException(nameof(senhaHash));
            IsAdministrador = isAdministrador;
            Ativo = true;
            DataCriacao = DateTimeOffset.UtcNow;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public void AlterarNome(string novoNome) => Nome = novoNome ?? throw new ArgumentNullException(nameof(novoNome));

        public void AlterarEmail(string? novoEmail)
        {
            if (string.IsNullOrWhiteSpace(novoEmail))
                throw new ArgumentException("Email não pode ser vazio", nameof(novoEmail));

            if (!IsValidEmail(novoEmail))
                throw new ArgumentException("Formato de email inválido", nameof(novoEmail));

            Email = novoEmail;
        }

        public void AlterarSenhaHash(string novoHash) => Senha = novoHash ?? throw new ArgumentNullException(nameof(novoHash));

        /// <summary>
        /// Valida se o email possui formato válido.
        /// </summary>
        private static bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
