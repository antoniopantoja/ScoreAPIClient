namespace Teste.ScoreAPI.Infrastructure.Repositories;

internal static class CustomerSqlQueries
{

    public const string ExistsByCpf = @"
    SELECT 1
    FROM Clients
    WHERE CPF = @Cpf";

    public const string GetByCpf = @"
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

    public const string GetAll = @"
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

    public const string Insert = @"
    INSERT INTO Clients
    (
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
    )
    VALUES
    (
    @Id,
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

    public const string UpdateByCpf = @"
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
}
