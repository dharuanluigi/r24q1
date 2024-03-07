namespace r24q1.DTOs;

public record ApiSuccess(
    Balance Saldo,

    IEnumerable<Extract>? Ultimas_transacoes
);