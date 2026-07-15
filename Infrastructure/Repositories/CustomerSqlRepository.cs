using Teste.ScoreAPI.Domain.Entities;
using Teste.ScoreAPI.Domain.Interfaces;
using Teste.ScoreAPI.Infrastructure.Data;

namespace Teste.ScoreAPI.Infrastructure.Repositories;

public sealed class CustomerSqlRepository : ICustomerRepository
{
    private readonly ConnectionFactory _connectionFactory;

    private const string ExistsByCpfSql = @"
    SELECT 1
    FROM Clients
    WHERE CPF = @Cpf";

    private const string GetByCpfSql = @"
    SELECT
    Id,
    Name,
    Email,
    BirthDate,
    CPF,
    AnnualIncome,
    AreaCode,
    PhoneNumber,
    Street,
    AddressNumber,
    AddressComplement,
    ZipCode,
    State
    FROM Clients
    WHERE CPF = @Cpf";

    private const string GetAllSql = @"
    SELECT
        Id,
        Name,
        Email,
        BirthDate,
        CPF,
        AnnualIncome,
        AreaCode,
        PhoneNumber,
        Street,
        AddressNumber,
        AddressComplement,
        ZipCode,
        State
    FROM Clients";

    private const string InsertSql = @"
    INSERT INTO Clients
    (
        Name,
        Email,
        BirthDate,
        CPF,
        AnnualIncome,
        AreaCode,
        PhoneNumber,
        Street,
        AddressNumber,
        AddressComplement,
        ZipCode,
        State
    )
    VALUES
    (
        @Name,
        @Email,
        @BirthDate,
        @Cpf,
        @AnnualIncome,
        @AreaCode,
        @PhoneNumber,
        @Street,
        @AddressNumber,
        @AddressComplement,
        @ZipCode,
        @State
    )";

    private const string UpdateByCpfSql = @"
    UPDATE Clients
    SET
        Name = @Name,
        Email = @Email,
        BirthDate = @BirthDate,
        AnnualIncome = @AnnualIncome,
        AreaCode = @AreaCode,
        PhoneNumber = @PhoneNumber,
        Street = @Street,
        AddressNumber = @AddressNumber,
        AddressComplement = @AddressComplement,
        ZipCode = @ZipCode,
        State = @State
    WHERE CPF = @Cpf";

    public CustomerSqlRepository(ConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public Task<bool> ExistsByCpfAsync(string cpf, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateByCpfAsync(string cpf, Customer customer, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> GetByCpfAsync(string cpf, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
