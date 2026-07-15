using System.Data;
using Microsoft.Data.SqlClient;
using Teste.ScoreAPI.Domain.Entities;

namespace Teste.ScoreAPI.Infrastructure.Mappers;

internal static class CustomerMapper
{
    public static Customer Map(SqlDataReader reader)
    {
        var id = reader.GetGuid(reader.GetOrdinal("Id"));
        var name = reader.IsDBNull(reader.GetOrdinal("Name"))
            ? null
            : reader.GetString(reader.GetOrdinal("Name"));
        var email = reader.IsDBNull(reader.GetOrdinal("Email"))
            ? null
            : reader.GetString(reader.GetOrdinal("Email"));
        var birthDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("BirthDate")));
        var cpf = reader.GetString(reader.GetOrdinal("CPF")).Trim();
        var annualIncome = reader.GetDecimal(reader.GetOrdinal("AnnualIncome"));
        var areaCode = reader.GetString(reader.GetOrdinal("AreaCode")).Trim();
        var phoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
        var street = reader.IsDBNull(reader.GetOrdinal("Street"))
            ? null
            : reader.GetString(reader.GetOrdinal("Street"));
        var addressNumber = reader.IsDBNull(reader.GetOrdinal("AddressNumber"))
            ? null
            : reader.GetString(reader.GetOrdinal("AddressNumber"));
        var addressComplement = reader.IsDBNull(reader.GetOrdinal("AddressComplement"))
            ? null
            : reader.GetString(reader.GetOrdinal("AddressComplement"));
        var zipCode = reader.IsDBNull(reader.GetOrdinal("ZipCode"))
            ? null
            : reader.GetString(reader.GetOrdinal("ZipCode")).Trim();
        var state = reader.GetString(reader.GetOrdinal("State")).Trim();

        return new Customer(
            id,
            name,
            email,
            birthDate,
            new Phone(areaCode, phoneNumber),
            cpf,
            new Address(street, addressNumber, addressComplement, zipCode, state),
            annualIncome);
    }

    public static void AddParameters(SqlCommand command, Customer customer)
    {
        command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = customer.Id;
        command.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value =
            (object?)customer.Name ?? DBNull.Value;
        command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value =
            (object?)customer.Email ?? DBNull.Value;
        command.Parameters.Add("@BirthDate", SqlDbType.Date).Value =
            customer.BirthDate.ToDateTime(TimeOnly.MinValue);
        command.Parameters.Add("@Cpf", SqlDbType.Char, 11).Value = customer.Cpf;
        command.Parameters.Add("@AnnualIncome", SqlDbType.Decimal).Value = customer.AnnualIncome;
        command.Parameters["@AnnualIncome"].Precision = 18;
        command.Parameters["@AnnualIncome"].Scale = 2;
        command.Parameters.Add("@AreaCode", SqlDbType.Char, 2).Value = customer.Phone.Ddd;
        command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 20).Value = customer.Phone.Number;
        command.Parameters.Add("@Street", SqlDbType.NVarChar, 200).Value =
            (object?)customer.Address.Street ?? DBNull.Value;
        command.Parameters.Add("@AddressNumber", SqlDbType.NVarChar, 20).Value =
            (object?)customer.Address.Number ?? DBNull.Value;
        command.Parameters.Add("@AddressComplement", SqlDbType.NVarChar, 150).Value =
            (object?)customer.Address.Complement ?? DBNull.Value;
        command.Parameters.Add("@ZipCode", SqlDbType.Char, 8).Value =
            (object?)customer.Address.ZipCode ?? DBNull.Value;
        command.Parameters.Add("@State", SqlDbType.Char, 2).Value = customer.Address.State;
    }
}
