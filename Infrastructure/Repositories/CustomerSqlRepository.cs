using System.Data;
using Microsoft.Data.SqlClient;
using Teste.ScoreAPI.Domain.Entities;
using Teste.ScoreAPI.Domain.Interfaces;
using Teste.ScoreAPI.Infrastructure.Data;
using Teste.ScoreAPI.Infrastructure.Mappers;

namespace Teste.ScoreAPI.Infrastructure.Repositories;

public sealed class CustomerSqlRepository : ICustomerRepository
{
    private readonly ConnectionFactory _connectionFactory;

    public CustomerSqlRepository(ConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> ExistsByCpfAsync(string cpf, CancellationToken cancellationToken = default)
    {
        await using var connection = _connectionFactory.Create();
        await connection.OpenAsync(cancellationToken);

        await using var command = new SqlCommand(CustomerSqlQueries.ExistsByCpf, connection);
        command.Parameters.Add("@Cpf", SqlDbType.Char, 11).Value = cpf;

        var result = await command.ExecuteScalarAsync(cancellationToken);
        return result is not null && result != DBNull.Value;
    }

    public async Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        await using var connection = _connectionFactory.Create();
        await connection.OpenAsync(cancellationToken);

        await using var command = new SqlCommand(CustomerSqlQueries.Insert, connection);
        CustomerMapper.AddParameters(command, customer);

        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public async Task<bool> UpdateByCpfAsync(string cpf, Customer customer, CancellationToken cancellationToken = default)
    {
        await using var connection = _connectionFactory.Create();
        await connection.OpenAsync(cancellationToken);

        await using var command = new SqlCommand(CustomerSqlQueries.UpdateByCpf, connection);
        CustomerMapper.AddParameters(command, customer);
        command.Parameters["@Cpf"].Value = cpf;

        var rowsAffected = await command.ExecuteNonQueryAsync(cancellationToken);
        return rowsAffected > 0;
    }

    public async Task<Customer?> GetByCpfAsync(string cpf, CancellationToken cancellationToken = default)
    {
        await using var connection = _connectionFactory.Create();
        await connection.OpenAsync(cancellationToken);

        await using var command = new SqlCommand(CustomerSqlQueries.GetByCpf, connection);
        command.Parameters.Add("@Cpf", SqlDbType.Char, 11).Value = cpf;

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        if (!await reader.ReadAsync(cancellationToken))
        {
            return null;
        }

        return CustomerMapper.Map(reader);
    }

    public async Task<IReadOnlyCollection<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        await using var connection = _connectionFactory.Create();
        await connection.OpenAsync(cancellationToken);

        await using var command = new SqlCommand(CustomerSqlQueries.GetAll, connection);

        var customers = new List<Customer>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            customers.Add(CustomerMapper.Map(reader));
        }

        return customers;
    }
}
